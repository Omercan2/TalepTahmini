namespace StokTahmin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnSiparisGir = new Button();
            BtnStokGuncelle = new Button();
            BtnTedarikTahmini = new Button();
            BtnYeniUrun = new Button();
            BtnUrunSil = new Button();
            SuspendLayout();
            // 
            // BtnSiparisGir
            // 
            BtnSiparisGir.Location = new Point(306, 37);
            BtnSiparisGir.Name = "BtnSiparisGir";
            BtnSiparisGir.Size = new Size(164, 54);
            BtnSiparisGir.TabIndex = 0;
            BtnSiparisGir.Text = "Sipariş Gir";
            BtnSiparisGir.UseVisualStyleBackColor = true;
            BtnSiparisGir.Click += BtnSiparisGir_Click;
            // 
            // BtnStokGuncelle
            // 
            BtnStokGuncelle.Location = new Point(306, 172);
            BtnStokGuncelle.Name = "BtnStokGuncelle";
            BtnStokGuncelle.Size = new Size(164, 69);
            BtnStokGuncelle.TabIndex = 1;
            BtnStokGuncelle.Text = "Stok Güncelle";
            BtnStokGuncelle.UseVisualStyleBackColor = true;
            BtnStokGuncelle.Click += BtnStokGuncelle_Click;
            // 
            // BtnTedarikTahmini
            // 
            BtnTedarikTahmini.Location = new Point(306, 97);
            BtnTedarikTahmini.Name = "BtnTedarikTahmini";
            BtnTedarikTahmini.Size = new Size(164, 69);
            BtnTedarikTahmini.TabIndex = 3;
            BtnTedarikTahmini.Text = "Geçmiş Siparişlere Göre Tedarik Tahmini Yap";
            BtnTedarikTahmini.UseVisualStyleBackColor = true;
            BtnTedarikTahmini.Click += BtnTedarikTahmini_Click;
            // 
            // BtnYeniUrun
            // 
            BtnYeniUrun.Location = new Point(306, 247);
            BtnYeniUrun.Name = "BtnYeniUrun";
            BtnYeniUrun.Size = new Size(164, 69);
            BtnYeniUrun.TabIndex = 4;
            BtnYeniUrun.Text = "Yeni Ürün Tipi Girisi";
            BtnYeniUrun.UseVisualStyleBackColor = true;
            BtnYeniUrun.Click += BtnYeniUrun_Click;
            // 
            // BtnUrunSil
            // 
            BtnUrunSil.Location = new Point(306, 322);
            BtnUrunSil.Name = "BtnUrunSil";
            BtnUrunSil.Size = new Size(164, 69);
            BtnUrunSil.TabIndex = 5;
            BtnUrunSil.Text = "Ürün Silme";
            BtnUrunSil.UseVisualStyleBackColor = true;
            BtnUrunSil.Click += BtnUrunSil_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnUrunSil);
            Controls.Add(BtnYeniUrun);
            Controls.Add(BtnTedarikTahmini);
            Controls.Add(BtnStokGuncelle);
            Controls.Add(BtnSiparisGir);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnSiparisGir;
        private Button BtnStokGuncelle;
        private Button BtnTedarikTahmini;
        private Button BtnYeniUrun;
        private Button BtnUrunSil;
    }
}
