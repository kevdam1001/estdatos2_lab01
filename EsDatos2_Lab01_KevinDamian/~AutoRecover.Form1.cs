using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsDatos2_Lab01_KevinDamian
{
    public partial class Form1 : Form
    {
        bool play = false;
        string[] archivosMp3;
        string[] rutasArchivos;
        IDictionary<string, List<string>> dicc = new Dictionary<string, List<string>>();
        List<string> musica = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> nombres = new List<string>();
            foreach(var s in checkedListBox1.CheckedItems)
            {
                nombres.Add(s.ToString());
                listBox1.Items.Add(s.ToString());
            }

            try
            {
                dicc[comboBox1.SelectedItem.ToString()] = nombres;
                MessageBox.Show("Se añadieron las canciones a la playlist");
            }
            catch
            {
                MessageBox.Show("No se encontro la llave");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            OpenFileDialog cajadebusquedas = new OpenFileDialog();
            cajadebusquedas.Multiselect = true;
            if (cajadebusquedas.ShowDialog() == DialogResult.OK)
            {
                archivosMp3 = cajadebusquedas.SafeFileNames;
                rutasArchivos = cajadebusquedas.FileNames;

                foreach (var s in archivosMp3)
                {
                    checkedListBox1.Items.Add(s);
                    musica.Add(s);
                }

                axWindowsMediaPlayer2.URL = rutasArchivos[0];
                checkedListBox1.SelectedIndex = 0;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.URL = rutasArchivos[checkedListBox1.SelectedIndex];
        }

        public void recibirPlay(string nombre)
        {
            comboBox1.Items.Add(nombre);
            dicc.Add(nombre,null);
        }

        private void Menu_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(textBox1.Text);
            comboBox2.Items.Add(textBox1.Text);
            dicc.Add(textBox1.Text, null);
            MessageBox.Show("Se ha creado la playlist <" + textBox1.Text + ">");
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> nueva = new List<string>();

            nueva = dicc[comboBox2.SelectedItem.ToString()];

            foreach(var s in nueva)
            {
                listBox2.Items.Add(s);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = 0;
            foreach (var s in musica)
            {
                if (s == textBox2.Text)
                {
                    n = listBox1.SelectedIndex;
                    checkedListBox1.Items.Clear();
                    checkedListBox1.Items.Add(s);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            foreach(var s in musica)
            {
                checkedListBox1.Items.Add(s);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
