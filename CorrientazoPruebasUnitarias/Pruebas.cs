using Corrientazo.Core;
using Corrientazo.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Corrientazo.PruebasUnitarias
{
    [TestClass]
    public class Pruebas
    {
        /// <summary>
        /// Prueba el cálculo de una coordenada válida (no se sale del máximo de cuadras).  Genera una coordenada.  Utiliza el ejemplo del enunciado, el cual, según la prueba, tiene la dirección equivocada.
        /// </summary>
        [TestMethod]
        public void TestCalculoDeCoordenada()
        {
            int maxCuadras = 8;
            string movimientosTest = "AAAAIAA";
            CalculadorDeViajeCartesiano calculadorDeViaje = new CalculadorDeViajeCartesiano();
            calculadorDeViaje.coordenadaInicial = new CoordenadaCartesiana(0, 0, maxCuadras, Data.Enumeraciones.PuntosCardinales.Norte);

            CoordenadaCartesiana coordenadaEsperada = new CoordenadaCartesiana(-2, 4, maxCuadras, Data.Enumeraciones.PuntosCardinales.Occidente);

            Entrega entregaTest = new Entrega();
            entregaTest.movimientos = movimientosTest;
            calculadorDeViaje.entrega = entregaTest;
            CoordenadaCartesiana coordenadaTest = new CoordenadaCartesiana(0, 0, maxCuadras, Data.Enumeraciones.PuntosCardinales.Norte);
            coordenadaTest = calculadorDeViaje.calcularCoordenadaFinal();
            Assert.AreEqual(coordenadaEsperada.x, coordenadaTest.x);
            Assert.AreEqual(coordenadaEsperada.y, coordenadaTest.y);
            Assert.AreEqual(coordenadaEsperada.orientacion, coordenadaTest.orientacion);
        }

        /// <summary>
        /// Prueba el cálculo de una coordenada con validación de límite de cuadras a la redonda. Genera una excepción.
        /// </summary>
        [TestMethod]
        public void TestCalculoDeCoordenadaSobreDimensionada()
        {
            int maxCuadras = 8;
            string movimientosTest = "AAAAAAAAAAAA";
            CalculadorDeViajeCartesiano calculadorDeViaje = new CalculadorDeViajeCartesiano();
            calculadorDeViaje.coordenadaInicial = new CoordenadaCartesiana(0, 0, maxCuadras, Data.Enumeraciones.PuntosCardinales.Norte);

            CoordenadaCartesiana coordenadaTest = new CoordenadaCartesiana(0, 0, maxCuadras, Data.Enumeraciones.PuntosCardinales.Norte);
            Entrega entregaTest = new Entrega();
            entregaTest.movimientos = movimientosTest;
            calculadorDeViaje.entrega = entregaTest;

            Assert.ThrowsException<Exception>(() => coordenadaTest = calculadorDeViaje.calcularCoordenadaFinal());

        }

        /// <summary>
        /// Prueba la generación de un informe de salida. Debe existir el archivo AppSettings con el parámetro de la ruta base. Utiliza su propia configuración con el Appsettings.. Genera un archivo con "(0,3) dirección Oriente".  
        /// </summary>
        [TestMethod]
        public void TestGeneracionDeInforme()
        {
            //CARGA VARIABLE DE APP
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false);

            IConfiguration config = builder.Build();

            int maximosViajesPorDron = 1;
            int maxCuadras = 8;
            string rutaBase = config.GetSection("AppSettings").GetSection("RutaBase").Value; ;
            string movimientosTest = "ADAIAD";

            Entrega entregaTest = new Entrega();
            entregaTest.movimientos = movimientosTest;
            Dron d1 = new Dron();
            d1.nombre = "1";

            List<Entrega> rutaTest = new List<Entrega>();
            rutaTest.Add(entregaTest);
            
            d1.ruta=rutaTest;
            GeneradorDeInformeCartesiano gi = new GeneradorDeInformeCartesiano(rutaBase);
            CalculadorDeViajeCartesiano calculadorDeViaje = new CalculadorDeViajeCartesiano();
            calculadorDeViaje.coordenadaInicial = new CoordenadaCartesiana(0, 0, maxCuadras, Data.Enumeraciones.PuntosCardinales.Norte);

            List<CoordenadaCartesiana> objetivosx = new List<CoordenadaCartesiana>();
            foreach (Entrega e in d1.ruta.Take(maximosViajesPorDron))
            {
                calculadorDeViaje.entrega = e;
                calculadorDeViaje.coordenadaInicial = calculadorDeViaje.calcularCoordenadaFinal();
                objetivosx.Add(calculadorDeViaje.coordenadaInicial);
            }
            d1.objetivos = objetivosx;
            gi.GenerarInforme(d1);
        }

    }
}