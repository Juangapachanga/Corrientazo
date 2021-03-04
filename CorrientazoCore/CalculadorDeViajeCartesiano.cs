using System;
using System.Collections.Generic;
using System.Text;
using Corrientazo.Core.Abstractas;
using Corrientazo.Data.Enumeraciones;
using Corrientazo.Core.Interfaces;
using Corrientazo.Data;

namespace Corrientazo.Core
{
    /// <summary>
    /// Calcula la coordenada final luego de realizar un viaje con los datos de la coordenada inicial e instrucciones de la entrega.
    /// </summary>
    public class CalculadorDeViajeCartesiano : IViaje<CoordenadaCartesiana>
    {
        public CoordenadaCartesiana coordenadaInicial { get; set; }
        public CoordenadaCartesiana coordenadaFinal { get; set; }
        public Entrega entrega { get; set; }

        public CoordenadaCartesiana calcularCoordenadaFinal()
        {
            coordenadaFinal = new CoordenadaCartesiana(coordenadaInicial.x, coordenadaInicial.y, coordenadaInicial.max, coordenadaInicial.orientacion);

            char[] pasos = entrega.movimientos.ToCharArray();

            foreach (char c in pasos)
            {
                switch (c)
                {
                    case 'A':
                        switch (coordenadaFinal.orientacion)
                        {
                            case PuntosCardinales.Norte:
                                coordenadaFinal.y++;
                                break;
                            case PuntosCardinales.Sur:
                                coordenadaFinal.y--;
                                break;
                            case PuntosCardinales.Oriente:
                                coordenadaFinal.x++;
                                break;
                            case PuntosCardinales.Occidente:
                                coordenadaFinal.x--;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 'D':
                        switch (coordenadaFinal.orientacion)
                        {
                            case PuntosCardinales.Norte:
                                coordenadaFinal.orientacion = PuntosCardinales.Oriente;
                                break;
                            case PuntosCardinales.Sur:
                                coordenadaFinal.orientacion = PuntosCardinales.Occidente;
                                break;
                            case PuntosCardinales.Oriente:
                                coordenadaFinal.orientacion = PuntosCardinales.Sur;
                                break;
                            case PuntosCardinales.Occidente:
                                coordenadaFinal.orientacion = PuntosCardinales.Norte;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 'I':
                        switch (coordenadaFinal.orientacion)
                        {
                            case PuntosCardinales.Norte:
                                coordenadaFinal.orientacion = PuntosCardinales.Occidente;
                                break;
                            case PuntosCardinales.Sur:
                                coordenadaFinal.orientacion = PuntosCardinales.Oriente;
                                break;
                            case PuntosCardinales.Oriente:
                                coordenadaFinal.orientacion = PuntosCardinales.Norte;
                                break;
                            case PuntosCardinales.Occidente:
                                coordenadaFinal.orientacion = PuntosCardinales.Sur;
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }

            return coordenadaFinal;
        }

    }
}
