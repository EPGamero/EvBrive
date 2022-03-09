using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Productos
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Existencia { get; set; }
        public Proveedores Proveedor { get; set; }
        public Categorias Categoria { get; set; }
    }
}
