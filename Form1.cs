using Accessibility;

namespace juegoDeLaVida
{
    public partial class Form1 : Form
    {
        private int longitud = 100;
        private int longitudPixel = 10;
        int[,] celulaEstado;
        private Bitmap bmp;
        private Graphics g;
        private bool dibujar = false;
        private int porcentagee = 50;
        private int velocida = 50;
        private bool totalistica = false;
        private Int64 generacion = 0;
        public Form1()
        {
            InitializeComponent();
            celulaEstado = new int[longitud, longitud];
            Smin.DropDownStyle = ComboBoxStyle.DropDownList;
            Smax.DropDownStyle = ComboBoxStyle.DropDownList;
            Nmin.DropDownStyle = ComboBoxStyle.DropDownList;
            Nmax.DropDownStyle = ComboBoxStyle.DropDownList;
            Smin.SelectedIndex = 2;
            Smax.SelectedIndex = 3;
            Nmin.SelectedIndex = 3;
            Nmax.SelectedIndex = 3;
        }
        private static Color colorVida = Color.Black;
        private static Color colorFondo = Color.White;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void pintarMatriz()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int x = 0; x < longitud; x++)
            {
                for (int y = 0; y < longitud; y++)
                {
                    if (celulaEstado[x, y] == 0)
                    {
                        pintarPixel(bmp, x, y, colorFondo);
                    }
                    else
                    {
                        pintarPixel(bmp, x, y, colorVida);
                    }
                }
            }
            pictureBox1.Image = bmp;

        }
        private void pintarPixel(Bitmap bmp, int x, int y, Color color)
        {
            for (int i = 0; i < longitudPixel; i++)
            {
                for (int j = 0; j < longitudPixel; j++)
                {
                    bmp.SetPixel(i + (x * longitudPixel), j + (y * longitudPixel), color);
                }
            }
        }
        private void juegoVida()
        {
            int sMin = Convert.ToInt32(Smin.SelectedItem);
            int sMax = Convert.ToInt32(Smax.SelectedItem);
            int nMin = Convert.ToInt32(Nmin.SelectedItem);
            int nMax = Convert.ToInt32(Nmax.SelectedItem);
            int[,] celulaTemp = new int[longitud, longitud];
            for (int x = 0; x < longitud; x++)
            {
                for (int y = 0; y < longitud; y++)
                {
                    if (celulaEstado[x, y] == 0)
                    {
                        celulaTemp[x, y] = reglas(x, y, false, nMax, nMin);
                    }
                    else
                    {
                        celulaTemp[x, y] = reglas(x, y, true, sMax, sMin);
                    }
                }
            }
            celulaEstado = celulaTemp;
        }
        private int contarVecinasVivas(int x, int y)
        {
            int vecinasVivas = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    int xIndex = (i + longitud) % longitud;
                    int yIndex = (j + longitud) % longitud;

                    if (i != x || j != y)
                    {
                        vecinasVivas += celulaEstado[xIndex, yIndex];
                    }
                }
            }
            return vecinasVivas;
        }
        private int reglas(int x, int y, bool estado, int maxVecinos, int minVecinos)
        {
            int vecinasVivas = contarVecinasVivas(x, y);

            if (estado)
            {
                return (vecinasVivas >= minVecinos && vecinasVivas <= maxVecinos) ? 1 : 0;
            }
            else
            {
                return (vecinasVivas >= minVecinos && vecinasVivas <= maxVecinos) ? 1 : 0;
            }
        }
        private void juegoVida2()
        {
            string b = bTxtbx.Text;
            string s = sTxtbx.Text; 

            int[] bw = Array.ConvertAll(b.ToCharArray(), c => (int)Char.GetNumericValue(c));
            int[] sw = Array.ConvertAll(s.ToCharArray(), c => (int)Char.GetNumericValue(c));

            int[,] celulaTemp = new int[longitud, longitud];
            for (int x = 0; x < longitud; x++)
            {
                for (int y = 0; y < longitud; y++)
                {
                    if (celulaEstado[x, y] == 0)
                    {
                        celulaTemp[x, y] = reglas2(x, y, false, sw, bw);
                    }
                    else
                    {
                        celulaTemp[x, y] = reglas2(x, y, true, sw, bw);
                    }
                }
            }
            celulaEstado = celulaTemp;
        }
        private int contarVecinasVivas2(int x, int y)
        {
            int vecinasVivas = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    int xIndex = (i + longitud) % longitud;
                    int yIndex = (j + longitud) % longitud;

                    if (i != x || j != y)
                    {
                        vecinasVivas += celulaEstado[xIndex, yIndex];
                    }
                }
            }
            return vecinasVivas;
        }
        private int reglas2(int x, int y, bool estado, int[] sValues, int[] bValues)
        {
            int vecinasVivas = contarVecinasVivas2(x, y);

            if (estado)
            {
                return (sValues.Contains(vecinasVivas)) ? 1 : 0;
            }
            else
            {
                return (bValues.Contains(vecinasVivas)) ? 1 : 0;
            }
        }
        private void random_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    celulaEstado[i, j] = 0;
                }
            }

            Random ran = new Random();
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    double randomValue = ran.NextDouble() * 100;

                    if (randomValue < porcentagee)
                    {
                        celulaEstado[i, j] = 1;
                    }
                }
            }

            pintarMatriz();
        }

        private void iniciar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            totalistica = false;
        }

        private void pausa_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalistica)
            {
                juegoVida2();
            }
            else
            {
                juegoVida();
            
            }
            label6.Text = $"Generacion: {generacion++}";
            pintarMatriz();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorVida = colorDialog1.Color;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dibujar = true;
            int x = e.X / longitudPixel;
            int y = e.Y / longitudPixel;
            if (x >= 0 && x < longitud && y >= 0 && y < longitud)
            {
                celulaEstado[x, y] = celulaEstado[x, y] == 1 ? 0 : 1;
                pintarMatriz();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dibujar = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dibujar)
            {
                int x = e.X / longitudPixel;
                int y = e.Y / longitudPixel;
                if (x >= 0 && x < longitud && y >= 0 && y < longitud)
                {
                    celulaEstado[x, y] = celulaEstado[x, y] == 1 ? 0 : 1;
                    pintarMatriz();
                }
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int valorActual = hScrollBar1.Value;
            porcentagee = valorActual;
            porcentajeLbl.Text = $"Porcentaje {valorActual}%";
        }

        private void fondoButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorFondo = colorDialog1.Color;
            }
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            int valorActual = hScrollBar2.Value;
            velocida = valorActual;
            velLbl.Text = $"Velocidad t = {velocida * 10}";

            timer1.Interval = (velocida == 0) ? 1 : velocida * 10;
        }
        private void limpiarTablero()
        {
            for (int i = 0; i < longitud; i++)
            {
                for (int j = 0; j < longitud; j++)
                {
                    celulaEstado[i, j] = 0;
                }
            }

            pintarMatriz();
        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            limpiarTablero();
        }

        private void ntacionIni_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            totalistica = true;
        }
    }
}