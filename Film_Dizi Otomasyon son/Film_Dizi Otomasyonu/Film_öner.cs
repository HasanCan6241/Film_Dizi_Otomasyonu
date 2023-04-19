using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_Dizi_Otomasyonu
{
    public partial class Film_öner : Form
    {
        public Form1 nesne;
        public Film_öner()
        {
            InitializeComponent();
        }

        private void Film_öner_Load(object sender, EventArgs e)
        {

        }

        private void Film_öner_FormClosed(object sender, FormClosedEventArgs e)
        {
            nesne.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filmöner nsn1 = new filmöner();
            nsn1.nesne = this;
            nsn1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModArama nsn1 = new ModArama();
            nsn1.nesne = this;
            nsn1.Show();
            this.Hide();
        }
    }
}
