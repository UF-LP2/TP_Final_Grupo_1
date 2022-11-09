using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cVehiculo
    {
        protected readonly int ID;
        protected float alto;
        protected float largo;
        protected float ancho;
        protected int nodosrecorridos;
        protected int tanquelleno;
        public cVehiculo(int iD, float alto, float largo, float ancho, int nodosrecorridos, int tanquelleno)
        {
            ID = iD;
            this.alto = alto;
            this.largo = largo;
            this.ancho = ancho;
            this.nodosrecorridos = 0; //arranca siempre en 0
            this.tanquelleno = tanquelleno;
        }

    }
}
