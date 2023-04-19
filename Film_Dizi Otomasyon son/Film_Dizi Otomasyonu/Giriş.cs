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
    public partial class Giriş : Form
    {
        public static String gönderilecek;
        internal static string Username;
        Admin admin_nsn1 = new Admin();
        Form1 anasayfa = new Form1();
        public Giriş()
        {
            InitializeComponent();
        }

        private void Giriş_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = VeriTabanı.connection;
            try
            {

                con.Open();
                String sql = "Select * From accounts where username=@username AND password=@pass";


                SqlParameter prm1 = new SqlParameter("username", username.Text.Trim());//buradaki trim sql de 50 char lık alan verdiğimiz için daha az karakter girilirse
                SqlParameter prm2 = new SqlParameter("pass", pass.Text.Trim());//diğer alanlar boşluk olacağı için Trim bu boşlukları siliyor     
                Username = username.Text.Trim();
                SqlCommand com = new SqlCommand(sql, con);

                com.Parameters.Add(prm1);
                com.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);

                da.Fill(dt);


                if (dt.Rows.Count > 0)


                {
                    gönderilecek = username.Text;

                    MessageBox.Show("Giriş Başarılı.");
                    if (gönderilecek == "admin")
                    {
                        admin_nsn1.Show();
                        admin_nsn1.nesne_giris = this;
                        Admin.userID = (int)dt.Rows[0]["id"];
                        this.Hide();

                    }
                    else
                    {

                        İzlenecekListesi.UserID = (int)dt.Rows[0]["id"];
                        SikayetOlustur.userID = (int)dt.Rows[0]["id"];
                        filmöner.UserID = (int)dt.Rows[0]["id"];
                        flyweight.UserID = (int)dt.Rows[0]["id"];
                        anasayfa.nesne_giris = this;
                        anasayfa.Show();
                        this.Hide();
                    }
                    con.Close();
                }

                else
                {
                    throw new ExecutionEngineException();
                }


            }
            catch (Exception)
            {
                String sql1 = "Select * From accounts where username='" + username.Text.Trim() + "'";
                SqlCommand com1 = new SqlCommand(sql1, con);
                SqlDataReader sdr = com1.ExecuteReader();


                if (sdr.Read())
                {
                    MessageBox.Show("Şifreniz yanlış");
                    pass.Text = "";
                }
                else
                {
                    MessageBox.Show("Hatalı giriş Yaptınız.");
                    pass.Text = "";
                    username.Text = "";

                }
                con.Close();
                sdr.Close();


            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            üye_ol nsn_üye_ol = new üye_ol();
            nsn_üye_ol.Show();
        }

    
    }
}
