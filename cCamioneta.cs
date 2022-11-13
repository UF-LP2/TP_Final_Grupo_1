using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cCamioneta:cVehiculo
    {
        private int distancia;
        cCamioneta() : base(2, 456, 45, 267)
        {
            distancia = 186;
        }
    }
}
