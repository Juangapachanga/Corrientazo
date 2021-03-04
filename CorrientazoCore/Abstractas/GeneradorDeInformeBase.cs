using System.Collections.Generic;
using Corrientazo.Core.Abstractas;

namespace Corrientazo.Core.Interfaces
{
    public abstract class GeneradorDeInformeBase<T>:ArchivoBase
    {
        List<T> objetivos = new List<T>();

        public abstract void GenerarInforme(IVehiculo vehiculo);
    }
}