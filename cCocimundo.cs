using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cCocimundo
    {
        public List<cPedido> Almacen;
        protected cVehiculo Camioneta;
        protected cVehiculo Furgon;
        protected cVehiculo Camion;

        public cCocimundo(List<cPedido> _Almacen, cVehiculo _Camioneta, cVehiculo _Furgon, cVehiculo _Camion)
        {
            Almacen= _Almacen;
            Camioneta= _Camioneta;
            Furgon= _Furgon;
            Camion= _Camion;

        }
        public void cargarvehiculos()
        {
            List<cPedido> Filtro_camioneta = new List<cPedido>();
            List<cPedido> Filtro_furgon = new List<cPedido>();
            List<cPedido> Filtro_camion = new List<cPedido>();

            for (int i = 0; i < Almacen.Count; i++)
            {
                
                    Filtro_camion.Add(Almacen[i]);
                   
                
            }
            Camion.CargarVehiculo(Filtro_camion);

            for (int i = 0; i < Almacen.Count; i++)
            {
                if (Almacen[i].necesita_elevador == false)
                {
                    Filtro_furgon.Add(Almacen[i]);
                    
                }
            }
            Furgon.CargarVehiculo(Filtro_furgon);

            for (int i = 0; i < Almacen.Count; i++)
            {
                if (Almacen[i].volumen < 1 && Almacen[i].necesita_elevador == false)
                {
                    Filtro_camioneta.Add(Almacen[i]);
                    
                }
            }
            Camioneta.CargarVehiculo(Filtro_camion);



        }

    }
   
}
