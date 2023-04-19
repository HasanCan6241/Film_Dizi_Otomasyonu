using System.Data.SqlClient;
using System.Threading;

namespace Film_Dizi_Otomasyonu
{
    public partial class FilmSayfasi : Form
    {
        public FilmSayfasi()
        {
            InitializeComponent();
        }

        SqlConnection connection = VeriTabaný.connection;

        internal static int userID;
        internal static int id;
        internal static string poster_link;
        internal static string adi;
        internal static double year;
        internal static int dakika;
        internal static string genre;
        internal static float imdb;
        internal static string director;
        internal static string star1;
        internal static string star2;
        internal static string star3;
        internal static string star4;
        public filmöner nesne;

        private void FilmSayfasi_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation= "C:\\Users\\hasan can\\Downloads\\image-loading-icon-6.jpg";//loading picture
            GetUserID();
            connection.Open();
            SqlCommand cmd = new SqlCommand($"SELECT id,Poster_Link FROM filmler WHERE Series_Title='{adi.Replace("'", "''")}' AND Released_Year={year} AND Director='{director}'", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = Int32.Parse(reader["id"].ToString());
                poster_link = reader["Poster_Link"].ToString();

            }
            connection.Close();
       
            pictureBox1.Load(poster_link);
            FilmAdiText.Text = adi;
            OyuncularText.Text = star1 + ", " + star2 + "," + star3 + ", " + star4;
            YonetmenText.Text = director;
            FilmTurText.Text = genre;
            BegeniText.Text = imdb.ToString();
            FilmYiliText.Text = year.ToString();
            FilmSuresiText.Text = dakika.ToString() + " dakika";


        }

        private void GetUserID()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand($"SELECT id FROM accounts WHERE username='{Giriþ.Username}'", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                userID = Int32.Parse(reader["id"].ToString());
            }
            else
            {
                userID = -1;
            }

            connection.Close();


        }
        private void ListeyeEkleButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM liste WHERE username_id={userID} AND film_id={id}", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Bu film daha önceden eklenmiþ.");
                connection.Close();
                return;
            }
            connection.Close();
            connection.Open();
            cmd = new SqlCommand($"INSERT INTO liste(username_id,film_id,genre) VALUES({userID},{id},'{genre.ToString()}')", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Baþarýyla eklendi.");
            if (nesne != null)
            {
                nesne.Show();
            }
            this.Close();
        }

        private void BegeniLabel_Click(object sender, EventArgs e)
        {

        }

        private void FilmSayfasi_FormClosed_1(object sender, FormClosedEventArgs e)
        {
              if (nesne != null)
                        {
                            nesne.Show();
                        }

        }

        private void OyuncularLabel_Click(object sender, EventArgs e)
        {

        }

        private void OyuncularText_Click(object sender, EventArgs e)
        {

        }
    }
}