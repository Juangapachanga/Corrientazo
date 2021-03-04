using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Corrientazo.Componentes.ImportarExportar.Interfaces
{
    /// <summary>
    /// Permite definir todas las opciones que existan para leer un archivo.  Inicialmente, desde una ruta.
    /// </summary>
    public interface IImportadorDeRegistros
    {

        /// <summary>
        /// Importa registros (líneas) de un archivo de texto específico.
        /// </summary>
        /// <param name="rutaArchivo"></param>
        /// <returns></returns>
        Task<List<string>> ImportarRegistros(string rutaArchivo);


    }
}
