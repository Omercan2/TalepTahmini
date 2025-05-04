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
    public partial class StokGuncelleForm : Form
    {
        public StokGuncelleForm()
        {
            InitializeComponent();
        }

        int eskiMiktar = 0;
        private void BtnStoguGuncelle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(tbxMiktar.Text, out int yeniMiktar))
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
            DateTime guncellemeTarihi = dtpTarih.Value;

            string connectionString = MainForm.sqlBaglanti; // Veritabanı bağlantısı

            string query = @"
                UPDATE Stok SET Miktar = @Miktar, BirimFiyat = @BirimFiyat
                OUTPUT inserted.StokID WHERE UrunAdi = @UrunAdi";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        command.Parameters.AddWithValue("@Miktar", yeniMiktar);
                        command.Parameters.AddWithValue("@BirimFiyat", fiyat);

                        object stokIdObj = command.ExecuteScalar();

                        if (stokIdObj != null)
                        {
                            int stokID = Convert.ToInt32(stokIdObj);
                            int miktarDegisimi=yeniMiktar-eskiMiktar;
                            KaydetStokGuncelleme(stokID, miktarDegisimi, guncellemeTarihi);
                            MessageBox.Show("Ürün başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void KaydetStokGuncelleme(int stokID, int miktarDegisimi, DateTime guncellemeTarihi)
        {
            string connectionString = MainForm.sqlBaglanti;
            string query = "INSERT INTO StokGuncellemeleri (StokID, MiktarDegisimi, GuncellemeTarihi) VALUES (@StokID, @MiktarDegisimi, @GuncellemeTarihi)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StokID", stokID);
                        command.Parameters.AddWithValue("@MiktarDegisimi", miktarDegisimi);
                        command.Parameters.AddWithValue("@GuncellemeTarihi", guncellemeTarihi);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stok güncelleme kaydı eklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StokGuncelleForm_Load(object sender, EventArgs e)
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
                                tbxMiktar.Text = reader["Miktar"].ToString();
                                eskiMiktar = Convert.ToInt32( tbxMiktar.Text);
                                tbxFiyat.Text = reader["BirimFiyat"].ToString();
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
    }
}
