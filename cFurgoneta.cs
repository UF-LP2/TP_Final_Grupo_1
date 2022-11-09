using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgoneta:cVehiculo
    {
        private string color;
        cFurgoneta(string color): base(1,12,123,1234,0,1400)

        {
            this.color = color;
        }

    }
}
