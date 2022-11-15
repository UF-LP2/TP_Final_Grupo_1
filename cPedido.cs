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
        protected string ID;
        protected int prioridad;
        protected double beneficio;
        protected barrios barrio;
        protected double volumen;
        protected string tipo;
        protected float peso;
        protected bool apilable;
        protected bool necesita_elevador;
        public float precio { get; set; }
        public float largo { get; set; }
        public float ancho { get; set; }
        public float alto { get; set; }
       
        
        public DateTime fecha { get; set; }


        public cPedido(string _ID,int _prioridad, string _comprador, barrios _barrio, string _tipo, double _volumen, float _peso, bool _apilable, bool _necesita_elevador)
        {
            ID = _ID;
            prioridad = _prioridad;
            beneficio = (volumen*peso)/prioridad;
            barrio= _barrio;
            volumen = _volumen;
            tipo = _tipo;
            peso = _peso;
            apilable = _apilable;
            necesita_elevador = _necesita_elevador;

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
        public string getID()
        {
            return ID;
        }
        public float getPeso()
        {
            return peso;
        }
        public double getVolumen()
        {
            return volumen;
        }
        public string getNombre()
        {
            return tipo;

        }
    }
   
}
