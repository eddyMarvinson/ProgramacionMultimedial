using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            refreshData();
        }
        private void refreshData()
        {
            conexion1 conn = new conexion1();
            DataSet data = conn.EjecutarSentenciaRetornaDataset(new SqlCommand("SELECT name as Textura, avg(red) as R, avg(green) as G, avg(blue) as B FROM color group by name"));
            dataGridView1.DataSource = data.Tables[0];
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes JPG|*.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            pictureBox2.Image = bmp;
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox2.Image != null)
            {

                Bitmap bmp = new Bitmap(pictureBox1.Image);
                Color c = new Color();
                c = bmp.GetPixel(e.X, e.Y);
                textBox1.Text = c.R.ToString();
                textBox2.Text = c.G.ToString();
                textBox3.Text = c.B.ToString();
            }
            else
            {
                MessageBox.Show("Cargue una imagen");
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) {}
        private void label4_Click(object sender, EventArgs e) {}
        private void button2_Click(object sender, EventArgs e)
        {
            String rText = textBox1.Text;
            String gText = textBox2.Text;
            String bText = textBox3.Text;
            String tipoText = textBox4.Text;
            if(rText != "" && gText != "" && bText != "" && tipoText != "")
            {
                conexion1 conn = new conexion1();
                String sentencia = "insert into color (name, red, green, blue) values ('" + tipoText + "'," + rText + "," + gText + "," + bText + ")";
                conn.EjecutarSentencia(new SqlCommand(sentencia));
                refreshData();
            }
            else
            {
                MessageBox.Show("Completar los valores ingresados");
            }
        }
        private void label5_Click(object sender, EventArgs e) {}
        private void pictureBox2_Click(object sender, EventArgs e) {}
        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                conexion1 conn = new conexion1();
                List<String> listaTipos = conn.EjecutarSentenciaRetornaCadenas(new SqlCommand("SELECT DISTINCT name as value FROM color"));
                List<int> redAvg = new List<int>();
                List<int> blueAvg = new List<int>();
                List<int> greenAvg = new List<int>();
                int redTipo=-1, greenTipo, blueTipo;
                foreach (String s in listaTipos)
                {
                    redTipo = conn.EjecutarSentenciaRetornaEnteros(new SqlCommand("SELECT avg(red) as value FROM color WHERE name = '" + s + "'"));
                    greenTipo = conn.EjecutarSentenciaRetornaEnteros(new SqlCommand("SELECT avg(green) as value FROM color WHERE name = '" + s + "'"));
                    blueTipo = conn.EjecutarSentenciaRetornaEnteros(new SqlCommand("SELECT avg(blue) as value FROM color WHERE name = '" + s + "'"));
                    redAvg.Add(redTipo);
                    greenAvg.Add(greenTipo);
                    blueAvg.Add(blueTipo);
                }
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
                Color c = new Color();
                int ciR, ciG, ciB;
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        c = bmp.GetPixel(i, j);
                        ciR = c.R;
                        ciG = c.G;
                        ciB = c.B;
                        int mejorColor = int.MaxValue, valorEvaluado;
                        for (int k = 0; k < listaTipos.Count(); ++k)
                        {
                            redTipo = redAvg.ElementAt(k);
                            greenTipo = greenAvg.ElementAt(k);
                            blueTipo = blueAvg.ElementAt(k);
                            valorEvaluado = funcionEvaluadora(ciR, ciG, ciB, redTipo, greenTipo, blueTipo);
                            mejorColor = Math.Min(mejorColor, valorEvaluado);
                        }
                        for (int k = 0; k < listaTipos.Count(); ++k)
                        {
                            redTipo = redAvg.ElementAt(k);
                            greenTipo = greenAvg.ElementAt(k);
                            blueTipo = blueAvg.ElementAt(k);
                            valorEvaluado = funcionEvaluadora(ciR, ciG, ciB, redTipo, greenTipo, blueTipo);
                            if (mejorColor == valorEvaluado)
                            {
                                bmp2.SetPixel(i, j, Color.FromArgb(redTipo, greenTipo, blueTipo));
                                break;
                            }
                        }
                    }
                }
                pictureBox1.Image = bmp2;
            }
            else
            {
                MessageBox.Show("Cargue una imagen");
            }
        }
        private int funcionEvaluadora(int r1, int g1, int b1, int r2, int g2, int b2)
        {
            return (Math.Abs(r1-r2) + Math.Abs(g1 - g2) + Math.Abs(b1 - b2)) / 3;
        }
        private void label6_Click(object sender, EventArgs e){ }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                conexion1 conn = new conexion1();
                String sentencia = "delete from color where name = '" + textBox5.Text + "'";
                conn.EjecutarSentencia(new SqlCommand(sentencia));
                refreshData();
            } else
            {
                MessageBox.Show("Ingrese un valor en Textura");
            }
        }
    }
}