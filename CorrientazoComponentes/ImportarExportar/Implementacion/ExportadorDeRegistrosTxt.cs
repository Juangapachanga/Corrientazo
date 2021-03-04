using Corrientazo.Componentes.ImportarExportar.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Corrientazo.Componentes.ImportarExportar.Implementacion
{
    public class ExportadorDeRegistrosTxt: IExportadorDeRegistros
    {
        public async Task ExportarRegistros(List<string> exportados,string rutaArchivo)
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    foreach (var item in exportados)
                    {
                        await tw.WriteLineAsync(item);
                    }
                }
            }
        }

    }
}
