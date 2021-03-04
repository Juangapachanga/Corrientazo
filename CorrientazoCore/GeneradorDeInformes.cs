using System;
using System.Collections.Generic;
using System.Text;
using Corrientazo.Core.Interfaces;
using Corrientazo.Logica.ImportadorExportador;
using Corrientazo.Data.Comunes;

namespace Corrientazo.Core
{
     public class GeneradorDeInformeCartesiano : GeneradorDeInformeBase<CoordenadaCartesiana>
    {

        public GeneradorDeInformeCartesiano(string rutaBase)
        {
            GeneradorDeInformeBase<CoordenadaCartesiana>.rutaBase = rutaBase;
        }

        public override void GenerarInforme(IVehiculo vehiculo)
        {
            //ESCRIBE ARCHIVO CON LOS OBJETIVOS ALCANZADOS
            ExportadorObjetivos exportadorObjetivos = new ExportadorObjetivos();
            List<Objetivo> objetivos = new List<Objetivo>();
            Objetivo o = new Objetivo();
            foreach (CoordenadaCartesiana item in vehiculo.objetivos)
            {
                o = new Objetivo();
                o.x = item.x;
                o.y = item.y;
                o.orientacion = item.orientacion;
                objetivos.Add(o);
            }
            List<string> exportados = exportadorObjetivos.ConvierteRegistros(objetivos);
            exportadorObjetivos.Exportar(exportados, $"{rutaBase}\\OUT\\out{vehiculo.nombre.PadLeft(2, '0')}.txt");
        }
    }
}