using Corrientazo.Componentes.ImportarExportar.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Corrientazo.Componentes.ImportarExportar.Core
{
    /// <summary>
    /// Importa registros desde un archivo txt.
    /// </summary>
    public class ImportadorDeRegistrosTxt : IImportadorDeRegistros
    {

        public async Task<List<string>> ImportarRegistros(string filePath)
        {
            List<string> registrosImportados = new List<string>();
            string linea;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (TextReader tr = new StreamReader(fs))
                {
                    while ((linea = tr.ReadLine()) != null)
                    {
                        registrosImportados.Add(linea);
                    }
                }
                return registrosImportados;
            }
        }
    }
}