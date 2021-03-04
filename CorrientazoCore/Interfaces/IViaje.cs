using Corrientazo.Data;

namespace Corrientazo.Core.Interfaces

{
    public interface IViaje<T>
    {
        T coordenadaInicial { get; set; }
        T coordenadaFinal { get; set; }
        Entrega entrega { get; set; }
        T calcularCoordenadaFinal();
    }
}
