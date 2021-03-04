using Corrientazo.Data;
using System.Collections.Generic;

namespace Corrientazo.Core.Interfaces
{
    public interface IGeneradorDeRuta
    {
        List<Entrega> GenerarRuta();
    }
}
