using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
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
        public cVehiculo(int iD, double _volumen, int nodosrecorridos, int tanquelleno)
        {
            ID = iD;
            volumen = _volumen;
            this.nodosrecorridos = 0; //arranca siempre en 0
            this.tanquelleno = tanquelleno;
        }
        public void CargarVehiculo(List<cPedido> Almacen, int N)
        {
            double[,] matriz_beneficio = new double[(int)(volumen / 0.5), N];
            double volumen_actual = 0.5;
            for (int i = 0; i < N; i++)
            {
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

                        // caso no entra el nuevo
                        if (Almacen[i].GetPaquete().getVolumen() > volumen_actual)
                        {
                            //no entra el nuevo y es la primera columna
                            if (Almacen[i].GetPaquete().getVolumen() > volumen_actual
                                )
                            {
                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                            }
                            //no entra el nuevo y no es la primera columna

                        }
                        //caso entra justo el nuevo
                        if (Almacen[i].GetPaquete().getVolumen() == volumen_actual)
                        {

                            //caso entra el nuevo y es mejor que la suma de los viejos
                            if (Almacen[i].getBeneficio() >= matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = Almacen[i].getBeneficio();
                            }
                            //caso entro justo y no es mejor que el de arriba
                            if (Almacen[i].getBeneficio() < matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                            }
                        }
                        //caso entra el nuevo y mas
                        if (Almacen[i].GetPaquete().getVolumen() + 0.5 <= volumen_actual)
                        {
                            //caso el nuevo y la combinacion de los otros es mejor
                            if (Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5) - 1), i - 1] >= matriz_beneficio[j, i - 1] &&
                               Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5) - 1), i - 1] >= matriz_beneficio[j - 1, i])
                            {

                                matriz_beneficio[j, i] = Almacen[i].getBeneficio() + matriz_beneficio[((int)((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5)) - 1, i - 1];
                            }
                            //caso no conviene meter el nuevo
                            if (Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5) - 1), i - 1] < matriz_beneficio[j, i - 1] ||
                               Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].GetPaquete().getVolumen()) / 0.5) - 1), i - 1] < matriz_beneficio[j - 1, i])
                            {

                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                            }
                        }
                        //caso entra pero no justo ni deja espacio para otra cosa
                        if (Almacen[i].GetPaquete().getVolumen() < volumen_actual && Almacen[i].GetPaquete().getVolumen() + 0.5 > volumen_actual)
                        {
                            //caso entra el nuevo y es mejor que la suma de los viejos
                            if (Almacen[i].getBeneficio() >= matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = Almacen[i].getBeneficio();
                            }
                            //caso entro justo y no es mejor que el de arriba
                            if (Almacen[i].getBeneficio() < matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                            }
                        }


                    }
                    volumen_actual = volumen_actual + 0.5;
                }

            }
            for (int q = 0; q < N; q++)
            {
                for (int h = 0; h < 11; h++)
                {
                    Console.Write(matriz_beneficio[h, q]);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }

        }
        public void recorrido(List<cPedido> Almacen, int inicio, int fin)
        {
            int cont = Almacen.Count;
            cGrafo grafo = new cGrafo(cont);
           
            int distancia = 0;
            //string dato = "";
            int actual = 0;
            int columna = 0;


            int[,] tablavisitados = new int[cont, 3]; //pos 0 si se visito  pos 1distancia  // pos 2 se ve el anterior nodo

            for (int i = 0; i < cont; i++)
            {
                tablavisitados[i, 0] = 0;
                tablavisitados[i, 1] = int.MaxValue;
                tablavisitados[i, 2] = 0;
            }
            // tablavisitados[inicio, 1] = 0; modificar codigo para que me de el primer lugar, normalmente liniers
            int nodoactual = inicio;
            do
            {
                tablavisitados[nodoactual, 0] = 1; //visitado
                for (columna = 0; columna < cont; columna++)
                {
                    if (grafo.sonadyacentes(actual, columna) != 0)
                    {
                        distancia = grafo.sonadyacentes(actual, columna) + tablavisitados[nodoactual, 1];
                    }
                    if (distancia < tablavisitados[columna, 1])
                    {
                        tablavisitados[columna, 1] = distancia;
                        tablavisitados[columna, 2] = nodoactual;
                    }

                }
                int indicemenor = -1;
                int distanciamenor = int.MaxValue;
                for (int j = 0; j < cont; j++)
                {
                    if (tablavisitados[j, 1] < distanciamenor && tablavisitados[j, 0] == 0)
                    {
                        indicemenor = j;
                        distanciamenor = tablavisitados[j, 1];
                    }
                }
                nodoactual = indicemenor;
            } while (nodoactual != -1);
            List<int> dijkstra = new List<int>();

            int nodo = fin;
            
            while(nodo!=inicio)
            {
                dijkstra.Add(nodo);
                nodo=tablavisitados[nodo, 2];

            }
            dijkstra.Add(inicio);
            dijkstra.Reverse();
        }
    }
}

