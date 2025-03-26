using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTahmin
{
    public partial class TedarikTahminiForm : Form
    {
        public TedarikTahminiForm()
        {
            InitializeComponent();
        }

        private void TedarikTahminiForm_Load(object sender, EventArgs e)
        {
            string connectionString = MainForm.sqlBaglanti; // Bağlantı dizesini al

            string query = "SELECT UrunAdi FROM Stok"; // Tüm ürün adlarını getir

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // Verileri tek tek oku
                            {

                                // Null kontrolü yap ve gerekirse boş string ("") ata
                                string urunAdi = reader["UrunAdi"] as string ?? "";

                                // Eğer ürün adı tamamen boş değilse ComboBox'a ekle
                                if (!string.IsNullOrWhiteSpace(urunAdi))
                                {
                                    CboxUrunAdı.Items.Add(urunAdi);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CboxUrunAdı_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboxUrunAdı.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string secilenUrun = CboxUrunAdı.SelectedItem.ToString();
            string connectionString = MainForm.sqlBaglanti;

            // Seçilen ürünün sadece geçen yılın (2024) siparişlerini 3 aylık sezonlara göre getir
            string querySatis = @"
            SELECT 
                CASE 
                    WHEN MONTH(SP.SiparisTarihi) IN (1, 2, 3) THEN '1. Sezon (Ocak-Şubat-Mart)'
                    WHEN MONTH(SP.SiparisTarihi) IN (4, 5, 6) THEN '2. Sezon (Nisan-Mayıs-Haziran)'
                    WHEN MONTH(SP.SiparisTarihi) IN (7, 8, 9) THEN '3. Sezon (Temmuz-Ağustos-Eylül)'
                    WHEN MONTH(SP.SiparisTarihi) IN (10, 11, 12) THEN '4. Sezon (Ekim-Kasım-Aralık)'
                END AS Sezon,
                SUM(SD.Miktar) AS [Toplam Satış Miktarı]
            FROM SiparisDetaylari SD
            JOIN Stok S ON SD.StokID = S.StokID
            JOIN Siparisler SP ON SD.SiparisID = SP.SiparisID
            WHERE YEAR(SP.SiparisTarihi) = YEAR(GETDATE()) - 1 -- Sadece geçen yılın verileri
            AND S.UrunAdi = @UrunAdi
            GROUP BY 
                CASE 
                    WHEN MONTH(SP.SiparisTarihi) IN (1, 2, 3) THEN '1. Sezon (Ocak-Şubat-Mart)'
                    WHEN MONTH(SP.SiparisTarihi) IN (4, 5, 6) THEN '2. Sezon (Nisan-Mayıs-Haziran)'
                    WHEN MONTH(SP.SiparisTarihi) IN (7, 8, 9) THEN '3. Sezon (Temmuz-Ağustos-Eylül)'
                    WHEN MONTH(SP.SiparisTarihi) IN (10, 11, 12) THEN '4. Sezon (Ekim-Kasım-Aralık)'
                END
            ORDER BY MIN(SP.SiparisTarihi) ASC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand commandSatis = new SqlCommand(querySatis, connection))
                    {
                        commandSatis.Parameters.AddWithValue("@UrunAdi", secilenUrun);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(commandSatis))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dtgSiparis.DataSource = dt;

                            int toplamSatilanUrunSayisi = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                toplamSatilanUrunSayisi += Convert.ToInt32(row["Toplam Satış Miktarı"]);
                            }

                            lblSatisSayisi.Text = "2024 Yılındaki Toplam Satılan Ürün Sayısı: " + toplamSatilanUrunSayisi;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler alınırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Regresyon katsayılarını hesaplayan fonksiyon
        public static (double a, double b) CalculateRegression(List<int> periods, List<int> actualSales)
        {
            int n = periods.Count;
            double sumX = periods.Sum();
            double sumY = actualSales.Sum();
            double sumXY = periods.Zip(actualSales, (x, y) => x * y).Sum();
            double sumX2 = periods.Select(x => x * x).Sum();

            double b = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double a = (sumY - b * sumX) / n;

            return (a, b);
        }

        // Tahmin edilen satışları hesaplayan fonksiyon
        public static List<double> PredictSales(List<int> periods, double a, double b)
        {
            return periods.Select(x => a + b * x).ToList();
        }

        // Mevsimsel indeksleri hesaplayan fonksiyon
        public static List<double> CalculateSeasonalIndices(List<int> actualSales, List<double> predictedSales)
        {
            List<double> indices = new List<double>();

            for (int i = 0; i < actualSales.Count; i++)
            {
                double index = (actualSales[i] / predictedSales[i]) * 100;
                indices.Add(index);
            }

            return indices;
        }

        // Satış tahminlerini mevsimsel düzeltme indeksine göre düzelten fonksiyon
        public static List<double> AdjustSales(List<double> predictedSales, double averageSeasonalIndex)
        {
            return predictedSales.Select(x => x * (averageSeasonalIndex / 100)).ToList();
        }
        private void BtnTahminEt_Click(object sender, EventArgs e)
        {
            if (CboxUrunAdı.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DataGridView'den verileri al
            DataTable dtVeriler = (DataTable)dtgSiparis.DataSource;

            if (dtVeriler == null || dtVeriler.Rows.Count == 0)
            {
                MessageBox.Show("DataGridView boş! Verileri yükleyin ve tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Satış verilerini al
            List<int> periods = new List<int>();  // Periyotlar (örneğin, aylar)
            List<int> actualSales = new List<int>();  // Gerçek satış miktarları
            periods.Add(1);
            periods.Add(2);
            periods.Add(3);
            periods.Add(4);
            foreach (DataRow row in dtVeriler.Rows)
            {
               
                actualSales.Add(Convert.ToInt32(row["Toplam Satış Miktarı"]));  // Gerçek satış miktarı
            }

            // 1. Regresyon katsayılarını hesapla
            var (a, b) = CalculateRegression(periods, actualSales);

            // 2. Satış tahminlerini yap
            List<double> predictedSales = PredictSales(periods, a, b);

            // 3. Mevsimsel indeksleri hesapla
            List<double> seasonalIndices = CalculateSeasonalIndices(actualSales, predictedSales);

            // 4. Ortalama mevsimsel indeksini hesapla
            double averageSeasonalIndex = seasonalIndices.Average();

            // 5. Satışları mevsimsel düzeltme indeksine göre düzelt
            List<double> adjustedSales = AdjustSales(predictedSales, averageSeasonalIndex);

            // Tahmin sonuçlarını ekranda göster
            string result = "Tahmin Sonuçları:\n";
            for (int i = 0; i < predictedSales.Count; i++)
            {
                result += $"Periyot {periods[i]}: " + $"Düzeltilmiş Tahmin: {adjustedSales[i]:F2}\n";                          
                          //$"Tahmin: {predictedSales[i]:F2}, " +
                          //$"Mevsimsel İndeks: {seasonalIndices[i]:F2}%, " +
            }

            MessageBox.Show(result, "Tahmin Sonuçları", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
