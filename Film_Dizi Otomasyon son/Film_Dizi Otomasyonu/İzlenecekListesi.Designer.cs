namespace Film_Dizi_Otomasyonu
{
    partial class İzlenecekListesi
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
            this.izlenecekList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // izlenecekList
            // 
            this.izlenecekList.ItemHeight = 25;
            this.izlenecekList.Location = new System.Drawing.Point(12, 12);
            this.izlenecekList.Name = "izlenecekList";
            this.izlenecekList.Size = new System.Drawing.Size(467, 354);
            this.izlenecekList.TabIndex = 0;
            this.izlenecekList.DoubleClick += new System.EventHandler(this.izlenecekList_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 66);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // İzlenecekListesi
            // 
            this.ClientSize = new System.Drawing.Size(656, 385);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.izlenecekList);
            this.Name = "İzlenecekListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İzlenecekler Listem";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.İzlenecekListesi_FormClosed);
            this.Load += new System.EventHandler(this.İzlenecekListesi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox izlenecekList;
        private Button button1;
    }
}