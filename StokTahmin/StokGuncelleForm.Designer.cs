namespace StokTahmin
{
    partial class StokGuncelleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CboxUrunAdı = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            tbxMiktar = new TextBox();
            tbxFiyat = new TextBox();
            label3 = new Label();
            BtnStoguGuncelle = new Button();
            label4 = new Label();
            dtpTarih = new DateTimePicker();
            SuspendLayout();
            // 
            // CboxUrunAdı
            // 
            CboxUrunAdı.FormattingEnabled = true;
            CboxUrunAdı.Location = new Point(140, 59);
            CboxUrunAdı.Name = "CboxUrunAdı";
            CboxUrunAdı.Size = new Size(151, 28);
            CboxUrunAdı.TabIndex = 0;
            CboxUrunAdı.SelectedIndexChanged += CboxUrunAdı_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 63);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Ürün Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 113);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 2;
            label2.Text = "Miktar";
            // 
            // tbxMiktar
            // 
            tbxMiktar.Location = new Point(140, 110);
            tbxMiktar.Name = "tbxMiktar";
            tbxMiktar.Size = new Size(151, 27);
            tbxMiktar.TabIndex = 3;
            // 
            // tbxFiyat
            // 
            tbxFiyat.Location = new Point(140, 154);
            tbxFiyat.Name = "tbxFiyat";
            tbxFiyat.Size = new Size(151, 27);
            tbxFiyat.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 157);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 4;
            label3.Text = "Fiyat";
            // 
            // BtnStoguGuncelle
            // 
            BtnStoguGuncelle.Location = new Point(512, 257);
            BtnStoguGuncelle.Name = "BtnStoguGuncelle";
            BtnStoguGuncelle.Size = new Size(141, 42);
            BtnStoguGuncelle.TabIndex = 8;
            BtnStoguGuncelle.Text = "Stoğu Güncelle";
            BtnStoguGuncelle.UseVisualStyleBackColor = true;
            BtnStoguGuncelle.Click += BtnStoguGuncelle_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 203);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 9;
            label4.Text = "Tarih";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(140, 203);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(250, 27);
            dtpTarih.TabIndex = 10;
            // 
            // StokGuncelleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpTarih);
            Controls.Add(label4);
            Controls.Add(BtnStoguGuncelle);
            Controls.Add(tbxFiyat);
            Controls.Add(label3);
            Controls.Add(tbxMiktar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CboxUrunAdı);
            Name = "StokGuncelleForm";
            Text = "StokGuncelleForm";
            Load += StokGuncelleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CboxUrunAdı;
        private Label label1;
        private Label label2;
        private TextBox tbxMiktar;
        private TextBox tbxFiyat;
        private Label label3;
        private Button BtnStoguGuncelle;
        private Label label4;
        private DateTimePicker dtpTarih;
    }
}