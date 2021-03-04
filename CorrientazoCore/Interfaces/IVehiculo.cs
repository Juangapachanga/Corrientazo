using Corrientazo.Data;
using System.Collections.Generic;

namespace Corrientazo.Core.Interfaces
{
    public interface IVehiculo
    {
        public string nombre { get; set; }
        public EstadoBasicoVehiculo estado { get; set; }
        
        /// <summary>
        /// Define la lista de entregas que va a realizar el vehículo, que son determinadas por la lectura del archivo de entrada de texto respectivo.
        /// </summary>
        public List<Entrega> ruta { get; set;}

        /// <summary>
        /// Define la lista de objetivos alcanzados por el vehículo, que deben escribirse en el archivo de salida de texto respectivo.
        /// </summary>
        public List<CoordenadaCartesiana> objetivos { get; set; }

    }
}
