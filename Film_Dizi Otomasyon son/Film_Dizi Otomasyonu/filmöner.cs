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

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Film_Dizi_Otomasyonu
{

    public partial class filmöner : Form
    {

        public Film_öner nesne;
        public static int UserID;
        public VeriTabanı baglantı = new VeriTabanı();
        SqlConnection Conn = VeriTabanı.connection;
        FilmSayfasi filmSayfasi = new FilmSayfasi();
        SqlCommand kos;
        public filmöner()
        {
            InitializeComponent();
        }


        private void filmöner_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int rnd_deger;
            pictureBox1.ImageLocation= "C:\\Users\\hasan can\\Downloads\\image-loading-icon-6.jpg";
            flyweight nsn1 = new flyweight();
            string[] genre = { "War", "Western", "Horror", "Action", "Thriller", "Romance", "Comedy", "Drama", "Sci-Fi", 
                "Family", "Animation", "Sport", "Film-Noir", "Musical", "Adventure", 
                "Biograhpy", "Crime", "Mystery", "History", "Fantasy" };
            int büyük = -1;
            int count = 0;
            int indis = 0;
            foreach (var item in genre)
            {
                int temp = nsn1.flyweight_method(item);
                if (temp > büyük)
                {
                    büyük = temp;
                    indis = count;
                    count++;
                }
                else
                {
                    count++;
                }
            }
            string onerilecek_genre = genre[indis];
            Conn.Open();
            kos = new SqlCommand($"SELECT TOP 1 * FROM filmler Where Genre Like '%{onerilecek_genre}%' ORDER BY NEWID()", Conn);
            SqlDataReader reader = kos.ExecuteReader();
            while (reader.Read())
            {
                
                pictureBox1.ImageLocation = reader["Poster_Link"].ToString();
                label1.Text = "";
                label1.Text = reader["Series_Title"].ToString();
                FilmSayfasi.adi = reader["Series_Title"].ToString();
                FilmSayfasi.year = Int32.Parse(reader["Released_Year"].ToString());
                FilmSayfasi.dakika = Int32.Parse(reader["Runtime"].ToString().Split(" ")[0]);
                FilmSayfasi.genre = reader["Genre"].ToString();
                FilmSayfasi.imdb = float.Parse(reader["IMDB_Rating"].ToString());
                FilmSayfasi.director = reader["Director"].ToString();
                FilmSayfasi.star1 = reader["Star1"].ToString();
                FilmSayfasi.star2 = reader["Star2"].ToString();
                FilmSayfasi.star3 = reader["Star3"].ToString();
                FilmSayfasi.star4 = reader["Star4"].ToString();
            }
            Conn.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filmSayfasi.nesne = this;
            filmSayfasi.Show();
            this.Hide();
        }

        private void filmöner_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            nesne.Show();
        }
    }
    public class flyweight
    {
        public static int UserID;
        public int flyweight_method(string genre)
        {
            string sql = $"SELECT count(*) FROM liste Where  username_id={UserID} and Genre Like '%{genre}%'";
            SqlConnection con = VeriTabanı.connection;
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            int sayi = (int)com.ExecuteScalar();
            con.Close();
            return sayi;


        }
    }
}
