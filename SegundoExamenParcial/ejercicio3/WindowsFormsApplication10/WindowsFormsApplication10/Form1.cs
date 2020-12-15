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
        int cR, cG, cB;
        int cmR, cmG, cmB;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imagenes JPG|*.jpg";
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            pictureBox2.Image = bmp;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            cR = c.R;
            cG = c.G;
            cB = c.B;
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            cmR = 0;
            cmG = 0;
            cmB = 0;
            for (int i = e.X; i < e.X + 5; i++)
                for (int j = e.Y; j < e.Y + 5; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cmR = cmR + c.R;
                    cmG = cmG + c.G;
                    cmB = cmB + c.B;
                }
            cmR = cmR / 25;
            cmG = cmG / 25;
            cmB = cmB / 25;
            textBox1.Text = cmR.ToString();
            textBox2.Text = cmG.ToString();
            textBox3.Text = cmB.ToString();

            //tipo1 agua -> Turquesa (64, 224, 208)
            //tipo2 bosque -> Lima (0, 255, 0)
            //tipo3 incendio -> Rojo (255, 0, 0)
            //tipo4 cuerpo blanco LightGreen (144, 238, 144)
            //tipo5 tierra cafe (139, 69, 19)
            
            if (cmR == 64 && cmG == 224 && cmB == 208)
            {
                textBox4.Text = "Agua";
            }
            else
            {
                if (cmR == 0 && cmG == 255 && cmB == 0)
                {
                    textBox4.Text = "Bosque";
                }
                else
                {
                    if (cmR == 255 && cmG == 0 && cmB == 0)
                    {
                        textBox4.Text = "Incendio";
                    }
                    else
                    {
                        if (cmR == 144 && cmG == 238 && cmB == 144)
                        {
                            textBox4.Text = "Cuerpo Blanco";
                        }
                        else
                        {
                            if (cmR == 139 && cmG == 69 && cmB == 19)
                            {
                                textBox4.Text = "Tierra";
                            }
                            else
                            {
                                textBox4.Text = "Sin identificar";
                            }
                        }
                    }
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conexion1 conn = new conexion1();
            //tipo1 agua -> Turquesa (64, 224, 208)
            int redTipo1 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(red) as value FROM colorRGB WHERE tipo = 1"));
            int greenTipo1 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(green) as value FROM colorRGB WHERE tipo = 1"));
            int blueTipo1 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(blue) as value FROM colorRGB WHERE tipo = 1"));
            //tipo2 bosque -> Lima (0, 255, 0)
            int redTipo2 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(red) as value FROM colorRGB WHERE tipo = 2"));
            int greenTipo2 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(green) as value FROM colorRGB WHERE tipo = 2"));
            int blueTipo2 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(blue) as value FROM colorRGB WHERE tipo = 2"));
            //tipo3 incendio -> Rojo (255, 0, 0)
            int redTipo3 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(red) as value FROM colorRGB WHERE tipo = 3"));
            int greenTipo3 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(green) as value FROM colorRGB WHERE tipo = 3"));
            int blueTipo3 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(blue) as value FROM colorRGB WHERE tipo = 3"));
            //tipo4 cuerpo blanco LightGreen (144, 238, 144)
            int redTipo4 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(red) as value FROM colorRGB WHERE tipo = 4"));
            int greenTipo4 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(green) as value FROM colorRGB WHERE tipo = 4"));
            int blueTipo4 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(blue) as value FROM colorRGB WHERE tipo = 4"));
            //tipo5 tierra cafe (139, 69, 19)
            int redTipo5 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(red) as value FROM colorRGB WHERE tipo = 5"));
            int greenTipo5 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(green) as value FROM colorRGB WHERE tipo = 5"));
            int blueTipo5 = conn.EjecutarSentenciaEntero(new SqlCommand("SELECT avg(blue) as value FROM colorRGB WHERE tipo = 5"));

            Bitmap bmp = new Bitmap(pictureBox2.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int ciR, ciG, ciB;
            int a1, b1, c1, d1, e1, minimo;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    ciR = c.R;
                    ciG = c.G;
                    ciB = c.B;
                    a1 = funcionEvaluadora(ciR, ciG, ciB, redTipo1, greenTipo1, blueTipo1);
                    b1 = funcionEvaluadora(ciR, ciG, ciB, redTipo2, greenTipo2, blueTipo2);
                    c1 = funcionEvaluadora(ciR, ciG, ciB, redTipo3, greenTipo3, blueTipo3);
                    d1 = funcionEvaluadora(ciR, ciG, ciB, redTipo4, greenTipo4, blueTipo4);
                    e1 = funcionEvaluadora(ciR, ciG, ciB, redTipo5, greenTipo5, blueTipo5);
                    minimo = valorMinimo(a1, b1, c1, d1, e1);

                    if(minimo == a1)
                    {
                        bmp2.SetPixel(i, j, Color.FromArgb(64, 224, 208));
                    } else
                    {
                        if (minimo == b1)
                        {
                            bmp2.SetPixel(i, j, Color.FromArgb(0, 255, 0));
                        }
                        else
                        {
                            if (minimo == c1)
                            {
                                bmp2.SetPixel(i, j, Color.FromArgb(255, 0, 0));
                            }
                            else
                            {
                                if (minimo == d1)
                                {
                                    bmp2.SetPixel(i, j, Color.FromArgb(144, 238, 144));
                                }
                                else
                                {
                                    if (minimo == e1)
                                    {
                                        bmp2.SetPixel(i, j, Color.FromArgb(139, 69, 19));
                                    } else
                                    {
                                        bmp2.SetPixel(i, j, Color.FromArgb(ciR, ciG, ciB));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            pictureBox1.Image = bmp2;
        }
        private int funcionEvaluadora(int r1, int g1, int b1, int r2, int g2, int b2)
        {
            // aplicando desviacion del promedio = xi - X_media
            return (Math.Abs(r1-r2) + Math.Abs(g1 - g2) + Math.Abs(b1 - b2)) / 3;
        }
        private int valorMinimo(int a1, int b1, int c1, int d1, int e1)
        {
            return Math.Min(a1, Math.Min(b1, Math.Min(c1, Math.Min(d1, e1))));
        }
    }
}