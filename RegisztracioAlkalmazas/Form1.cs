using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisztracioAlkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileOk += (sender, e) =>
                {
                    try
                    {
                        using (var sr = new StreamReader(openFileDialog1.FileName))
                        {
                            listBox1.Items.Clear();
                            textBox1.Text = sr.ReadLine();
                            textBox2.Text = sr.ReadLine();
                            if (sr.ReadLine() == "Férfi")
                            {
                                radioButton1.Checked = true;
                                radioButton2.Checked = false;
                            }
                            else
                            {
                                radioButton1.Checked = false;
                                radioButton2.Checked = true;
                            }
                            while (!sr.EndOfStream)
                            {
                                listBox1.Items.Add(sr.ReadLine());
                            }
                        }
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Hiba! Nem sikerült a betöltés!");
                    }
                };
        }

        private void button2_Click(object sender, EventArgs e)
        {
                saveFileDialog1.ShowDialog();
        }
        
        
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                using (var sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine(textBox1.Text);
                    sw.WriteLine(textBox2.Text);
                    if (radioButton1.Checked)
                    {
                        sw.WriteLine("Férfi");
                    }
                    else
                    {
                        sw.WriteLine("Nő");
                    }

                    foreach (var item in listBox1.Items)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            catch(IOException)
            {
                MessageBox.Show("Hiba. Sikertelen mentés!");
            }
        }
        
        private void nev_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void datum_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void hobbi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox3.Text.Trim() != "")
            {
                listBox1.Items.Add(textBox3.Text);
                textBox3.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text.Trim() != "")
            {
                listBox1.Items.Add(textBox3.Text);
                textBox3.Text = "";
            }
            else
            {
               textBox3.Text = "";
            }

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
