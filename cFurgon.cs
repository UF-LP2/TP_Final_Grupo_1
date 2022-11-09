using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgon: cVehiculo  
    {
        private bool montacargas;
        public cFurgon() : base(11,13, 54, 67,666, 123)
        {
            this.montacargas = false;
        }
    }
}
