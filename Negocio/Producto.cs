using Modelo;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace Negocio
{
    public class Producto
    {
        public static Respuesta<List<Productos>> GetAll()
        {
            Respuesta<List<Productos>> respuesta = new Respuesta<List<Productos>>();

            try
            {

                using (SqlConnection contex = new SqlConnection(Conexion.Conexion.ConnectionString()))
                {
                    string Query = "GetProductos";


                    SqlCommand cmd = Conexion.Conexion.CreateCommand(Query, contex);
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable productos = Conexion.Conexion.ExecuteCommandSelect(cmd);


                    if (productos.Rows.Count >= 1)
                    {
                        respuesta.Codigo = 200;
                        respuesta.Mensaje = "Productos Existentes";
                        respuesta.Datos = new List<Productos>();
                        foreach (DataRow row in productos.Rows)
                        {
                            Productos productoItem = new Productos();
                            productoItem.idProducto = Convert.ToInt32(row[0]);
                            productoItem.Nombre = row[1].ToString();
                            productoItem.Precio = (float)Convert.ToDouble(row[2]);
                            productoItem.Descripcion = row[3].ToString();
                            productoItem.Marca = row[4].ToString();
                            productoItem.Existencia = Convert.ToInt32(row[5]);

                            productoItem.Proveedor = new Proveedores();
                            productoItem.Proveedor.idProveedor = Convert.ToInt32(row[6]);

                            productoItem.Categoria = new Categorias();
                            productoItem.Categoria.idCategoria = Convert.ToInt32(row[7]);

                            respuesta.Datos.Add(productoItem);
                        }
                        return respuesta;
                    }
                    else
                    {
                        respuesta.Codigo = 400;
                        respuesta.Mensaje = "Sin productos en existencia";
                        respuesta.Datos = new List<Productos>();

                        return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Mensaje = ex.Message;
                respuesta.Datos = new List<Productos>();

                return respuesta;
            }

        }
        public static Respuesta<List<Productos>> GetById(Productos producto)
        {
            Respuesta<List<Productos>> respuesta = new Respuesta<List<Productos>>();

            try
            {

                using (SqlConnection contex = new SqlConnection(Conexion.Conexion.ConnectionString()))
                {
                    string Query = "GetProductosById";


                    SqlCommand cmd = Conexion.Conexion.CreateCommand(Query, contex);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProducto", producto.idProducto);

                    DataTable productoI = Conexion.Conexion.ExecuteCommandSelect(cmd);


                    if (productoI.Rows.Count >= 1)
                    {
                        respuesta.Codigo = 200;
                        respuesta.Mensaje = "Producto encontrado";
                        respuesta.Datos = new List<Productos>();
                        foreach (DataRow row in productoI.Rows)
                        {
                            Productos productoItem = new Productos();
                            productoItem.idProducto = Convert.ToInt32(row[0]);
                            productoItem.Nombre = row[1].ToString();
                            productoItem.Precio = (float)Convert.ToDouble(row[2]);
                            productoItem.Descripcion = row[3].ToString();
                            productoItem.Marca = row[4].ToString();
                            productoItem.Existencia = Convert.ToInt32(row[5]);

                            productoItem.Proveedor = new Proveedores();
                            productoItem.Proveedor.idProveedor = Convert.ToInt32(row[6]);

                            productoItem.Categoria = new Categorias();
                            productoItem.Categoria.idCategoria = Convert.ToInt32(row[7]);

                            respuesta.Datos.Add(productoItem);
                        }
                        return respuesta;
                    }
                    else
                    {
                        respuesta.Codigo = 400;
                        respuesta.Mensaje = "Producto no existente";
                        respuesta.Datos = new List<Productos>();

                        return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Mensaje = ex.Message;
                respuesta.Datos = new List<Productos>();

                return respuesta;
            }
        }
        public static Respuesta<Productos> Add(Productos producto)
        {
            Respuesta<Productos> respuesta = new Respuesta<Productos>();
            try
            {
                using (SqlConnection contex = new SqlConnection(Conexion.Conexion.ConnectionString()))
                {
                    string Query = "AddProducto";


                    SqlCommand cmd = Conexion.Conexion.CreateCommand(Query, contex);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                    cmd.Parameters.AddWithValue("@Proveedor", producto.Proveedor.idProveedor);
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria.idCategoria);

                    int RowsAffected = Conexion.Conexion.ExecuteCommand(cmd);

                    if (RowsAffected >= 1)
                    {
                        respuesta.Codigo = 200;
                        respuesta.Mensaje = "Producto agregado en el inventario correctamente";
                        respuesta.Datos = new Productos();
                        return respuesta;
                    }
                    else
                    {
                        respuesta.Codigo = 400;
                        respuesta.Mensaje = "No se puedo agregar el producto";
                        respuesta.Datos = new Productos();
                        return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Mensaje = ex.Message;
                respuesta.Datos = new Productos();
                return respuesta;
            }
        }
        public static Respuesta<Productos> Update(Productos producto)
        {
            Respuesta<Productos> respuesta = new Respuesta<Productos>();
            try
            {
                using (SqlConnection contex = new SqlConnection(Conexion.Conexion.ConnectionString()))
                {
                    string Query = "UpdateProducto";


                    SqlCommand cmd = Conexion.Conexion.CreateCommand(Query, contex);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProducto", producto.idProducto);
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@Marca", producto.Marca);
                    cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);
                    cmd.Parameters.AddWithValue("@Proveedor", producto.Proveedor.idProveedor);
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria.idCategoria);

                    int RowsAffected = Conexion.Conexion.ExecuteCommand(cmd);

                    if (RowsAffected >= 1)
                    {
                        respuesta.Codigo = 200;
                        respuesta.Mensaje = "Producto actualizado correctamente";
                        respuesta.Datos = new Productos();
                        return respuesta;
                    }
                    else
                    {
                        respuesta.Codigo = 400;
                        respuesta.Mensaje = "No se puedo actualizar el producto";
                        respuesta.Datos = new Productos();
                        return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Mensaje = ex.Message;
                respuesta.Datos = new Productos();
                return respuesta;
            }
        }
        public static Respuesta<Productos> Delete(Productos producto)
        {
            Respuesta<Productos> respuesta = new Respuesta<Productos>();
            try
            {
                using (SqlConnection contex = new SqlConnection(Conexion.Conexion.ConnectionString()))
                {
                    string Query = "DeleteProducto";


                    SqlCommand cmd = Conexion.Conexion.CreateCommand(Query, contex);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProducto", producto.idProducto);
                    int RowsAffected = Conexion.Conexion.ExecuteCommand(cmd);

                    if (RowsAffected >= 1)
                    {
                        respuesta.Codigo = 200;
                        respuesta.Mensaje = "Producto eliminado correctamente";
                        respuesta.Datos = new Productos();
                        return respuesta;
                    }
                    else
                    {
                        respuesta.Codigo = 400;
                        respuesta.Mensaje = "No se puedo eliminar el producto";
                        respuesta.Datos = new Productos();
                        return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Mensaje = ex.Message;
                respuesta.Datos = new Productos();
                return respuesta;
            }
        }
    }
}
