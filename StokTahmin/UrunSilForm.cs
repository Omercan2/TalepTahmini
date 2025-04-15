using Microsoft.Data.SqlClient;
using StokTahmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalepTahmin
{
    public partial class UrunSilForm : Form
    {
        public UrunSilForm()
        {
            InitializeComponent();
        }

        private void UrunSilForm_Load(object sender, EventArgs e)
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
                                tbxFiyat.Text = reader["BirimFiyat"].ToString();
                                tbxFiyat.Enabled = false;
                                tbxMiktar.Enabled = false;

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

        private void BtnUrunSil_Click(object sender, EventArgs e)
        {
            string secilenUrunAdi = CboxUrunAdı.Text;

            if (string.IsNullOrWhiteSpace(secilenUrunAdi))
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"'{secilenUrunAdi}' adlı ürünü silmek istediğinize emin misiniz?\nİlişkili tüm veriler (sipariş detayları, stok güncellemeleri) silinecektir.",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                string connectionString = MainForm.sqlBaglanti;

                string deleteQuery = "DELETE FROM Stok WHERE UrunAdi = @UrunAdi";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@UrunAdi", secilenUrunAdi);
                            int affectedRows = command.ExecuteNonQuery();

                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Ürün ve ilişkili veriler başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Formu temizle
                                CboxUrunAdı.Items.Remove(secilenUrunAdi);
                                CboxUrunAdı.Text = "";
                                tbxMiktar.Clear();
                                tbxFiyat.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Ürün silinirken bir sorun oluştu. Ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
