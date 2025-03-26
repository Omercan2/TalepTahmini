using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace StokTahmin
{
    public partial class YeniUrunForm : Form
    {
        public YeniUrunForm()
        {
            InitializeComponent();
        }

        private void BtnYeniUrun_Click(object sender, EventArgs e)
        {
            string urunAdi=TbxUrunAdi.Text;
            int miktar = Convert.ToInt32( tbxMiktar.Text);
            decimal fiyat =Convert.ToDecimal( tbxFiyat.Text);

            // Veritabanı bağlantı dizesini MainForm.sqlBaglanti'dan alıyoruz
            string connectionString = MainForm.sqlBaglanti;

            // SQL sorgusu
            string query = "INSERT INTO Stok (UrunAdi, Miktar, BirimFiyat) VALUES (@UrunAdi, @Miktar, @BirimFiyat)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // Komutu oluştur
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                        command.Parameters.AddWithValue("@Miktar", miktar);
                        command.Parameters.AddWithValue("@BirimFiyat", fiyat);

                        // Komutu çalıştır ve etkilenen satır sayısını al
                        int rowsAffected = command.ExecuteNonQuery();

                        // Eğer veri başarıyla eklenmişse
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Veri başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Veri eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
