using Corrientazo.Data.Comunes;
using System.Collections.Generic;

namespace Corrientazo.Logica.ImportadorExportador
{
    /// <summary>
    /// Capa lógica para cargar rutas desde líneas de archivo de texto. ESe aprovecha para generar formatos, concatenar textos, etc.
    /// </summary>
    public class ExportadorObjetivos : Exportador<Objetivo>
    {

        public override List<string> ConvierteRegistros(List<Objetivo> exportados)
        {
            string nuevoRegistro;
            List<string> registrosConvertidos = new List<string>();
            int contador = 1;
            foreach (Objetivo registro in exportados)
            {
                nuevoRegistro = $"({registro.x},{registro.y}) dirección {registro.orientacion}";
                contador++;
                registrosConvertidos.Add(nuevoRegistro);
            }
            return registrosConvertidos;
        }

    }
}