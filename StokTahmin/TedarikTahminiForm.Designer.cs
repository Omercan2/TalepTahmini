namespace StokTahmin
{
    partial class TedarikTahminiForm
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
            dtgSiparis = new DataGridView();
            label1 = new Label();
            CboxUrunAdı = new ComboBox();
            BtnTahminEt = new Button();
            label2 = new Label();
            lblSatisSayisi = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgSiparis).BeginInit();
            SuspendLayout();
            // 
            // dtgSiparis
            // 
            dtgSiparis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgSiparis.Location = new Point(131, 250);
            dtgSiparis.Name = "dtgSiparis";
            dtgSiparis.RowHeadersWidth = 51;
            dtgSiparis.Size = new Size(465, 188);
            dtgSiparis.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 53);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 3;
            label1.Text = "Ürün Adı";
            // 
            // CboxUrunAdı
            // 
            CboxUrunAdı.FormattingEnabled = true;
            CboxUrunAdı.Location = new Point(131, 49);
            CboxUrunAdı.Name = "CboxUrunAdı";
            CboxUrunAdı.Size = new Size(151, 28);
            CboxUrunAdı.TabIndex = 2;
            CboxUrunAdı.SelectedIndexChanged += CboxUrunAdı_SelectedIndexChanged;
            // 
            // BtnTahminEt
            // 
            BtnTahminEt.Location = new Point(528, 121);
            BtnTahminEt.Name = "BtnTahminEt";
            BtnTahminEt.Size = new Size(121, 62);
            BtnTahminEt.TabIndex = 4;
            BtnTahminEt.Text = "Stok Tahmini Yap";
            BtnTahminEt.UseVisualStyleBackColor = true;
            BtnTahminEt.Click += BtnTahminEt_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 218);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Siparişler";
            // 
            // lblSatisSayisi
            // 
            lblSatisSayisi.AutoSize = true;
            lblSatisSayisi.Location = new Point(22, 142);
            lblSatisSayisi.Name = "lblSatisSayisi";
            lblSatisSayisi.Size = new Size(287, 20);
            lblSatisSayisi.TabIndex = 7;
            lblSatisSayisi.Text = "2024 Yılındaki Toplam Satılan Ürün Sayısı: ";
            // 
            // TedarikTahminiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSatisSayisi);
            Controls.Add(label2);
            Controls.Add(BtnTahminEt);
            Controls.Add(label1);
            Controls.Add(CboxUrunAdı);
            Controls.Add(dtgSiparis);
            Name = "TedarikTahminiForm";
            Text = "TedarikTahminiForm";
            Load += TedarikTahminiForm_Load;
            ((System.ComponentModel.ISupportInitialize)dtgSiparis).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgSiparis;
        private Label label1;
        private ComboBox CboxUrunAdı;
        private Button BtnTahminEt;
        private Label label2;
        private Label lblTedarik;
        private Label lblSatisSayisi;
    }
}