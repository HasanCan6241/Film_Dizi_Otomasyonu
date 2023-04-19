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
using System.Data.SqlClient;

namespace Film_Dizi_Otomasyonu
{
    public partial class ModArama : Form
    {
        SqlConnection connection = VeriTabanı.connection;
        SqlDataAdapter kos;
        public Film_öner nesne;
        public ModArama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            flyweight_2_method("War");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Western");

        }

        private void button3_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Horror");

        }
        private void button4_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Action");

        }
        private void button5_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Thriller");

        }

        private void button6_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Romance");

        }

        private void button7_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Comedy");

        }

        private void button8_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Drama");

        }

        private void button9_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Sci-Fi");

        }

        private void button10_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Family");

        }

        private void button11_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Animation");

        }

        private void button12_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Sport");

        }

        private void button13_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Film-Noir");

        }

        private void button14_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Musical");

        }

        private void button15_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Adventure");

        }

        private void button16_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Crime");

        }

        private void button17_Click(object sender, EventArgs e)
        {

            flyweight_2_method("Mystery");

        }

        private void button18_Click(object sender, EventArgs e)
        {
            flyweight_2_method("History");


        }

        private void ModArama_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            button19.Visible = false;
        }

        private void ModArama_FormClosed(object sender, FormClosedEventArgs e)
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
    
        public void flyweight_2_method(string genre)
        {

            kos = new SqlDataAdapter($"" +
                $"SELECT TOP 1 Series_Title,Released_Year,Certificate,Runtime,Genre,IMDB_Rating,Overview,Meta_score,Director,Star1,Star2,Star3,star4,No_of_Votes,Gross " +
                $"FROM filmler Where Genre " +
                $"Like '%{genre}%' ORDER BY NEWID()", connection);
            DataTable tablo = new DataTable();
            kos.Fill(tablo);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = tablo;
            button19.Visible = true;
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow;
            try
            {

                selectedRow = dataGridView1.SelectedRows[0];

            }
            catch { return; }
            FilmSayfasiniAc(selectedRow);
        }
    }
}
