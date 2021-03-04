using Corrientazo.Componentes.ImportarExportar.Core;
using Corrientazo.Componentes.ImportarExportar.Interfaces;
using Corrientazo.Logica.ImportadorExportador.Importadores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corrientazo.Logica.ImportadorExportador
{
    /// <summary>
    /// Permite cargar líneas de texto y convertirlas/mapearlas en un tipo determinado.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Importador<T> : BaseImportado
    {
        public List<string> importados;

        /// <summary>
        /// Importa una lista de registros (líneas) desde un archivo específico.
        /// </summary>
        /// <param name="rutaArchivo"></param>
        /// <returns></returns>
        public async Task<List<string>> Importar(string rutaArchivo)
        {
            importados = new List<string>();
            IImportadorDeRegistros importador = new ImportadorDeRegistrosTxt();
            importados = await importador.ImportarRegistros(rutaArchivo);
            return importados;
        }

        /// <summary>
        /// Debe convertir el texto a una clase específica.
        /// </summary>
        /// <returns></returns>
        public abstract List<T> ConvierteRegistros();

    }
}
