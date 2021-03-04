using System;
using System.Collections.Generic;
using System.Text;
using Corrientazo.Data.Enumeraciones;

namespace Corrientazo.Data.Comunes
{
    public class Objetivo
    {
        public int x { get; set; }
        public int y { get; set; }
        public PuntosCardinales orientacion { get; set; }
    }
}
