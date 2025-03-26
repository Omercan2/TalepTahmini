namespace StokTahmin
{
    partial class SiparisGirForm
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
            BtnSiparis = new Button();
            dtpTarih = new DateTimePicker();
            label4 = new Label();
            tbxFiyat = new TextBox();
            label3 = new Label();
            tbxMiktar = new TextBox();
            label2 = new Label();
            label1 = new Label();
            CboxUrunAdı = new ComboBox();
            lblStokToplam = new Label();
            SuspendLayout();
            // 
            // BtnSiparis
            // 
            BtnSiparis.Location = new Point(529, 223);
            BtnSiparis.Name = "BtnSiparis";
            BtnSiparis.Size = new Size(94, 29);
            BtnSiparis.TabIndex = 1;
            BtnSiparis.Text = "Sipariş Gir";
            BtnSiparis.UseVisualStyleBackColor = true;
            BtnSiparis.Click += BtnSiparis_Click;
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(160, 204);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(250, 27);
            dtpTarih.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 204);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 17;
            label4.Text = "Tarih";
            // 
            // tbxFiyat
            // 
            tbxFiyat.Location = new Point(160, 155);
            tbxFiyat.Name = "tbxFiyat";
            tbxFiyat.Size = new Size(151, 27);
            tbxFiyat.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 158);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 15;
            label3.Text = "Fiyat";
            // 
            // tbxMiktar
            // 
            tbxMiktar.Location = new Point(160, 111);
            tbxMiktar.Name = "tbxMiktar";
            tbxMiktar.Size = new Size(151, 27);
            tbxMiktar.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 114);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 13;
            label2.Text = "Miktar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 64);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 12;
            label1.Text = "Ürün Adı";
            // 
            // CboxUrunAdı
            // 
            CboxUrunAdı.FormattingEnabled = true;
            CboxUrunAdı.Location = new Point(160, 60);
            CboxUrunAdı.Name = "CboxUrunAdı";
            CboxUrunAdı.Size = new Size(151, 28);
            CboxUrunAdı.TabIndex = 11;
            CboxUrunAdı.SelectedIndexChanged += CboxUrunAdı_SelectedIndexChanged;
            // 
            // lblStokToplam
            // 
            lblStokToplam.AutoSize = true;
            lblStokToplam.Location = new Point(333, 114);
            lblStokToplam.Name = "lblStokToplam";
            lblStokToplam.Size = new Size(115, 20);
            lblStokToplam.TabIndex = 19;
            lblStokToplam.Text = "Stoktaki Miktar: ";
            // 
            // SiparisGirForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStokToplam);
            Controls.Add(dtpTarih);
            Controls.Add(label4);
            Controls.Add(tbxFiyat);
            Controls.Add(label3);
            Controls.Add(tbxMiktar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CboxUrunAdı);
            Controls.Add(BtnSiparis);
            Name = "SiparisGirForm";
            Text = "SiparisGirForm";
            Load += SiparisGirForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button BtnSiparis;
        private DateTimePicker dtpTarih;
        private Label label4;
        private TextBox tbxFiyat;
        private Label label3;
        private TextBox tbxMiktar;
        private Label label2;
        private Label label1;
        private ComboBox CboxUrunAdı;
        private Label lblStokToplam;
    }
}