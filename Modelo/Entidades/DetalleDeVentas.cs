using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class DetalleDeVentas
    {
        public Productos Producto { get; set; }
        public Ventas Venta { get; set; }
    }
}
