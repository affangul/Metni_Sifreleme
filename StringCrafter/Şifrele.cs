using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;
using System.IO;


namespace StringCrafter
{
    public partial class Şifrele : Form
    {
        public Şifrele()
        {
            InitializeComponent();
        }

        private void Şifrele_Load(object sender, EventArgs e)
        {
            string[] alfabe = { "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z", "Q", "W", "X" };
            ComboBox[] comboBoxlar = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20, comboBox21, comboBox22, comboBox23, comboBox24, comboBox25, comboBox26, comboBox27, comboBox28, comboBox29, comboBox30, comboBox31, comboBox32 };

            foreach (ComboBox cmb in comboBoxlar)
            {
                cmb.Items.AddRange(alfabe);
            }


        }

        private void button1_Click(object sender, EventArgs e) //kodu güncelle
        {
            ComboBox[] comboBoxlar = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20, comboBox21, comboBox22, comboBox23, comboBox24, comboBox25, comboBox26, comboBox27, comboBox28, comboBox29, comboBox30, comboBox31, comboBox32 };
            string[] alfabe = { "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z", "Q", "W", "X" };
            Label[] labellar = { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, label19, label20, label21, label22, label23, label24, label25, label26, label27, label28, label29, label30, label31, label32 };
            string kod = "";
            // Dizileri aynı indekste gez
            for (int i = 0; i < comboBoxlar.Length; i++)
            {
                ComboBox cmb = comboBoxlar[i];
                Label lbl = labellar[i];

                if (cmb.Text != lbl.Text)
                {
                    kod += (Array.IndexOf(alfabe, cmb.Text) + 1).ToString("D2");
                }
                else
                {
                    kod += "00";
                }
            }
            label34.Text = kod;

        }

        private void button2_Click(object sender, EventArgs e) // şifrele
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

             if (ofd.ShowDialog() == DialogResult.OK)
              {
                  string dosyaYolu = ofd.FileName;
                  label38.Text = dosyaYolu;
                  string icerik = File.ReadAllText(dosyaYolu);

                  textBox1.Text = icerik;
              

            string metin = textBox1.Text;
            char[] yeniMetin = metin.ToCharArray();


            ComboBox[] comboBoxlar = {comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox6, comboBox7, comboBox8, comboBox9, comboBox10, comboBox11, comboBox12, comboBox13, comboBox14, comboBox15, comboBox16, comboBox17, comboBox18, comboBox19, comboBox20,comboBox21, comboBox22, comboBox23, comboBox24, comboBox25, comboBox26, comboBox27, comboBox28, comboBox29,comboBox30, comboBox31, comboBox32};

            string[] harfler = {"A","B","C","Ç","D","E","F","G","Ğ","H","I","İ","J","K","L","M","N","O","Ö","P","R","S","Ş","T","U","Ü","V","Y","Z","Q","W","X"};

                char[] sonucMetin = new char[metin.Length];

                for (int j = 0; j < metin.Length; j++)
                {
                    char karakter = metin[j];
                    char buyukKarakter = char.ToUpper(karakter);

                    int index = Array.FindIndex(harfler, h => h[0] == buyukKarakter);

                    if (index >= 0 && !string.IsNullOrEmpty(comboBoxlar[index].Text))
                    {
                        char secilenHarf = comboBoxlar[index].Text[0];
                        sonucMetin[j] = char.IsUpper(karakter) ? char.ToUpper(secilenHarf) : char.ToLower(secilenHarf);
                    }
                    else
                    {
                        sonucMetin[j] = karakter;
                    }
                }

                string sonuc = new string(sonucMetin);
                textBox2.Text = sonuc;
            }
        }

        private void button3_Click(object sender, EventArgs e) //kaydet
        {
            if (textBox2.Text != null)
            {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.Title = "Kaydet";
            sfd.FileName = "şifrelenmişBilgi.txt";

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
