using Accessibility;
using ILGPU;
using ILGPU.Runtime;
using ILGPU.Runtime.CPU;
using ILGPU.Runtime.Cuda;
namespace juegoDeLaVida
{
    public partial class Form1 : Form
    {
        private int longitud = 1000;
        private int longitudPixel = 1;
        int[,] celulaEstado;
        private Bitmap bmp;
        private Graphics g;
        private bool dibujar = false;
        private int porcentagee = 50;
        private int velocida = 50;
        private bool totalistica = false;
        private Int64 generacion = 0;
        private int zoom = 0;
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
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPress);
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

            List<Thread> threads = new List<Thread>();
            int threadCount = Environment.ProcessorCount; // N�mero de hilos disponibles

            // Divide la matriz en secciones para cada hilo
            int sectionHeight = longitud / threadCount;

            for (int i = 0; i < threadCount; i++)
            {
                int start = i * sectionHeight;
                int end = (i == threadCount - 1) ? longitud : (i + 1) * sectionHeight;

                Thread thread = new Thread(() =>
                {
                    for (int x = start; x < end; x++)
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
                });

                threads.Add(thread);
            }

            // Inicia todos los hilos
            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            // Espera a que todos los hilos terminen
            foreach (Thread thread in threads)
            {
                thread.Join();
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
            using Context context = Context.Create(builder => builder.Cuda());
            using Accelerator accelerator = context.CreateCudaAccelerator(0);
            // para 2 dimensiones se usa el Allocate2D



            List<Thread> threads = new List<Thread>();
            int threadCount = Environment.ProcessorCount; 

            int sectionHeight = longitud / threadCount;

            for (int i = 0; i < threadCount; i++)
            {
                int start = i * sectionHeight;
                int end = (i == threadCount - 1) ? longitud : (i + 1) * sectionHeight;

                Thread thread = new Thread(() =>
                {
                    for (int x = start; x < end; x++)
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
                });

                threads.Add(thread);
            }

            // Inicia todos los hilos
            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            // Espera a que todos los hilos terminen
            foreach (Thread thread in threads)
            {
                thread.Join();
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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                zoom++;
                pictureBox1.Height += zoom;
                pictureBox1.Width += zoom;
            }
            else if (e.KeyChar == '-')
            {
                if (zoom > 0.2f)
                {
                    zoom--;
                    pictureBox1.Height -= zoom;
                    pictureBox1.Width -= zoom;
                }
            }
        }

        private void pictureBox1_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
        }

        private void pictureBox1_MouseDown_1(object sender, MouseEventArgs e)
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

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            dibujar = false;
        }

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
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
    }
}