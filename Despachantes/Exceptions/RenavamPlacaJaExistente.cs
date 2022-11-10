using Google.Protobuf.Reflection;
using System;

namespace Despachantes.Exceptions
{
    [Serializable]
    public class RenavamPlacaJaExistente : Exception
    {
        public RenavamPlacaJaExistente(){}

        public RenavamPlacaJaExistente(string message): base(message){}  

    }
}
