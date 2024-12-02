using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Negocio
{
    public class StockNegocio
    {
        // Método para listar todos los registros de stock
        public List<Stock> Listar()
        {
            List<Stock> stocks = new List<Stock>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Consulta para obtener todos los stocks
                datos.SetearConsulta("SELECT st.id, st.id_producto, st.id_sitio, st.stock, s.Nombre AS SitioNombre " +
                                     "FROM STOCK st " +
                                     "INNER JOIN SITIO s ON st.id_sitio = s.id_sitio");
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Stock stock = new Stock
                    {
                        id = (int)datos.lector["id"],
                        id_producto = (int)datos.lector["id_producto"],
                        stock = (int)datos.lector["stock"],
                        sitio = new Sitio
                        {
                            Id_Sitio = (int)datos.lector["id_sitio"],
                            Nombre = (string)datos.lector["SitioNombre"]
                        }
                    };

                    stocks.Add(stock);
                }

                return stocks;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar el stock.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // Método para modificar un registro de stock
        public void Modificar(Stock stock)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE STOCK SET stock = @stock WHERE id_producto = @id_producto AND id_sitio = @id_sitio");
                datos.setearParametro("@id_producto", stock.id_producto);
                datos.setearParametro("@id_sitio", stock.sitio.Id_Sitio); 
                datos.setearParametro("@stock", stock.stock);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el stock.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // Método para eliminar un registro de stock por ID
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Consulta para eliminar el stock por ID
                datos.SetearConsulta("DELETE FROM STOCK WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el stock.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // Método para buscar un stock por ID
        public Stock BuscarStockPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Stock stock = null;

            try
            {
                // Consulta para obtener un registro de stock por ID
                datos.SetearConsulta("SELECT st.id, st.id_producto, st.id_sitio, st.stock, s.Nombre AS SitioNombre " +
                                     "FROM STOCK st " +
                                     "INNER JOIN SITIO s ON st.id_sitio = s.id_sitio " +
                                     "WHERE st.id = @id");
                datos.setearParametro("@id", id);
                datos.EjecutarLectura();

                if (datos.lector.Read())
                {
                    stock = new Stock
                    {
                        id = (int)datos.lector["id"],
                        id_producto = (int)datos.lector["id_producto"],
                        stock = (int)datos.lector["stock"],
                        sitio = new Sitio
                        {
                            Id_Sitio = (int)datos.lector["id_sitio"],
                            Nombre = (string)datos.lector["SitioNombre"]
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el stock por ID.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return stock;
        }

        // Método para obtener el stock total de un producto por su id
        public int ObtenerStockTotalPorProducto(int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            int totalStock = 0;

            try
            {
                // Consulta para obtener la suma total del stock para un id_producto
                datos.SetearConsulta("SELECT SUM(stock) AS TotalStock FROM STOCK WHERE id_producto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);

                // Ejecutar la consulta y leer el resultado
                datos.EjecutarLectura();

                if (datos.lector.Read())
                {
                    // Si hay resultado, obtener el total del stock
                    totalStock = datos.lector.IsDBNull(0) ? 0 : (int)datos.lector["TotalStock"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el stock total por producto.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return totalStock;
        }

        public void Agregar(Stock stock)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Consulta para insertar un nuevo registro en la tabla STOCK
                datos.SetearConsulta("INSERT INTO STOCK (id_producto, id_sitio, stock) VALUES (@id_producto, @id_sitio, @stock)");
                datos.setearParametro("@id_producto", stock.id_producto);
                datos.setearParametro("@id_sitio", stock.sitio.Id_Sitio);
                datos.setearParametro("@stock", stock.stock);

                // Ejecutar la acción para insertar
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el stock.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public bool ExisteRelacionStock(Stock stock)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Consulta SQL para verificar si ya existe la relación entre id_producto e id_sitio
                datos.SetearConsulta("SELECT COUNT(*) FROM STOCK WHERE id_producto = @id_producto AND id_sitio = @id_sitio");
                datos.setearParametro("@id_producto", stock.id_producto);
                datos.setearParametro("@id_sitio", stock.sitio.Id_Sitio);

                datos.EjecutarLectura();

                return datos.lector.Read();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia de la relación en stock.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int ObtenerSitioConMasStock(int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            int idSitioConMasStock = -1;

            try
            {
                // Consulta SQL para obtener el id_sitio con la mayor cantidad de stock para el producto especificado
                datos.SetearConsulta(
                    "SELECT TOP 1 id_sitio " +
                    "FROM STOCK " +
                    "WHERE id_producto = @id_producto " +
                    "ORDER BY stock DESC"
                );

                datos.setearParametro("@id_producto", idProducto);

                datos.EjecutarLectura();

                // Si hay un resultado, extrae el id_sitio con mayor stock
                if (datos.lector.Read())
                {
                    idSitioConMasStock = (int)datos.lector["id_sitio"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el sitio con más stock para el producto especificado.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return idSitioConMasStock;
        }


        public int ObtenerStockPorProductoYSitio(int idProducto, int idSitio)
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidadStock = 0;

            try
            {
                // Consulta SQL para obtener la cantidad de stock de un producto en un sitio específico
                datos.SetearConsulta(
                    "SELECT stock " +
                    "FROM STOCK " +
                    "WHERE id_producto = @id_producto AND id_sitio = @id_sitio"
                );

                datos.setearParametro("@id_producto", idProducto);
                datos.setearParametro("@id_sitio", idSitio);

                datos.EjecutarLectura();

                // Si se encuentra un resultado, asigna la cantidad de stock
                if (datos.lector.Read())
                {
                    cantidadStock = (int)datos.lector["stock"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la cantidad de stock para el producto y sitio especificados.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return cantidadStock;
        }
    }
}
