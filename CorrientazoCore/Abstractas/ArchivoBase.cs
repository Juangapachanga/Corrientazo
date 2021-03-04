using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrientazo.Core.Abstractas
{
    public class ArchivoBase
    {
        private static string _rutaBase;

        public static string rutaBase
        {
            get { return _rutaBase; }
            set { _rutaBase = value; }
        }

    }
}
