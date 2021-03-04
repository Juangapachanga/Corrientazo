using Corrientazo.Logica.ImportadorExportador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corrientazo.Core.Interfaces;
using Corrientazo.Core.Abstractas;
using Corrientazo.Data;

namespace Corrientazo.Core
{

    public class GeneradorDeRuta : ArchivoBase
    {
        public GeneradorDeRuta(string rutaBase)
        {
            ArchivoBase.rutaBase = rutaBase;
        }

        public static async Task<List<Entrega>> GenerarRutaAsync(string vehiculoNombre)
        {
            //LEE ARCHIVO PARA CARGAR RUTA (LISTA DE MOVIMIENTOS)
            ImportadorRutas importadorRutas = new ImportadorRutas();
            List<string> movimientos = await importadorRutas.Importar($"{rutaBase}\\IN\\in{vehiculoNombre.PadLeft(2, '0')}.txt");
            List<Entrega> ruta = new List<Entrega>();
            ruta = importadorRutas.ConvierteRegistros();
            return ruta;
        }

        public static async Task<IEnumerable<List<Entrega>>> GenerarRutasAsync(List<string> vehiculos)
        {
            var generarRutas = new List<Task<List<Entrega>>>();
            foreach (string nombre in vehiculos)
            {
                generarRutas.Add(GenerarRutaAsync(nombre));
            }

            return await Task.WhenAll(generarRutas);
        }

    }
}
