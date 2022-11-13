using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cPedido
    {
        protected int prioridad;
        protected double beneficio;
        protected string comprador;
        protected cPaquete paquete;

        public cPedido(int _prioridad, string _comprador, cPaquete _paquete)
        {
            prioridad = _prioridad;
            beneficio = (_paquete.getPeso() * _paquete.getVolumen() );
            comprador = _comprador;
            paquete= _paquete;

        }

    public cPaquete GetPaquete()
        { 
            return paquete;
        }
    public double getBeneficio()
        {
            return beneficio;

        }
    }
   
}
