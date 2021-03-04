using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Corrientazo.Componentes.ImportarExportar.Interfaces
{
    /// <summary>
    /// ELEMENTO QUE EXPORTA UNA LISTA DE ITEMS A UN ARCHIVO O A UN STREAM
    /// </summary>
    public interface IExportadorDeRegistros
    {
        /// <summary>
        /// Exporta lista de elemetos a un archivo de texto específico.
        /// </summary>
        /// <param name="PCampos"></param>
        /// <param name="PRegistros"></param>
        /// <param name="PRutaArchivo"></param>
        Task ExportarRegistros(List<string> registros, string rutaArchivo);

    }
}
