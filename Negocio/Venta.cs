using Modelo;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class Venta
    {
        public static Respuesta<Ventas> Add(Ventas venta, List<int> productos)
        {
            Respuesta<Ventas> respuesta = new Respuesta<Ventas>();
            try
            {
                using (SqlConnection contex = new SqlConnection(Conexion.Conexion.ConnectionString()))
                {
                    string queryVenta = "AddVenta";


                    SqlCommand cmd = Conexion.Conexion.CreateCommand(queryVenta, contex);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Identity", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@Total", venta.Total);
                    cmd.Parameters.AddWithValue("@Cliente", venta.Cliente.idCliente);

                    int RowsAffected = Conexion.Conexion.ExecuteCommand(cmd);
                    int idVenta = (int)cmd.Parameters["@Identity"].Value; 

                    if (RowsAffected >= 1)
                    {
                        contex.Close();
                        respuesta.Codigo = 200;
                        respuesta.Mensaje = "Venta realizada exitosamente";
                        respuesta.Datos = new Ventas();

                        foreach(int producto in productos)
                        {
                            string queryDetalleDeVenta = "AddDetalleDeVenta";
                            SqlCommand cmdDV = Conexion.Conexion.CreateCommand(queryDetalleDeVenta, contex);
                            cmdDV.CommandType = CommandType.StoredProcedure;
                            cmdDV.Parameters.AddWithValue("@Producto", producto);
                            cmdDV.Parameters.AddWithValue("@Venta", idVenta);

                            int RowsAffectedDV = Conexion.Conexion.ExecuteCommand(cmdDV);
                            if(RowsAffected >= 1)
                            {
                                contex.Close();
                                respuesta.Codigo = 200;
                                respuesta.Mensaje = "Venta y detalle de la venta realizada exitosamente";
                                respuesta.Datos = new Ventas();

                                string queryExistenciaProducto = "UpdateExistenciaProducto";
                                SqlCommand cmdEP = Conexion.Conexion.CreateCommand(queryExistenciaProducto, contex);
                                cmdEP.CommandType = CommandType.StoredProcedure;
                                cmdEP.Parameters.AddWithValue("@idProducto", producto);

                                int RowsAffectedEP = Conexion.Conexion.ExecuteCommand(cmdEP);
                                if (RowsAffectedEP >= 1)
                                {
                                    contex.Close();
                                    respuesta.Codigo = 200;
                                    respuesta.Mensaje = "Venta y actualización del inventario generados exitosamente ";
                                    respuesta.Datos = new Ventas();
                                }
                                else
                                {
                                    respuesta.Codigo = 400;
                                    respuesta.Mensaje = "Se realizo la venta y el detalle de esta sin embargo hubo problema con la actualización del inventario";
                                    respuesta.Datos = new Ventas();
                                }
                            }
                            else
                            {
                                respuesta.Codigo = 400;
                                respuesta.Mensaje = "Se realizo la venta, sin embargo hubo un problema con el detalle de la venta";
                                respuesta.Datos = new Ventas();
                            }
                        }
                        return respuesta;
                    }
                    else
                    {
                        respuesta.Codigo = 400;
                        respuesta.Mensaje = "No se puedo realizar la venta";
                        respuesta.Datos = new Ventas();
                        return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Mensaje = ex.Message;
                respuesta.Datos = new Ventas();
                return respuesta;
            }
        }
    }
}
