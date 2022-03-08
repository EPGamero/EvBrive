using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Ventas
    {
        public int idVenta { get; set; }
        public float Total { get; set; }
        public DateTime Fecha { get; set; }
        public Clientes Cliente { get; set; }
    }
}
