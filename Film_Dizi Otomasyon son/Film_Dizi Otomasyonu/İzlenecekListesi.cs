using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class İzlenecekListesi : Form
    {
        SqlConnection connection1 = VeriTabanı.connection;
        public Form1 nesne;
        public static int UserID;
        public İzlenecekListesi()
        {
            InitializeComponent();
        }

        private void İzlenecekListesi_Load(object sender, EventArgs e)
        {
            GetUserID();
            connection1.Open();
            SqlCommand cmd = new SqlCommand($"SELECT film_id FROM liste WHERE username_id={UserID}", connection1);
            SqlDataReader reader = cmd.ExecuteReader();

            SqlCommand cmd1;
            while (reader.Read())
            {
                int filmId = Int32.Parse(reader["film_id"].ToString());
                cmd1 = new SqlCommand($"SELECT id,Series_Title,Released_Year FROM filmler WHERE id={filmId}", connection1);
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    izlenecekList.Items.Add($"{reader1["id"]} | {reader1["Released_Year"]} | {reader1["Series_Title"]}");
                }
            }

            connection1.Close();
        }



        private void GetUserID()
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand($"SELECT id FROM accounts WHERE username='{Giriş.Username}'", connection1);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                UserID = Int32.Parse(reader["id"].ToString());
            }
            else
            {
                UserID = -1;
            }

            connection1.Close();

        }

        private void izlenecekList_DoubleClick(object sender, EventArgs e)
        {
            int index = izlenecekList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            int film_id = Int32.Parse(izlenecekList.Items[index].ToString().Split(" | ")[0]);
            DialogResult result = MessageBox.Show("Filmi kaldır", "Filmi izlenecekler listesinden kaldırmak istediğinizden emin misiniz?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                connection1.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM liste WHERE username_id={UserID} AND film_id={film_id}", connection1);
                cmd.ExecuteNonQuery();
                connection1.Close();
                izlenecekList.Items.RemoveAt(index);
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void İzlenecekListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            nesne.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = izlenecekList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            int film_id = Int32.Parse(izlenecekList.Items[index].ToString().Split(" | ")[0]);
            DialogResult result = MessageBox.Show("Filmi kaldır", "Filmi izlenecekler listesinden kaldırmak istediğinizden emin misiniz?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                connection1.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM liste WHERE username_id={UserID} AND film_id={film_id}", connection1);
                cmd.ExecuteNonQuery();
                connection1.Close();
                izlenecekList.Items.RemoveAt(index);
            }
            else if (result == DialogResult.No)
            {

            }
        }
    }
}
