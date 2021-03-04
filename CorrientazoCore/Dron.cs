using System;
using System.Collections.Generic;
using Corrientazo.Core.Interfaces;
using Corrientazo.Logica.ImportadorExportador;
using Corrientazo.Data;

namespace Corrientazo.Core
{
    public class Dron:IVehiculo
    {
        /// <summary>
        /// Corresponde al nombre(número) del dron, con lo que se determina el nombre de archivo que se va a leer y a escribir.
        /// </summary>
        public string nombre { get; set; }

        public EstadoBasicoVehiculo estado { get; set; }
        public List<Entrega> ruta { get; set; }
        public List<CoordenadaCartesiana> objetivos { get; set; }
    }
}
