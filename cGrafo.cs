using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cGrafo
    {
        private int[,] matrizbarrios;
        private int[] restador;
        private int cantnodos;

        public cGrafo(int _cantnodos)
        {
            this.cantnodos = _cantnodos;

            matrizbarrios = new int[cantnodos, cantnodos];
            restador = new int[cantnodos];
        }

        public void agregardistanciabarrio(int inicio, int final, int pesoentrebarrios)//ver como con un enum poner los barrios
        {
            matrizbarrios[inicio, final] = pesoentrebarrios;

        }

        public int sonadyacentes(int fila, int columna)
        {
            return matrizbarrios[fila, columna];

        }
        public void restar()
        {
            int n = 0;
            int m = 0;
            for (n = 0; n < cantnodos; n++)
            {
                for (m = 0; m < cantnodos; m++)
                {
                    if (matrizbarrios[m, n] == 1)
                    {
                        restador[n]++;

                    }
                }
            }

        }
        public int indice0()
        {
            bool encontrado = false;
            int i = 0;
            for (i = 0; i < cantnodos; i++)
            {
                if (restador[i] == 0)
                {
                    encontrado = true;
                    break;
                }

            }
                if (encontrado)
                {
                    return i;

                }
                else
                {
                    return -1;
                }
              
            }
        public void restarrestador(int nodo)
        {
            restador[nodo] = -1;
            for(int i=0;i<cantnodos; i++)
            {
                if (matrizbarrios[nodo,i]==1)
                {
                    restador[i]--;
                }
            }
        }
    }  
}
