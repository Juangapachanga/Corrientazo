using Corrientazo.Componentes.ImportarExportar;
using Corrientazo.Componentes.ImportarExportar.Implementacion;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corrientazo.Logica.ImportadorExportador
{
    /// <summary>
    /// Represents an item that can export items to Excel.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Exportador<T>
    {
               
        /// <summary>
        /// Exporta una lista de registros (líneas) a un archivo específico.
        /// </summary>
        /// <param name="rutaArchivo"></param>
        /// <returns></returns>
        public void Exportar(List<string> exportados,string rutaArchivo)
        {
            ExportadorDeRegistrosTxt exportador = new ExportadorDeRegistrosTxt();
            exportador.ExportarRegistros(exportados, rutaArchivo);
        }

        /// <summary>
        /// Debe convertir una clase específica a texto.
        /// </summary>
        /// <returns></returns>
        public abstract List<string> ConvierteRegistros(List<T> exportados);

    }
}
