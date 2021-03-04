using System;
using System.Collections.Generic;
using Corrientazo.Componentes.ImportarExportar;
using Corrientazo.Logica.ImportadorExportador.Importadores;
using Corrientazo.Data;

namespace Corrientazo.Logica.ImportadorExportador
{
    /// <summary>
    /// Capa lógica para cargar rutas desde líneas de archivo de texto
    /// </summary>
    public class ImportadorRutas : Importador<Entrega>
    {
        public override List<Entrega> ConvierteRegistros()
        {
            Entrega nuevoRegistro;
            List<Entrega> registrosConvertidos = new List<Entrega>();
            int contador = 1;
            foreach (string registro in importados)
            {
                nuevoRegistro = new Entrega();
                nuevoRegistro.movimientos = registro.Replace("DDD", "I").Replace("III", "D").Replace("IIII", "").Replace("DDDD", "");
                contador++;
                registrosConvertidos.Add(nuevoRegistro);
            }
            return registrosConvertidos;
        }
    }
}