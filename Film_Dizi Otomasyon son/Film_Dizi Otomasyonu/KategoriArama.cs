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
    public partial class KategoriArama : Form
    {
        SqlConnection connection = VeriTabanı.connection;
        SqlDataAdapter kos;
        public Form1 nesne;

        public KategoriArama()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KategoriArama_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flyweight3("War");
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            flyweight3("Western");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            flyweight3("Horror");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            flyweight3("Action");

        }
        public void button5_Click(object sender, EventArgs e)
        {

           
            flyweight3("Thriller");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            flyweight3("Romance");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            flyweight3("Comedy");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            flyweight3("Drama");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            flyweight3("Sci-Fi");

        }

        private void button10_Click(object sender, EventArgs e)
        {
           
            flyweight3("Family");

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            flyweight3("Animation");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            flyweight3("Sport");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            flyweight3("Film-Noir");

        }
        private void button14_Click(object sender, EventArgs e)
        {
            
            flyweight3("Musical");


        }
        private void button15_Click(object sender, EventArgs e)
        {
           
            flyweight3("Adventure");

        }

        private void button16_Click(object sender, EventArgs e)
        {
           
            flyweight3("Biography");

        }

        private void button17_Click(object sender, EventArgs e)
        {
            
            flyweight3("Crime");

        }

        private void button18_Click(object sender, EventArgs e)
        {
          
            flyweight3("Mystery");

        }

        private void button19_Click(object sender, EventArgs e)
        {
            flyweight3("History");

        }
        private void button20_Click(object sender, EventArgs e)
        {
            
            flyweight3("Fantasy");

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button21.Visible = false;
        }

        private void KategoriArama_FormClosed(object sender, FormClosedEventArgs e)
        {
            nesne.Show();

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
    public void flyweight3(string genre)
        {
            kos = new SqlDataAdapter($"SELECT Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1," +
                $"Star2,Star3,star4,No_of_Votes,Gross FROM filmler Where Genre " +
                $"Like '%{genre}%' order by (Released_Year) DESC", connection);
            DataTable tablo = new DataTable();
            kos.Fill(tablo);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = tablo;
            button21.Visible = true;
        }
    }
}
