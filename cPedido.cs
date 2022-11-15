using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        protected barrios barrio;
     
       
        public cPedido(int _prioridad, string _comprador, cPaquete _paquete, barrios _barrio)
        {
            prioridad = _prioridad;
            beneficio = (_paquete.getPeso() * _paquete.getVolumen() );
            comprador = _comprador;
            paquete= _paquete;
            barrio= _barrio;
            
        }

    public cPaquete GetPaquete()
        { 
            return paquete;
        }
    public double getBeneficio()
        {
            return beneficio;

        }
     public barrios getBarrio()
        {
            return barrio;
        }
        public enum barrios
        {
            Comuna01, Comuna02, Comuna03, Comuna04, Comuna05, Comuna06, Comuna07, Comuna08, Comuna09, Comuna10, Comuna11, Comuna12, Comuna13, Comuna14,Comuna15, Avellaneda, SanMartin, LaMatanza, Lanus, Lomas, Moron, SanIsidro, TresFebrero, Vilo , 
        }
    }
   
}
