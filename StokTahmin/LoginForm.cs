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
    public partial class LoginForm : Form
    {
        private readonly string dogruEmail = "taleptahmin@gmail.com";
        private readonly string dogruSifre = "Grupno2";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            string girilenEmail = TbxEmail.Text;
            string girilenSifre = TbxSifre.Text;

            if (girilenEmail == dogruEmail && girilenSifre == dogruSifre)
            {
                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                MainForm mainForm = new MainForm(); 
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("E-posta veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
