using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using juegoDeLaVida.Objetos;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace juegoDeLaVida.App
{
    public partial class Graficos : Form
    {
        GraficasUnidades graficasUnidades;
        public Graficos(GraficasUnidades graficasUnidades)
        {
            InitializeComponent();
            this.graficasUnidades = graficasUnidades;
            cartesianChart1.EasingFunction = null;
            timer1.Interval = 100;
            timer1.Start();
            timer1.Enabled = true;
        }

        private int sdw = 0;
        private void unosBtn_Click(object sender, EventArgs e)
        {
            sdw = 1;
            graficar(1);
        }


        private void logBtn_Click(object sender, EventArgs e)
        {
            sdw = 2;
            graficar(2);
        }

        private void shannBtn_Click(object sender, EventArgs e)
        {
            sdw = 3;
            graficar(3);
        }
        private void graficar(int opc)
        {
            switch (opc)
            {
                case 1:
                    cartesianChart1.Series = new ISeries[]
                    {
                        new LineSeries<Int64>
                        {
                            Values = graficasUnidades.unos,
                            GeometryStroke = null,
                            GeometryFill = null
                        }
                    };
                    cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
                    break;
                case 2:
                    cartesianChart1.Series = new ISeries[]
                    {
                        new LineSeries<Double>
                        {
                            Values = graficasUnidades.log,
                            GeometryStroke = null,
                            GeometryFill = null
                        }
                    };
                    cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
                    break;
                case 3:
                    cartesianChart1.Series = new ISeries[]
                    {
                        new LineSeries<Double>
                        {
                            Values = graficasUnidades.shannon,
                            GeometryStroke = null,
                            GeometryFill = null
                        }
                    };
                    cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
                    break;
                default:
                    break;
            }
            Application.DoEvents();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sdw == 1)
            {
                unosBtn.PerformClick();
            } else if (sdw == 2)
            {
                logBtn.PerformClick();
            } else if (sdw == 3)
            {
                shannBtn.PerformClick();
            }
            
        }
    }
}
