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
        protected string barrio;
        
        public cPedido(int _prioridad, string _comprador, cPaquete _paquete, string _barrio)
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
     public string getBarrio()
        {
            return barrio;
        }
        
    }
   
}
