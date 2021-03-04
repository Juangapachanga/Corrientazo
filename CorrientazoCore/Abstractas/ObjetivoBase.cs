using System;
using System.Collections.Generic;
using System.Text;
using Corrientazo.Core.Enumeraciones;

namespace Corrientazo.Core.Abstractas
{
    public abstract class ObjetivoBase<T>
    {
        public abstract T calculaCoordenadaFinal(T coordenadaInicial, string instruccion);

        public T coordenadaFinal;

        public EstadoObjetivo estado;

    }
}
