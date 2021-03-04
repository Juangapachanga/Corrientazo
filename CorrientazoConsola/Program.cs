using Corrientazo.Core;
using Corrientazo.Data;
using Corrientazo.Data.Enumeraciones;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrientazoConsola
{
    class Program
    {
        private static string rutaBase;
        private static int maximosViajesPorDron;
        private static int maximoNumeroDeCuadras;
        private static int maximoDrones;
        private static List<string> nombres = new List<string>();
        private static List<Dron> drones = new List<Dron>();

        public Program()
        {

        }

        public static async System.Threading.Tasks.Task Main(string[] args)
        {

            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bienvenido a Su Corrientazo a Domicilio");
                Console.WriteLine();
                AlistaFormulario();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}.");
                Console.WriteLine($"Por favor revise todos los parámtros de la aplicación e intente de nuevo. Presione una tecla para salir.");
                Console.ReadLine();
                Environment.Exit(-1);
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Los parámetros actuales para la ejecución son: ");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Número de drones: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{maximoDrones}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Ruta base: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{rutaBase}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Máximo número de entregas por dron: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{maximosViajesPorDron}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Máximo número de cuadras a la redonda: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{maximoNumeroDeCuadras}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Si desea, puede cambiar estos valores en el archivo Appsettings.json en la ruta de la aplicación.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("¿Desea continuar? Sí:S / No:N");
            bool siga = Console.ReadLine().ToUpper() == "S";

            StringBuilder fallidos = new StringBuilder();

            while (siga)
            {
                //REINICIA VARIABLES PARA UN DIA NUEVO
                Console.ForegroundColor = ConsoleColor.Green;
                //gi = new GeneradorDeInformeCartesiano(rutaBase);
                //vc = new CalculadorDeViajeCartesiano();
                fallidos = new StringBuilder();
                
                //BORRA CARPETA DE RESULTADOS
                Parallel.ForEach(Directory.GetFiles($"{rutaBase}\\OUT\\", "*.txt"), (archivo) =>
                {
                    File.Delete(archivo);
                });

                //GENERA LAS RUTAS DE TODOS LOS DRONES
                GeneradorDeInformeCartesiano gi = new GeneradorDeInformeCartesiano(rutaBase);
                IEnumerable<List<Entrega>> v = await GeneradorDeRuta.GenerarRutasAsync(nombres);
                int contador = 0;
                foreach (List<Entrega> r in v)
                {
                    drones[contador].ruta = r;
                    contador++;
                }

                Parallel.ForEach((drones),d1=>
                {
                    CalculadorDeViajeCartesiano vc = new CalculadorDeViajeCartesiano();
                    vc.coordenadaInicial = new CoordenadaCartesiana(0, 0, maximoNumeroDeCuadras, PuntosCardinales.Norte);
                    gi = new GeneradorDeInformeCartesiano(rutaBase);
                    d1.estado = EstadoBasicoVehiculo.Ocupado;
                    try
                      {
                          List<CoordenadaCartesiana> objetivosx = new List<CoordenadaCartesiana>();
                          foreach (Entrega e in d1.ruta.Take(maximosViajesPorDron))
                          {
                              vc.entrega = e;
                              vc.coordenadaInicial = vc.calcularCoordenadaFinal();
                              objetivosx.Add(vc.coordenadaInicial);
                            }
                          d1.objetivos = objetivosx;
                          gi.GenerarInforme(d1);
                          d1.estado = EstadoBasicoVehiculo.Disponible;
                          
                          Console.WriteLine($"Dron {d1.nombre}:OK ");
                      }
                      catch (Exception ex)
                      {
                        fallidos.Append($"Dron {d1.nombre}: {ex.Message} .");
                      }
                  });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Finalizado");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Drones Fallidos: {fallidos.ToString()}");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string salida=string.Empty;
                while (salida==string.Empty)
                {
                    Console.WriteLine("¿Desea realizar otro viaje? Sí:S / No:N");
                    salida = Console.ReadLine().ToUpper();
                    if (salida=="S")
                    {
                        siga = true;
                    }else if (salida == "N")
                    {
                        siga = false;
                    }else
                    {
                        salida = string.Empty;
                    }
                    
                }
              
             }
            Environment.Exit(-1);
        }

        /// <summary>
        /// Carga variables de aplicación, crea elementos globales.
        /// </summary>
        public static void AlistaFormulario()
        {

            try
            {
                //CARGA VARIABLE DE APP
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("AppSettings.json", optional: false);

                IConfiguration config = builder.Build();
                int aux = 0;

                rutaBase = config.GetSection("AppSettings").GetSection("RutaBase").Value;
                maximosViajesPorDron = int.TryParse(config.GetSection("AppSettings").GetSection("MaximosViajesPorDron").Value, out aux) == true ? aux : 3;
                maximoNumeroDeCuadras = int.TryParse(config.GetSection("AppSettings").GetSection("MaximoNumeroDeCuadras").Value, out aux) == true ? aux : 10;
                maximoDrones = int.TryParse(config.GetSection("AppSettings").GetSection("MaximoDrones").Value, out aux) == true ? aux : 20;

                //CREA ELEMENTOS
                Dron d = new Dron();
                for (int i = 0; i < maximoDrones; i++)
                {
                    d = new Dron();
                    d.nombre = (i+1).ToString();
                    nombres.Add((i+1).ToString());
                    drones.Add(d);
                }
            }
            catch (Exception)
            {
                throw new Exception("Ha ocurrido un error al alistar la aplicación.");
            }
            

        }
    }
}
