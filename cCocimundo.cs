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
            Almacen = _Almacen;
            Camioneta = _Camioneta;
            Furgon = _Furgon;
            Camion = _Camion;

        }
        public void cargarvehiculos()
        {

            Camion.CargarVehiculo(Almacen);

            Furgon.CargarVehiculo(Almacen);

            Camioneta.CargarVehiculo(Almacen);


        }
        public void iniciarrecorrido()
        {
            if (Camion.Pedidos_a_bordo.Count() > 0) { Camion.recorrido(); }
            if (Furgon.Pedidos_a_bordo.Count() > 0) { Furgon.recorrido(); }
            if (Camioneta.Pedidos_a_bordo.Count() > 0) { Camioneta.recorrido(); }

            Camion.entregarpedidios();
            Camioneta.entregarpedidios();
            Furgon.entregarpedidios();
        }

    }

}