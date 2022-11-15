using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cPaquete
    {
        protected double volumen;
        protected string tipo;
        protected float peso;
        protected bool apilable;
        protected bool necesita_elevador;

        public cPaquete(string _tipo, double _volumen, float _peso, bool _apilable, bool _necesita_elevador)
        {
            volumen = _volumen;
            tipo = _tipo;
            peso = _peso;
            apilable = _apilable;
            necesita_elevador = _necesita_elevador;
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
