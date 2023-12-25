using ILGPU;

using ILGPU.Runtime;
using ManagedCuda;
using ILGPU.Runtime.Cuda;
using System.Numerics;
using System.Diagnostics;
using juegoDeLaVida.Objetos;
using juegoDeLaVida.Utilidades;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.Security.Claims;
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
        public Objetos.GraficasUnidades graficasUnidades = new();
        private List<Int64> unoss = new();
        private List<Double> logss = new();
        private List<Double> shannonss = new();
        public Form1()
        {
            InitializeComponent();
            celulaEstado = new int[longitud, longitud];
            Smin.DropDownStyle = ComboBoxStyle.DropDownList;
            Smax.DropDownStyle = ComboBoxStyle.DropDownList;
            Nmin.DropDownStyle = ComboBoxStyle.DropDownList;
            Nmax.DropDownStyle = ComboBoxStyle.DropDownList;
            atractComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            atractComboBox.SelectedIndex = 0;
            Smin.SelectedIndex = 2;
            Smax.SelectedIndex = 3;
            Nmin.SelectedIndex = 3;
            Nmax.SelectedIndex = 3;
            timer2.Enabled = true;
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
            Utilidades.GrafsUtil grafsUtil = new();
            Int64 unos = grafsUtil.densidad1s(celulaEstado);
            unoss.Add(unos);
            logss.Add(grafsUtil.logUnos(unos));
            shannonss.Add(grafsUtil.entriopiaShannon(celulaEstado));
            graficasUnidades.unos = unoss;
            graficasUnidades.log = logss;
            graficasUnidades.shannon = shannonss;
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
            Utilidades.GrafsUtil grafsUtil = new();
            Int64 unos = grafsUtil.densidad1s(celulaEstado);
            unoss.Add(unos);
            logss.Add(grafsUtil.logUnos(unos));
            shannonss.Add(grafsUtil.entriopiaShannon(celulaEstado));
            graficasUnidades.unos = unoss;
            graficasUnidades.log = logss;
            graficasUnidades.shannon = shannonss;
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
        private List<Atracrs> atractoresResultados()
        {
            int n = Convert.ToInt32(atractComboBox.SelectedItem);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Atracrs> cadenaAtrctList = new();
            Atractores atractores = new();
            List<Universo> uni = atractores.calcularPosibilidades(n * n);
            List<String> final = new();
            final.Insert(0, Convert.ToString(new string('0', n * n)));
            List<String> aux = new();
            int i = 0;
            int numTareas = Environment.ProcessorCount;
            var tareas = new Task[numTareas];
            while (atractores.estaLleno(n * n, uni))
            {
                int tamanoPorcion = uni.Count / numTareas;

                int f = 0;
                foreach (Universo pepe in uni)
                {
                    if (final[i] == pepe.EstadoActual && pepe.EstaOcupado == false)
                    {
                        uni[f].EstaOcupado = true;
                        break;
                    }
                    if (final[i] == pepe.EstadoActual && pepe.EstaOcupado)
                    {
                        int hg = 0;
                        foreach (Universo coincidencias in uni)
                        {
                            if (!coincidencias.EstaOcupado)
                            {
                                final[i] = coincidencias.EstadoActual;
                                uni[hg].EstaOcupado = true;
                                break;
                            }

                            hg++;
                        }
                        break;
                    }
                    f++;
                }
                aux.Insert(i, final[i]);
                int[,] hola = new int[n, n];
                int fff = 0;
                for (int xf = 0; xf < n; xf++)
                {
                    for (int yf = 0; yf < n; yf++)
                    {
                        hola[xf, yf] = (final[i][fff] == '0') ? 0 : 1;
                        fff++;
                    }
                }
                longitud = n;
                celulaEstado = hola;
                juegoVida();
                String auxf = "";
                for (int gfr = 0; gfr < n; gfr++)
                {
                    for (int gfr2 = 0; gfr2 < n; gfr2++)
                    {
                        auxf += Convert.ToString(celulaEstado[gfr, gfr2]);
                    }
                }
                final.Insert(i + 1, auxf);
                Atracrs atracrs = new();
                atracrs.CadenaAnterior = final[i];
                atracrs.CadenaActual = final[i + 1];
                cadenaAtrctList.Add(atracrs);
                i++;
            }
            return cadenaAtrctList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Atracrs> atractores = new();
            atractores = atractoresResultados();
            proMaster(atractores);
        }
        private void proMaster(List<Atracrs> atractores)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var cadenaDOT = new StringBuilder("digraph G {");
            cadenaDOT.Append("bgcolor=\"black\";");

            Random random = new Random();

            for (int i = 0; i < atractores.Count; i++)
            {
                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);

                string color = $"#{r:X2}{g:X2}{b:X2}";

                cadenaDOT.Append($"\"{Convert.ToInt32(atractores[i].CadenaAnterior, 2)}\" [style=filled, fillcolor=\"{color}\"]; ");
                cadenaDOT.Append($"\"{Convert.ToInt32(atractores[i].CadenaActual, 2)}\" [style=filled, fillcolor=\"{color}\"]; ");
                cadenaDOT.Append($"\"{Convert.ToInt32(atractores[i].CadenaAnterior, 2)}\" -> \"{Convert.ToInt32(atractores[i].CadenaActual, 2)}\" [color=\"{color}\"]; ");
            }
            cadenaDOT.Append("}");

            cadenaDOT = cadenaDOT.Replace("\r\n", "");
            File.WriteAllText("C:\\Users\\Iljim\\Desktop\\AutomatasCelularesInfo\\Au2D\\atractores.dot", cadenaDOT.ToString());

            Process process = new();
            process.StartInfo.FileName = "circo";
            process.StartInfo.Arguments = "-Tsvg C:\\Users\\Iljim\\Desktop\\AutomatasCelularesInfo\\Au2D\\atractores.dot -o C:\\Users\\Iljim\\Desktop\\AutomatasCelularesInfo\\Au2D\\atractores.svg";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            string errors = process.StandardError.ReadToEnd();
            if (!string.IsNullOrEmpty(errors))
            {
                Console.WriteLine($"Error en: {errors}");
            }
            process.Close();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine($"Tiempo de ejecucion: {ts}");

            var privateKey = new PrivateKeyFile("C:\\Users\\Iljim\\Desktop\\AutomatasCelularesInfo\\Au2D\\Seh.pem");

            using SftpClient client = new("3.145.45.66", 22, "ubuntu", privateKey);
            try
            {
                client.Connect();
                if (client.IsConnected)
                {
                    Console.WriteLine("Conectado");
                    if (!client.Exists("/home/ubuntu/a2D/"))
                    {
                        client.CreateDirectory("/home/ubuntu/a2D/");
                        client.UploadFile(File.OpenRead("C:\\Users\\Iljim\\Desktop\\AutomatasCelularesInfo\\Au2D\\atractores.svg"), "/home/ubuntu/a2D/atractor.svg");
                        foreach (var file in client.ListDirectory("/home/ubuntu/a2D/"))
                        {
                            Console.WriteLine(file.FullName);
                        }
                    }
                    else
                    {
                        client.DeleteFile("/home/ubuntu/a2D/atractor.svg");
                        client.DeleteDirectory("/home/ubuntu/a2D/");
                        client.CreateDirectory("/home/ubuntu/a2D/");
                        client.UploadFile(File.OpenRead("C:\\Users\\Iljim\\Desktop\\AutomatasCelularesInfo\\Au2D\\atractores.svg"), "/home/ubuntu/a2D/atractor.svg");
                        foreach (var file in client.ListDirectory("/home/ubuntu/a2D/"))
                        {
                            Console.WriteLine(file.FullName);
                        }
                    }
                    client.Disconnect();
                }
                else
                {
                    Console.WriteLine("No conectado");
                    MessageBox.Show("No se pudo conectar al servidor");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label7.Text = $"Atractores de {atractComboBox.SelectedItem}x{atractComboBox.SelectedItem}";

        }

        private void atrBtn_Click(object sender, EventArgs e)
        {

        }

        private void graphBtn_Click(object sender, EventArgs e)
        {
            App.Graficos graficos = new(graficasUnidades);
            graficos.ShowDialog();
        }

        private void guardarImg_Click(object sender, EventArgs e)
        {
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Filter = "JPEG(*.JPG)|*.JPG|BMP(*.BMP)|*.BMP|PNG(*.PNG)|*.PNG";
            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(Guardar.FileName);
            }
        }
    }
}