using juegoDeLaVida.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace juegoDeLaVida.Utilidades
{
    public class Atractores
    {
        public Atractores()
        {
        }

        public List<Universo> calcularPosibilidades(int n)
        {
            List<Universo> d = new();
            int maxCombinations = (int)Math.Pow(2, n);

            for (int i = 0; i < maxCombinations; i++)
            {
                string binaryRepresentation = Convert.ToString(i, 2).PadLeft(n, '0');
                Universo pap = new();
                pap.EstadoActual = binaryRepresentation;
                pap.EstaOcupado = false;
                d.Add(pap);
                Console.WriteLine(binaryRepresentation);
            }

            return d;
        }

        public bool estaLleno(int n, List<Universo> d)
        {
            int i = 0;
            foreach (Universo uni in d)
            {
                if (uni.EstaOcupado) i++;
            }
            return i != d.Count;
        }
    }
}