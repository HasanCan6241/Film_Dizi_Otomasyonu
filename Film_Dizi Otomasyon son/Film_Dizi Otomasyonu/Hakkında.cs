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
    public partial class Hakkında : Form
    {
        public Form1 nesne;
        public Hakkında()
        {
            InitializeComponent();
        }

        private void Hakkında_Load(object sender, EventArgs e)
        {

        }
        private void Hakkında_FormClosed(object sender, FormClosedEventArgs e)
        {
            nesne.Show();

        }
    }
}
