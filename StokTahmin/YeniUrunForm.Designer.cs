namespace StokTahmin
{
    partial class YeniUrunForm
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
            BtnYeniUrun = new Button();
            tbxFiyat = new TextBox();
            label3 = new Label();
            tbxMiktar = new TextBox();
            label2 = new Label();
            label1 = new Label();
            TbxUrunAdi = new TextBox();
            SuspendLayout();
            // 
            // BtnYeniUrun
            // 
            BtnYeniUrun.Location = new Point(494, 241);
            BtnYeniUrun.Name = "BtnYeniUrun";
            BtnYeniUrun.Size = new Size(141, 42);
            BtnYeniUrun.TabIndex = 15;
            BtnYeniUrun.Text = "Yeni Ürün Ekle";
            BtnYeniUrun.UseVisualStyleBackColor = true;
            BtnYeniUrun.Click += BtnYeniUrun_Click;
            // 
            // tbxFiyat
            // 
            tbxFiyat.Location = new Point(169, 169);
            tbxFiyat.Name = "tbxFiyat";
            tbxFiyat.Size = new Size(151, 27);
            tbxFiyat.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 172);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 13;
            label3.Text = "Fiyat";
            // 
            // tbxMiktar
            // 
            tbxMiktar.Location = new Point(169, 125);
            tbxMiktar.Name = "tbxMiktar";
            tbxMiktar.Size = new Size(151, 27);
            tbxMiktar.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 128);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 11;
            label2.Text = "Miktar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 78);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 10;
            label1.Text = "Ürün Adı";
            // 
            // TbxUrunAdi
            // 
            TbxUrunAdi.Location = new Point(169, 78);
            TbxUrunAdi.Name = "TbxUrunAdi";
            TbxUrunAdi.Size = new Size(151, 27);
            TbxUrunAdi.TabIndex = 16;
            // 
            // YeniUrunForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TbxUrunAdi);
            Controls.Add(BtnYeniUrun);
            Controls.Add(tbxFiyat);
            Controls.Add(label3);
            Controls.Add(tbxMiktar);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "YeniUrunForm";
            Text = "YeniUrunForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnYeniUrun;
        private TextBox tbxFiyat;
        private Label label3;
        private TextBox tbxMiktar;
        private Label label2;
        private Label label1;
        private TextBox TbxUrunAdi;
    }
}