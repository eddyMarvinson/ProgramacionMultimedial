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
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes JPG|*.jpg";
            openFileDialog1.ShowDialog();
            try
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                pictureBox2.Image = bmp;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            refreshData();
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
                textBox6.Text = e.X.ToString();
                textBox7.Text = e.Y.ToString();
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
            }
            else
            {
                MessageBox.Show("Falta completar los valores");
            }
            refreshData();
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
                int redTipo, greenTipo, blueTipo;
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
            refreshData();
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
            }
            else
            {
                MessageBox.Show("Ingrese un valor en Textura");
            }
            refreshData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String xText = textBox6.Text;
            String yText = textBox7.Text;
            String anchuraText = textBox8.Text;
            String tipoText = textBox9.Text;
            if (xText != "" && yText != "" && anchuraText != "" && tipoText != "")
            {
                int u = Convert.ToInt32(xText);
                int v = Convert.ToInt32(yText);
                int w = Convert.ToInt32(anchuraText);
                FloodFill(u, v, w, tipoText);
            }
            else
            {
                MessageBox.Show("Falta completar los valores");
            }
            refreshData();
        }

        private void FloodFill(int x, int y, int w, String tipoText)
        {
            conexion1 conn = new conexion1();
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            int n = bmp.Width;
            int m = bmp.Height;
            Color c = new Color();
            bool[,,] arrRGB = new bool[256, 256, 256];
            for (int i = 0; i < 256; ++i)
                for (int j = 0; j < 256; ++j)
                    for (int k = 0; k < 256; ++k)
                        arrRGB[i, j, k] = false;

            int[] dx = {-1,0,1,1,1,0,-1,-1};
            int[] dy = {1,1,1,0,-1,-1,-1,0};
            int[,] distance = new int[n, m];
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                    distance[i, j] = -1;
            
            Stack<Point> stack = new Stack<Point>();
            Point p1 = new Point(x, y);
            distance[x, y] = 0;
            stack.Push(p1);
            while (stack.Count() > 0)
            {
                p1 = stack.Pop();
                if (distance[p1.X, p1.Y] > w)
                    continue;
                for (int i = 0; i < 8; ++i)
                {
                    int u = p1.X + dx[i];
                    int v = p1.Y + dy[i];
                    if (0 <= u && u < n && 0 <= v && v < m)
                    {
                        if (distance[u, v] == -1)
                        {
                            c = bmp.GetPixel(u, v);
                            if(!arrRGB[c.R, c.G, c.B])
                            {
                                arrRGB[c.R, c.G, c.B] = true;
                                String sentencia = "insert into color (name, red, green, blue) values ('" + tipoText + "'," + (c.R).ToString() + "," + (c.G).ToString() + "," + (c.B).ToString() + ")";
                                conn.EjecutarSentencia(new SqlCommand(sentencia));
                            }
                            distance[u, v] = distance[p1.X, p1.Y] + 1;
                            stack.Push(new Point(u, v));
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                pictureBox1.Image = pictureBox2.Image;
            }
            else
            {
                MessageBox.Show("Cargue una imagen");
            }
            refreshData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String sentencia = "delete from color";
            conexion1 conn = new conexion1();
            conn.EjecutarSentencia(new SqlCommand(sentencia));
            refreshData();
        }
    }
}