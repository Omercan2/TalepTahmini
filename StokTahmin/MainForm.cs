namespace StokTahmin
{
    public partial class MainForm : Form
    {
        public static string sqlBaglanti = "Data Source=OMER;Initial Catalog=SiparisYonetim;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnSiparisGir_Click(object sender, EventArgs e)
        {
            SiparisGirForm siparisGirForm = new SiparisGirForm();
            siparisGirForm.ShowDialog();
        }

        private void BtnStokGuncelle_Click(object sender, EventArgs e)
        {
            StokGuncelleForm stokGuncelleForm = new StokGuncelleForm();
            stokGuncelleForm.ShowDialog();
        }

        private void BtnYeniUrun_Click(object sender, EventArgs e)
        {
            YeniUrunForm yeniUrunForm = new YeniUrunForm();
            yeniUrunForm.ShowDialog();
        }

        private void BtnTedarikTahmini_Click(object sender, EventArgs e)
        {
            TedarikTahminiForm tedarikTahminiForm = new TedarikTahminiForm();
            tedarikTahminiForm.ShowDialog();
        }
    }
}
