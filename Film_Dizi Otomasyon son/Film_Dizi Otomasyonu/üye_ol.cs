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
    public partial class üye_ol : Form
    {
        public üye_ol()
        {
            InitializeComponent();
        }


        private void üye_ol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con1 = VeriTabanı.connection;

            string t1, t2, t3, t4, t5, t6, t7;

            t1 = textBox1.Text;
            t2 = textBox2.Text;
            t3 = textBox3.Text;
            t4 = textBox4.Text;
            t5 = textBox5.Text;
            t7 = dateTimePicker1.Text;
            /*TimeSpan fark;
                      fark = DateTime.Parse("1.1.2021") - DateTime.Parse(t5);//iki tarih arası hesaplama*/

            t6 = "";

            bool isChecked = radioButton1.Checked;
            bool isChecked2 = radioButton2.Checked;

            if (isChecked)
                t6 = radioButton1.Text;

            else if (isChecked2)
            {
                t6 = radioButton2.Text;

            }
            else
            {
                t6 = "...";
            }
            if (t1.Equals("") || t2.Equals("") || t3.Equals("") || t4.Equals("") || t5.Equals(""))
            {
                MessageBox.Show("Lütfen boş bölme bırakmayınız !!!");

            }
            else
            {

                string var_mı_sorgu = $"Select * from accounts where e_posta='{t5.Trim()}' or username='{t1.Trim()}'";
                SqlCommand cmnd = new SqlCommand(var_mı_sorgu, con1);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmnd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bu e-postayla bir kayıt bulunmaktadır.");
                }
                else
                {
                    con1.Open();
                    //String alanları birbirinden ayırmak içi n '" kullanılır
                    String sorgu = "INSERT INTO accounts(username,password,isim,soyisim,e_posta,cinsiyet,d_tarihi) VALUES (@username,@sifre,@isim,@soyisim,@e_posta,@cinsiyet,@d_tarihi)";//SQL TABLOYA VERİLER EKLEME
                    SqlCommand ka = new SqlCommand(sorgu, con1);
                    ka.Parameters.AddWithValue("@username", t1.Trim());
                    ka.Parameters.AddWithValue("@sifre", t2.Trim());
                    ka.Parameters.AddWithValue("@isim", t3.Trim());
                    ka.Parameters.AddWithValue("@soyisim", t4.Trim());
                    ka.Parameters.AddWithValue("@e_posta", t5.Trim());
                    ka.Parameters.AddWithValue("@cinsiyet", t6.Trim());
                    ka.Parameters.AddWithValue("@d_tarihi", t7.Trim());
                    ka.ExecuteNonQuery();
                    con1.Close();
                    this.Close();
                    MessageBox.Show("Başarılı bir şekilde kayıt oldunuz");
                    //profil yerini doldurma bölüm
                }
            }
        }
    }
}
