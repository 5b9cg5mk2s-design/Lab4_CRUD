using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Labb4Productos
{
    public class Conexion : IProductoRepository
    {
        private static string cadenaConexion = "Server=localhost;Database=productosdb;Uid=root;Pwd=Aqrt.234#@;";

        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error crítico de infraestructura: " + ex.Message);
                return null;
            }
        }

        // CREATE: Uso de Diccionarios y control riguroso de parámetros
        public bool Insertar(Dictionary<string, object> data)
        {
            var columns = string.Join(", ", data.Keys);
            var placeholders = "@" + string.Join(", @", data.Keys);
            string sql = $"INSERT INTO productos ({columns}) VALUES ({placeholders})";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;
                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }
                        return stmt.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Excepción controlada en inserción: " + ex.Message);
                System.Windows.Forms.MessageBox.Show("Error en inserción: " + ex.Message);
                return false;
            }
        }

        // READ: Filtra registros activos y asigna valores de auditoría y usuario
        public List<Producto> ObtenerTodos(string filtro)
        {
            List<Producto> listaProductos = new List<Producto>();
            // Importante: Filtramos para traer solo aquellos que NO estén anulados (anulado = 0)
            string query = "SELECT id, nombre, precio, cantidad, imagen, usuario, fecha_creacion, fecha_modificacion FROM productos WHERE anulado = 0";

            if (!string.IsNullOrEmpty(filtro))
            {
                query += " AND (id LIKE @filtro OR nombre LIKE @filtro OR usuario LIKE @filtro)";
            }

            try
            {
                using (MySqlConnection conn = ObtenerConexion())
                {
                    if (conn == null) return listaProductos;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        }

                        using (MySqlDataReader mReader = cmd.ExecuteReader())
                        {
                            while (mReader.Read())
                            {
                                Producto prod = new Producto
                                {
                                    Id = Convert.ToInt32(mReader["id"]),
                                    Nombre = mReader["nombre"].ToString(),
                                    Precio = Convert.ToDecimal(mReader["precio"]),
                                    Cantidad = Convert.ToInt32(mReader["cantidad"]),
                                    Imagen = mReader["imagen"] != DBNull.Value ? (byte[])mReader["imagen"] : null,
                                    Usuario = mReader["usuario"].ToString(),
                                    FechaCreacion = Convert.ToDateTime(mReader["fecha_creacion"]),
                                    FechaModificacion = Convert.ToDateTime(mReader["fecha_modificacion"])
                                };
                                listaProductos.Add(prod);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Excepción controlada en lectura: " + ex.Message);
                System.Windows.Forms.MessageBox.Show("Error en lectura de base de datos: " + ex.Message);
            }
            return listaProductos;
        }

        // UPDATE: Actualiza datos y registra de forma implícita la fecha de modificación en el servidor
        public bool Actualizar(Producto producto)
        {
            string query = "UPDATE productos SET nombre=@nombre, precio=@precio, cantidad=@cantidad, imagen=@imagen, usuario=@usuario WHERE id=@id";
            try
            {
                using (MySqlConnection conn = ObtenerConexion())
                {
                    if (conn == null) return false;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", producto.Id);
                        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                        cmd.Parameters.AddWithValue("@precio", producto.Precio);
                        cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                        cmd.Parameters.AddWithValue("@imagen", producto.Imagen ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@usuario", producto.Usuario);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Excepción controlada en actualización: " + ex.Message);
                return false;
            }
        }

        // DELETE (LÓGICO): En lugar de un DELETE físico, hacemos un UPDATE poniendo anulado = 1
        public bool Anular(int id)
        {
            string query = "UPDATE productos SET anulado = 1 WHERE id = @id";
            try
            {
                using (MySqlConnection conn = ObtenerConexion())
                {
                    if (conn == null) return false;
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Excepción controlada en eliminación lógica: " + ex.Message);
                return false;
            }
        }
    }
}


