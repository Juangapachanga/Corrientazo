using System;
using System.Collections.Generic;
using System.Text;
using Corrientazo.Core.Abstractas;
using Corrientazo.Data.Enumeraciones;

namespace Corrientazo.Core
{
    public class CoordenadaCartesiana:CoordenadaBase
    {
        public CoordenadaCartesiana(int xa, int ya, int maxa, PuntosCardinales orientacion) : base(xa, ya, maxa)
        {
        
            this.orientacion = orientacion;

        }
        public PuntosCardinales orientacion { get; set; }
    }
}
