using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_Dizi_Otomasyonu
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        internal static int userID;
        public Giriş nesne_giris;
        SqlConnection baglanti = VeriTabanı.connection;
        void lıstele()
        {
            SqlDataAdapter adtr = new SqlDataAdapter("select Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross from filmler", baglanti);
            DataSet tablo = new DataSet();
            adtr.Fill(tablo, "filmler");
            dataGridView1.DataSource = tablo.Tables["filmler"];
            adtr.Dispose();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Filmi Ekleme", "Filmi Eklemek İstediğinize Emin misiniz?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into filmler(Poster_Link,Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,Star4,No_of_Votes,Gross) values(@Poster_Link,@Series_Title,@Released_Year,@Certificate,@Runtime,@Genre,@IMDB_Rating,@Overview,@Meta_score,@Director,@Star1,@Star2,@Star3,@Star4,@No_of_Votes,@Gross)", baglanti);
                komut.Parameters.AddWithValue("@Series_Title", textBox1.Text);
                komut.Parameters.AddWithValue("@Overview", textBox2.Text);
                komut.Parameters.AddWithValue("@IMDB_Rating", Convert.ToDecimal(textBox3.Text));
                komut.Parameters.AddWithValue("@Star1", textBox4.Text);
                komut.Parameters.AddWithValue("@Star2", textBox7.Text);
                komut.Parameters.AddWithValue("@Star3", textBox8.Text);
                komut.Parameters.AddWithValue("@Star4", textBox9.Text);
                komut.Parameters.AddWithValue("@Director", textBox5.Text);
                komut.Parameters.AddWithValue("@Released_Year", textBox6.Text);


                komut.Parameters.AddWithValue("@Poster_Link", textBox10.Text);
                komut.Parameters.AddWithValue("@Certificate", textBox10.Text);
                komut.Parameters.AddWithValue("@Runtime", Convert.ToDecimal(textBox10.Text));
                komut.Parameters.AddWithValue("@Genre", textBox10.Text);
                komut.Parameters.AddWithValue("@Meta_score", Convert.ToDecimal(textBox10.Text));
                komut.Parameters.AddWithValue("@No_of_Votes", Convert.ToDecimal(textBox10.Text));
                komut.Parameters.AddWithValue("@Gross", Convert.ToDecimal(textBox10.Text));
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklendi");
                lıstele();
                baglanti.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox1.Focus();



            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox1.Focus();
                MessageBox.Show("İşlem İptal Edildi");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lıstele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Filmi Çıkarma", "Filmi Çıkarmak İstediğinize Emin misiniz?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("delete from filmler where Series_Title='" + dataGridView1.SelectedRows[i].Cells["Series_Title"].Value.ToString() + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                }
                MessageBox.Show("Kayıt Silindi");
                lıstele();
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi");

            }
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            nesne_giris.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 nsn1 = new Form1();
            nsn1.Admin_Giris = this;
            nsn1.Show();
            this.Hide();

        }
    }
}
