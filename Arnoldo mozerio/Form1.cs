using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
//using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arnoldo_mozerio
{
    public partial class Form1 : Form
    {
        List<Kategorija> kategorijos = new List<Kategorija>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)

        {
            listBox3.Items.Add("Suma is viso: € " + "0");
            string[] kate = File.ReadAllLines("kategorijoss.txt", Encoding.Default);

            foreach (string z in kate)
            {
                string[] s = z.Split('&');

                Kategorija k = new Kategorija(Convert.ToInt32(s[0]), s[1]);
                kategorijos.Add(k);
            }

            kate = File.ReadAllLines("Patiekalai.txt", Encoding.Default);
            foreach (string l in kate)
            {
                string[] s = l.Split('&');

                Patiekalas p = new Patiekalas(Convert.ToInt32(s[0]),
                    s[2], Convert.ToDouble(s[4]), s[3], s[5]);


                foreach (Kategorija k in kategorijos)
                    if (k.kategorijosID == Convert.ToInt32(s[1]))
                    {
                        k.patiekaluSarasas.Add(p);
                        break;
                    }

            }

            int n = kategorijos.Count;
            Button[] kategorijuMygtukai = new Button[n];
            for (int i = 0; i < n; i++)
            {
                kategorijuMygtukai[i] = new Button();
                panel1.Controls.Add(kategorijuMygtukai[i]);
                kategorijuMygtukai[i].Text = kategorijos[i].kategorijosPavadinimas;
                kategorijuMygtukai[i].Location = new Point(10 + 130 * i, 10);
                kategorijuMygtukai[i].Height = 40;
                kategorijuMygtukai[i].Width = 120;
                kategorijuMygtukai[i].Click += Form1_Click;
                kategorijuMygtukai[i].Tag = kategorijos[i];
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            Button b = (Button)sender;
            Kategorija kategorija = (Kategorija)b.Tag;

            int n = kategorija.patiekaluSarasas.Count;
            Button[] patiekaluMygtukai = new Button[n];
            for (int i = 0; i < n; i++)
            {
                patiekaluMygtukai[i] = new Button();
                panel2.Controls.Add(patiekaluMygtukai[i]);
                patiekaluMygtukai[i].Text = kategorija.patiekaluSarasas[i].patiekaloPavadinimas;
                patiekaluMygtukai[i].Location = new Point(10, 10 + 50 * i);
                patiekaluMygtukai[i].Height = 40;
                patiekaluMygtukai[i].Width = 120;
                patiekaluMygtukai[i].Click += Form1_Click1;
                patiekaluMygtukai[i].Tag = kategorija.patiekaluSarasas[i];
            }
        }

        private void Form1_Click1(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Patiekalas patiekalas = (Patiekalas)b.Tag;
            pictureBox1.ImageLocation = patiekalas.patiekaloPaveikslelis;
            //richTextBox1.Clear();
            /*richTextBox1.Text = "Pavadinimas: " + patiekalas.patiekaloPavadinimas+" \n"
           
            +"Aprašymas: " + patiekalas.patiekaloAprasymas +" \n"
          +"Kaina: "  + "€" + patiekalas.patiekaloKaina ;
          */
            listBox1.Items.Clear();
            listBox1.Items.Add("pavadinimas: " + patiekalas.patiekaloPavadinimas + " \n");
            listBox1.Items.Add("aprasymas: " + patiekalas.patiekaloAprasymas + " \n");
            listBox1.Items.Add("kaina: € " + patiekalas.patiekaloKaina + " \n \n");




        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // NumberFormatInfo numberInfo = CultureInfo.CurrentCulture.NumberFormat;
            foreach (var item in listBox1.Items)
            {
                listBox2.Items.Add(item + "\n");
            }
            string c = listBox3.Items[0].ToString();
            listBox3.Items.Clear();
            string[] m = c.Split('€');
            // Convert.ToDouble(m[1]);
            double suma = Convert.ToDouble(m[1]);

            string a = listBox1.Items[2].ToString();
            string[] bbd = a.Split('€');
            //  Convert.ToDouble(bbd[1]);

            // double kaina= double.Parse(bbd[1], System.Globalization.NumberStyles.AllowDecimalPoint);
            double kaina = Convert.ToDouble(bbd[1]);

            suma = kaina + suma;
            listBox3.Items.Add("Suma is viso: € " + suma);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int g = 0;
            string a = "";
            if (listBox2.Items.Count == 0)
            {
                MessageBox.Show("Nėra ką šalinti");
            }
            else
            {
                g = listBox2.Items.Count - 1;
                a = listBox2.Items[g].ToString();
                // NumberFormatInfo numberInfo = CultureInfo.CurrentCulture.NumberFormat;
                for (int i = 0; i <= 2; i++)
                {
                    g = listBox2.Items.Count - 1;
                    listBox2.Items.RemoveAt(g);
                }


                string[] bbd = a.Split('€');
                Convert.ToDouble(bbd[1]);
                double kaina = Convert.ToDouble(bbd[1]);
                string f = listBox3.Items[0].ToString();
                string[] k = f.Split('€');
                double isviso = Convert.ToDouble(k[1]);
                isviso = isviso - kaina;
                listBox3.Items.Clear();
                listBox3.Items.Add("Suma is viso:  € " + isviso);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            MessageBox.Show("Uzsakymas priimtas");
            System.Environment.Exit(0);
        }
    }
    }

