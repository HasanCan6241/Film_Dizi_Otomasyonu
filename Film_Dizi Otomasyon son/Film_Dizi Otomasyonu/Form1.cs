namespace Film_Dizi_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Giriþ nesne_giris;
        public Admin Admin_Giris;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Admin.userID != 0)
            {
                Admin_Giris.Show();
            }

            else
            {
                nesne_giris.Close();
            }
            }

        private void button6_Click(object sender, EventArgs e)
        {
            Hakkýnda nsn1 = new Hakkýnda();
            nsn1.nesne = this;
            nsn1.Show();
            this.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ÝzlenecekListesi izlenecekListesi_nsn = new ÝzlenecekListesi();
            izlenecekListesi_nsn.nesne = this;
            izlenecekListesi_nsn.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Film_Görüntüle frm = new Film_Görüntüle();
            frm.nesne = this;
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SikayetOlustur sik_nesne = new SikayetOlustur();
            sik_nesne.nesne = this;
            sik_nesne.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Film_öner nsn1 = new Film_öner();
            nsn1.nesne = this;
            nsn1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KategoriArama nsn1 = new KategoriArama();
            nsn1.nesne = this;
            nsn1.Show();
            this.Hide();
        }
    }
}