using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgoneta:cVehiculo
    {
        private float volumen;
        private bool montacargas;
        cFurgoneta(float _volumen,bool _montacargas): base(1,12,123,1234)

        {
            volumen=_volumen;
            montacargas = _montacargas;
        }

    }
}
