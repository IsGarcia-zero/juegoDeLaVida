using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juegoDeLaVida.Utilidades
{
    public class GrafsUtil
    {
        public Int64 densidad1s(int[,] matriz)
        {
            Int64 unos = 0;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++) { if (matriz[i, j] == 1) { unos++; } }
            }
            return unos;
        }

        public Double logUnos(Int64 den)
        {
            Double elPRI;
            elPRI = Math.Log(Convert.ToDouble(den), 10);
            return elPRI;
        }

        public Double entriopiaShannon(int[,] matriz)
        {
            var frecuencias = new Dictionary<int, int>();
            foreach (int valor in matriz)
            {
                if (frecuencias.ContainsKey(valor))
                {
                    frecuencias[valor]++;
                }
                else
                {
                    frecuencias.Add(valor, 1);
                }
                
            }
            double entropia = 0.0;
            int total = matriz.GetLength(0) * matriz.GetLength(1);
            foreach (var kvp in frecuencias)
            {
                double probabilidad = (double)kvp.Value / total;
                entropia -= probabilidad * Math.Log(probabilidad, 2);
            }
            return entropia;
        }
    }
}
