using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace tp_final
{
 
    internal class cVehiculo
    {
        protected readonly int ID;
        protected double volumen;
        protected int nodosrecorridos;
        protected int tanquelleno;
        public cVehiculo(int iD,double _volumen,int nodosrecorridos, int tanquelleno)
        {
            ID = iD;
            volumen = _volumen;
            this.nodosrecorridos = 0; //arranca siempre en 0
            this.tanquelleno = tanquelleno;
        }
        public void CargarVehiculo(List<cPedido> Almacen, int N) {
            double[,] matriz_beneficio = new double[(int)(volumen/0.5), N];
            double volumen_actual = 0.5;
            for (int i = 0; i < N; i++) {
                volumen_actual = 0.5;
                for (int j = 0; j < 11; j++)
                {
                    //solo primera fila
                    if (i == 0 && Almacen[i].GetPaquete().getVolumen() <= volumen_actual)
                    {
                        matriz_beneficio[j, i] = Almacen[i].getBeneficio();

                    }
                    if (i > 0)
                    {
                        //caso entra el nuevo y es mejor que la suma de los viejos
                        if (Almacen[i].GetPaquete().getVolumen() <= volumen_actual && Almacen[i].getBeneficio() >= matriz_beneficio[j, i - 1])
                        {
                            matriz_beneficio[j, i] = Almacen[i].getBeneficio();
                        }
                        //caso entra el nuevo, pero no es mejor que la combinacion de los viejos
                        if (Almacen[i].GetPaquete().getVolumen() <= volumen_actual && Almacen[i].getBeneficio() < matriz_beneficio[j, i - 1])
                        {
                            matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                        }
                        if (j > 1)
                        {
                            if (Almacen[i].GetPaquete().getVolumen() < volumen_actual &&
                                Almacen[i].getBeneficio() + matriz_beneficio[ (int)(((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5) - 1),i-1] > matriz_beneficio[j, i - 1] &&
                                Almacen[i].getBeneficio() + matriz_beneficio[ (int)(((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5) - 1),i-1] > matriz_beneficio[j-1, i ])
                            {

                                matriz_beneficio[j, i] = Almacen[i].getBeneficio() + matriz_beneficio[(int)((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5) - 1, i-1];
                            }
                        }
                    }
                    volumen_actual = volumen_actual + 0.5;
                } 
            }
            for(int q = 0; q < N; q++)
            {
                for (int h=0;h<11;h++)
                {
                    Console.Write(matriz_beneficio[h,q]);
                }
                Console.WriteLine("");
            }

        }
    }
}
