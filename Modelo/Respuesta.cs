using System;

namespace Modelo
{
    public class Respuesta <T>
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
    }
}
