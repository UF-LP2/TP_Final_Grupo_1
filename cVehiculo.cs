using csvfiles;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace tp_final
{
    public class cbarrios
    {
        public string barriardo;
        public double x { get; set;}
        public double y { get; set;}

        public cbarrios(string _barriardo, double _x, double _y)
        {
            this.barriardo = _barriardo;
            this.x = _x;
            this.y =_y;
        }
    }
    public class cVehiculo
    {
        protected readonly int ID;
        protected double volumen;
        protected int nodosrecorridos;
        protected int tanquelleno;
        public List<cPedido> Pedidos_a_bordo;

        public cVehiculo(int iD, double _volumen, int nodosrecorridos, int tanquelleno)
        {
            ID = iD;
            volumen = _volumen;
            this.nodosrecorridos = 0; //arranca siempre en 0
            this.tanquelleno = tanquelleno;
            Pedidos_a_bordo = new List<cPedido>();


        }
        public void CargarVehiculo(List<cPedido> Almacen)
        {
            int N = Almacen.Count;
            string[,] lista_productos = new string[(int)(volumen / 0.5), N];
            double[,] matriz_beneficio = new double[(int)(volumen / 0.5), N];
            double volumen_actual = 0.5;
            for (int i = 0; i < Almacen.Count; i++)
            {
                volumen_actual = 0.5;
                for (int j = 0; j < 11; j++)
                {
                    //solo primera fila
                    if (i == 0 && Almacen[i].getVolumen() <= volumen_actual)
                    {
                        matriz_beneficio[j, i] = Almacen[i].getBeneficio();
                        lista_productos[j, i] = Almacen[i].getID() + ",";

                    }
                    if (i > 0)
                    {

                        // caso no entra el nuevo
                        if (Almacen[i].getVolumen() > volumen_actual)
                        {
                            //no entra el nuevo y es la primera columna
                            if (Almacen[i].getVolumen() > volumen_actual
                                )
                            {
                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                                lista_productos[j, i] = lista_productos[j, i - 1];
                            }
                            //no entra el nuevo y no es la primera columna

                        }
                        //caso entra justo el nuevo
                        if (Almacen[i].getVolumen() == volumen_actual)
                        {

                            //caso entra el nuevo y es mejor que la suma de los viejos
                            if (Almacen[i].getBeneficio() >= matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = Almacen[i].getBeneficio();
                                lista_productos[j, i] = Almacen[i].getID() + ",";
                            }
                            //caso entro justo y no es mejor que el de arriba
                            if (Almacen[i].getBeneficio() < matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                                lista_productos[j, i] = lista_productos[j, i - 1];
                            }
                        }
                        //caso entra el nuevo y mas
                        if (Almacen[i].getVolumen() + 0.5 <= volumen_actual)
                        {
                            //caso el nuevo y la combinacion de los otros es mejor
                            if (Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].getVolumen()) / 0.5) - 1), i - 1] >= matriz_beneficio[j, i - 1] &&
                               Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].getVolumen()) / 0.5) - 1), i - 1] >= matriz_beneficio[j - 1, i])
                            {

                                matriz_beneficio[j, i] = Almacen[i].getBeneficio() + matriz_beneficio[((int)((volumen_actual - Almacen[i].getVolumen()) / 0.5)) - 1, i - 1];
                                lista_productos[j, i] = lista_productos[((int)((volumen_actual - Almacen[i].getVolumen()) / 0.5)) - 1, i - 1] + Almacen[i].getID() + ",";
                            }
                            //caso no conviene meter el nuevo
                            if (Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].getVolumen()) / 0.5) - 1), i - 1] < matriz_beneficio[j, i - 1] ||
                               Almacen[i].getBeneficio() + matriz_beneficio[(int)(((volumen_actual - Almacen[i].getVolumen()) / 0.5) - 1), i - 1] < matriz_beneficio[j - 1, i])
                            {

                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                                lista_productos[j, i] = lista_productos[j, i - 1];
                            }
                        }
                        //caso entra pero no justo ni deja espacio para otra cosa
                        if (Almacen[i].getVolumen() < volumen_actual && Almacen[i].getVolumen() + 0.5 > volumen_actual)
                        {
                            //caso entra el nuevo y es mejor que la suma de los viejos
                            if (Almacen[i].getBeneficio() >= matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = Almacen[i].getBeneficio();
                                lista_productos[j, i] = Almacen[i].getID() + ",";
                            }
                            //caso entro justo y no es mejor que el de arriba
                            if (Almacen[i].getBeneficio() < matriz_beneficio[j, i - 1])
                            {
                                matriz_beneficio[j, i] = matriz_beneficio[j, i - 1];
                                lista_productos[j, i] = lista_productos[j, i - 1];
                            }
                        }


                    }
                    volumen_actual = volumen_actual + 0.5;
                }

            }
            for (int q = 0; q < Almacen.Count; q++)
            {
                for (int h = 0; h < 11; h++)
                {
                    Console.Write(matriz_beneficio[h, q]);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }


            string codigos = lista_productos[(int)(volumen / 0.5) - 1, Almacen.Count - 1];
            string[] Codigos = codigos.Split(",");

            for (int w = 0; w < Codigos.Length; w++)
            {
                Console.WriteLine(Codigos[w]);
                for (int i = 0; i < Almacen.Count; i++)
                {

                    if (Almacen[i].getID() == Codigos[w])
                    {
                        Pedidos_a_bordo.Add(Almacen[i]);
                        Almacen.Remove(Almacen[i]);
                    }
                }

            }

        }
        public double calculardistancia(cPedido pedido1,cPedido pedido2 )
        {
            double distancia =  Math.Sqrt(pedido1.barrio.x * pedido1.barrio.x - pedido2.barrio.x * pedido2.barrio.x + pedido1.barrio.y * pedido1.barrio.y - pedido2.barrio.y * pedido2.barrio.y);
            return distancia;
        }

       

        public cPedido pedidomascercano(List<cPedido> Almacen, cPedido pedido)
        {
            cPedido minimo = Almacen[0];
            for (int i=0;i<Almacen.Count;i++)
            {
                if (calculardistancia(pedido, Almacen[i])< calculardistancia(pedido, minimo))
                {
                    minimo = Almacen[i];
                }
               
            }
               
                return minimo;
        }
        public cPedido primerpedido(List<cPedido> Almacen)
        {
            cPedido minimo = Almacen[0];
            for (int i = 0; i < Almacen.Count; i++)
            {
                if (Math.Sqrt(Almacen[i].barriecito.x* Almacen[i].barriecito.x + Almacen[i].barriecito.y * Almacen[i].barriecito.y)< Math.Sqrt(minimo.barriecito.x * minimo.barriecito.x + minimo.barriecito.y * minimo.barriecito.y))
                {
                    minimo = Almacen[i];
                }

            }

            return minimo;
        }
        public void recorrido(List<cPedido> Almacen)
        {
            cbarrios Comuna01 = new cbarrios("comuna 1", 10, 4);
            cbarrios Comuna02 = new cbarrios("comuna 2", 9, 5);
            cbarrios Comuna03 = new cbarrios("comuna 3", 9, 4);
            cbarrios Comuna04 = new cbarrios("comuna 4", 10, 0);
            cbarrios Comuna05 = new cbarrios("comuna 5", 8, 1);
            cbarrios Comuna06 = new cbarrios("comuna 6", 7, 1);
            cbarrios Comuna07 = new cbarrios("comuna 7", 7, 0);
            cbarrios Comuna08 = new cbarrios("comuna 8", 4, -3);
            cbarrios Comuna09 = new cbarrios("comuna 9 ", 1, -1);
            cbarrios Comuna10 = new cbarrios("comuna 10", 1, 1);
            cbarrios Comuna11 = new cbarrios("comuna 11", 1, 3);
            cbarrios Comuna12 = new cbarrios("comuna 12", 2, 8);

            cbarrios Comuna13 = new cbarrios("comuna 13", 4, 8);
            cbarrios Comuna14 = new cbarrios("comuna 14", 5, 7);
            cbarrios Comuna15 = new cbarrios("comuna 15", 3, 3);
            cbarrios tresfebrero = new cbarrios("tres de febrero", -1, 1);
            cbarrios moron = new cbarrios("moron", -2, 0);
            cbarrios VicenteLopez = new cbarrios("vicente lopez", 0, 10);
            cbarrios SanIsidro = new cbarrios("san isidro", -3, 11);
            cbarrios Liniers = new cbarrios("linieros", 0, 0);
            cbarrios Lanus = new cbarrios("lanus", 9, -5);
            cbarrios LaMatanza = new cbarrios("la matanza", 0, -2);
            cbarrios Avellaneda = new cbarrios("avellaneda", 11, 0);
            cbarrios Lomas = new cbarrios("lomas de zamora", 4, -4);

            cPedido primero = primerpedido(Almacen);
            List<cPedido> recorrido = new List<cPedido>();
            recorrido.Add(primero);
            Almacen.Remove(primero);
            while (Almacen.Count > 0)
            {
                for (int i = 0; i < Almacen.Count; i++)
                {
                    cPedido segundo = pedidomascercano(Almacen, primero);
                    recorrido.Add(segundo);
                    Almacen.Remove(segundo);
                    primero = segundo;
                }
            }

        }
    
    

}

