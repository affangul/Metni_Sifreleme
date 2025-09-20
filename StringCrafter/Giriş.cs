using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringCrafter
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Şifrele şfr = new Şifrele();
            şfr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Çöz çz = new Çöz();
            çz.Show();
        }
    }
}
