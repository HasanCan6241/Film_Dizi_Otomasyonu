using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Film_Dizi_Otomasyonu
{
    public partial class Film_Görüntüle : Form
    {
        public Form1 nesne;
        public Film_Görüntüle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = VeriTabanı.connection;
        DataSet tablo = new DataSet();

        void lıstele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross from filmler", baglanti);
            adtr.Fill(tablo, "filmler");
            dataGridView1.DataSource = tablo.Tables["filmler"];
            adtr.Dispose();
            baglanti.Close();

        }
        void top250()
        {

            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select top 250 Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross from filmler order by IMDB_Rating desc", baglanti);
            adtr.Fill(tablo, "filmler");
            dataGridView1.DataSource = tablo.Tables["filmler"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            top250();
        }

        private void Film_Görüntüle_Load(object sender, EventArgs e)
        {
            lıstele();
        }
        void yonetmen()
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross from filmler where Director like'%" + textBox2.Text + "%' and Released_Year like'%" + textBox3.Text + "%' and Series_Title like'%" + textBox4.Text + "%'and (Star1 LIKE '%" + textBox1.Text + "%' or Star2 LIKE '%" + textBox1.Text + "%' or Star3 LIKE '%" + textBox1.Text + "%'or Star4 LIKE '%" + textBox1.Text + "%')", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            yonetmen();
        }
        void yıllar()
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr2 = new SqlDataAdapter("Select Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross from filmler where Released_Year like'%" + textBox3.Text + "%' and Series_Title like'%" + textBox4.Text + "%'and (Star1 LIKE '%" + textBox1.Text + "%' or Star2 LIKE '%" + textBox1.Text + "%' or Star3 LIKE '%" + textBox1.Text + "%'or Star4 LIKE '%" + textBox1.Text + "%') and Director like'%" + textBox2.Text + "%'", baglanti);
            adtr2.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            yıllar();
        }
        void Oyuncu()
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr3 = new SqlDataAdapter("SELECT Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross FROM filmler WHERE (Star1 LIKE '%" + textBox1.Text + "%' or Star2 LIKE '%" + textBox1.Text + "%' or Star3 LIKE '%" + textBox1.Text + "%' or Star4 LIKE '%" + textBox1.Text + "%') and Released_Year like'%" + textBox3.Text + "%'and Series_Title like'%" + textBox4.Text + "%'and Director like'%" + textBox2.Text + "%'", baglanti);
            adtr3.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Oyuncu();
        }

        void fılm_ara()
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr4 = new SqlDataAdapter("Select Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross from filmler where Series_Title like'%" + textBox4.Text + "%' and Released_Year like'%" + textBox3.Text + "%'and (Star1 LIKE '%" + textBox1.Text + "%' or Star2 LIKE '%" + textBox1.Text + "%' or Star3 LIKE '%" + textBox1.Text + "%' or Star4 LIKE '%" + textBox1.Text + "%') and Director like'%" + textBox2.Text + "%'", baglanti);
            adtr4.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            fılm_ara();
        }

        private void FilmSayfasiniAc(DataGridViewRow selectedRow)
        {

            FilmSayfasi filmSayfasi = new FilmSayfasi();
            FilmSayfasi.adi = selectedRow.Cells[0].Value.ToString();
            FilmSayfasi.year = Int32.Parse(selectedRow.Cells[1].Value.ToString());
            FilmSayfasi.dakika = Int32.Parse(selectedRow.Cells[3].Value.ToString().Split(" ")[0]);
            FilmSayfasi.genre = selectedRow.Cells[4].Value.ToString();
            FilmSayfasi.imdb = float.Parse(selectedRow.Cells[5].Value.ToString());
            FilmSayfasi.director = selectedRow.Cells[8].Value.ToString();
            FilmSayfasi.star1 = selectedRow.Cells[9].Value.ToString();
            FilmSayfasi.star2 = selectedRow.Cells[10].Value.ToString();
            FilmSayfasi.star3 = selectedRow.Cells[11].Value.ToString();
            FilmSayfasi.star4 = selectedRow.Cells[12].Value.ToString();


            filmSayfasi.Show();
        }





        private void Film_Görüntüle_FormClosed(object sender, FormClosedEventArgs e)
        {
            nesne.Show();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {

                selectedRow = dataGridView1.SelectedRows[0];

            }
            catch { return; }
            FilmSayfasiniAc(selectedRow);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*      private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
              {
                  DataGridViewRow selectedRow;
                  selectedRow = dataGridView1.Rows[e.RowIndex];
                  FilmSayfasiniAc(selectedRow);
              }*/
    }
}
