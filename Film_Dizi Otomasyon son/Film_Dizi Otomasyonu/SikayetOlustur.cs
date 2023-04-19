using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_Dizi_Otomasyonu
{
    public partial class SikayetOlustur : Form
    {
        internal static int userID;
        SqlConnection connection = VeriTabanı.connection;
        public Form1 nesne;
        public SikayetOlustur()
        {
            InitializeComponent();
        }

        private void SikayetButton_Click(object sender, EventArgs e)
        {

            string sikayetTitle = SikayetBasligiInput.Text;
            string sikayetDesc = SikayetAciklamasiInput.Text;


            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MAX(id) FROM sikayetler", connection);
            int Id;
            try
            {
                Id = Convert.ToInt32(cmd.ExecuteScalar().ToString()) + 1;
            }
            catch
            {
                Id = 0;
            }
            connection.Close();

            connection.Open();
            cmd = new SqlCommand($"INSERT INTO Sikayetler VALUES({Id},{userID},'{sikayetTitle}','{sikayetDesc}') ", connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Şikayetiniz talebiniz oluşturuldu.");
        }

        private void SikayetOlustur_Load(object sender, EventArgs e)
        {

        }

        private void SikayetOlustur_FormClosed(object sender, FormClosedEventArgs e)
        {
            nesne.Show();
        }
    }
}
