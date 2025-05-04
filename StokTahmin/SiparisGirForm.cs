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
    public partial class SiparisGirForm : Form
    {
        public SiparisGirForm()
        {
            InitializeComponent();
        }
        int eskiMiktar = 0;
       
        private void BtnSiparis_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbxMiktar.Text, out int siparisMiktari))
            {
                MessageBox.Show("Lütfen miktar alanına sadece tam sayı girin!", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tbxFiyat.Text, out decimal fiyat))
            {
                MessageBox.Show("Lütfen fiyat alanına sadece sayısal bir değer girin!", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string urunAdi = CboxUrunAdı.Text;
            
            DateTime siparisTarihi = dtpTarih.Value;

            if (siparisMiktari <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir sipariş miktarı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (siparisMiktari > eskiMiktar)
            {
                MessageBox.Show("Sipariş miktarı stoktan fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string baglantiDizesi = MainForm.sqlBaglanti;

            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglantiDizesi))
                {
                    baglanti.Open();
                    string stokGuncelleQuery = "UPDATE Stok SET Miktar = Miktar - @SiparisMiktari OUTPUT inserted.StokID WHERE UrunAdi = @UrunAdi";

                    using (SqlCommand stokKomut = new SqlCommand(stokGuncelleQuery, baglanti))
                    {
                        stokKomut.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        stokKomut.Parameters.AddWithValue("@SiparisMiktari", siparisMiktari);

                        object stokIdObj = stokKomut.ExecuteScalar();

                        if (stokIdObj != null)
                        {
                            int stokID = Convert.ToInt32(stokIdObj);
                            string siparisEkleQuery = "INSERT INTO Siparisler (MusteriID, SiparisTarihi) OUTPUT INSERTED.SiparisID VALUES (@MusteriID, @SiparisTarihi)";

                            using (SqlCommand siparisKomut = new SqlCommand(siparisEkleQuery, baglanti))
                            {
                                siparisKomut.Parameters.AddWithValue("@MusteriID", 1); // simdilik musteri kismini yapmadigim icin 1 verdim
                                siparisKomut.Parameters.AddWithValue("@SiparisTarihi", siparisTarihi); 
                                object siparisIdObj = siparisKomut.ExecuteScalar();

                                if (siparisIdObj != null)
                                {
                                    int siparisID = Convert.ToInt32(siparisIdObj);
                                    string detayEkleQuery = "INSERT INTO SiparisDetaylari (SiparisID, StokID, Miktar) VALUES (@SiparisID, @StokID, @Miktar)";

                                    using (SqlCommand detayKomut = new SqlCommand(detayEkleQuery, baglanti))
                                    {
                                        detayKomut.Parameters.AddWithValue("@SiparisID", siparisID);
                                        detayKomut.Parameters.AddWithValue("@StokID", stokID);
                                        detayKomut.Parameters.AddWithValue("@Miktar", siparisMiktari);
                                        detayKomut.ExecuteNonQuery();
                                    }
                                }
                            }
                            MessageBox.Show("Sipariş başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblStokToplam.Text = "Stoktaki Miktar: " + (eskiMiktar - siparisMiktari).ToString();
                            eskiMiktar -= siparisMiktari;
                        }
                        else
                        {
                            MessageBox.Show("Ürün bulunamadı veya güncelleme başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboxUrunAdı_SelectedIndexChanged(object sender, EventArgs e)
        {
            string urunAdi = CboxUrunAdı.Text;
            string connectionString = MainForm.sqlBaglanti;
            string query = "SELECT Miktar, BirimFiyat FROM Stok WHERE UrunAdi = @UrunAdi";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (Convert.ToInt32(reader["Miktar"]) <= 0)
                                {
                                    MessageBox.Show("Bu ürünü sipariş edemezsiniz");
                                    return;
                                }
                                else
                                {
                                    lblStokToplam.Text = "Stoktaki Miktar: " + reader["Miktar"].ToString();
                                    eskiMiktar = Convert.ToInt32(reader["Miktar"]);
                                    tbxFiyat.Text = reader["BirimFiyat"].ToString();
                                    tbxFiyat.Enabled = false;
                                }
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün bilgileri alınırken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SiparisGirForm_Load(object sender, EventArgs e)
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
    }
}
