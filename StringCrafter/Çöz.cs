using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;

namespace StringCrafter
{
    public partial class Çöz : Form
    {
        public Çöz()
        {
            InitializeComponent();
        }

        private void Çöz_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            if (input.Length != 64)
            {
                MessageBox.Show("Lütfen tam 64 karakter girin.");
                return;
            }

            else if (!input.All(char.IsDigit))
            {
                MessageBox.Show("Lütfen sadece rakam girin.");
                return;
            }

            else
            {
                label3.Text = textBox1.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e) //çöz
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = ofd.FileName;
                label5.Text = dosyaYolu;
                string icerik = File.ReadAllText(dosyaYolu);

                textBox2.Text = icerik;


                string metin = textBox2.Text;
                string kod = label3.Text;

                string sonuc = KodCoz(kod, metin);
                textBox3.Text = sonuc;

            }
        }

        private string KodCoz(string kod, string metin)
        {
            string[] alfabe = { "A","B","C","Ç","D","E","F","G","Ğ","H","I","İ","J","K","L","M","N","O","Ö","P","R","S","Ş","T","U","Ü","V","Y","Z","Q","W","X" };

            string[] esleme = new string[32];
            for (int i = 0; i < 32; i++)
            {
                string parca = kod.Substring(i * 2, 2);
                if (parca == "00")
                {
                    esleme[i] = alfabe[i];
                }
                else
                {
                    int index = int.Parse(parca) - 1;
                    esleme[i] = alfabe[index];
                }
            }

            char[] sonuc = new char[metin.Length];
            for (int j = 0; j < metin.Length; j++)
            {
                char c = metin[j];
                char upper = char.ToUpper(c);

                int idx = Array.FindIndex(alfabe, a => a[0] == upper);
                if (idx >= 0)
                {
                    char hedef = esleme[idx][0];
                    sonuc[j] = char.IsUpper(c) ? char.ToUpper(hedef) : char.ToLower(hedef);
                }
                else
                {
                    sonuc[j] = c; 
                }
            }

            return new string(sonuc);
        }
        private void button2_Click(object sender, EventArgs e) //kaydet
        {
            if (textBox3.Text != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                sfd.Title = "Kaydet";
                sfd.FileName = "çözülmüşBilgi.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string dosyaYolu = sfd.FileName;

                    File.WriteAllText(dosyaYolu, textBox2.Text);

                    MessageBox.Show("Dosya kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }
    }
}
