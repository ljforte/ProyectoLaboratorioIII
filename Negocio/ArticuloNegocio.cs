using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using static System.Net.Mime.MediaTypeNames;
using System.Data;



namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            Stock st = new Stock();
            try
            {
                // Consulta SQL
                datos.SetearConsulta(@"
                            SELECT * FROM ListarArticulos");

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.lector["Id"];
                    aux.Codigo = (string)datos.lector["Codigo"];
                    aux.Nombre = (string)datos.lector["Nombre"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    aux.Precio = (int)datos.lector["Precio"];
                    aux.Estado = (bool)datos.lector["Estado"];

                    // Asignar Marca
                    aux.MarcasCls = new Marcas();
                    aux.MarcasCls.nombre = (string)datos.lector["Marca"];

                    // Asignar Categoria
                    aux.CategoriasCls = new Categorias();
                    aux.CategoriasCls.nombre = (string)datos.lector["Categoria"];

                    // Asignar Imagen
                    aux.Imagen = new ArtImg();
                    aux.Imagen.ImagenUrl = datos.lector["Imagen"].ToString();

                    // Asignar Proveedor
                    aux.ProveedorCls = new Proveedor();
                    aux.ProveedorCls.id_proveedor = (int)datos.lector["id_proveedor"];
                    aux.ProveedorCls.nombre = (string)datos.lector["ProveedorNombre"];

                    // Agregar a la lista
                    lista.Add(aux);
                }
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en la base de datos: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error: {ex.Message}", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void AgregarImagen(ArtImg Imagen, Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            string urlImagen = string.IsNullOrEmpty(Imagen.ImagenUrl) ? "https://thumbs.dreamstime.com/b/cinta-defectuosa-signo-de-la-banda-grifo-banner-defecto-189768085.jpg" : Imagen.ImagenUrl;

            try
            {
                datos.comando.Parameters.Clear();

                // Verificar si la imagen ya existe
                datos.SetearConsulta("SELECT COUNT(*) FROM IMAGENES WHERE IdArticulo = @IdArticulo AND ImagenUrl = @Url");
                datos.setearParametro("@IdArticulo", ConsultarId(art));
                datos.setearParametro("@Url", Imagen.ImagenUrl);

                if ((int)datos.EjecutarEscalar() == 0)
                {
                    datos.comando.Parameters.Clear();

                    datos.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @Url)");
                    datos.setearParametro("@IdArticulo", ConsultarId(art));
                    datos.setearParametro("@Url", Imagen.ImagenUrl);
                    datos.EjecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar imagen.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public int ConsultarId(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            int id = 0;

            try
            {
                datos.SetearConsulta("select Id from ARTICULOS where Codigo = @Codigo");
                datos.setearParametro("@Codigo", art.Codigo);

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    id = (int)datos.lector["Id"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar ID del artículo.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return id;
        }

        public void Agregar(Articulo art, ArtImg img, Stock st)
        {
            AccesoDatos datos = new AccesoDatos();
            StockNegocio stNeg = new StockNegocio();
            try
            {
                datos.setearProcedimiento("InsertarArticulo");

                datos.setearParametro("@Codigo", art.Codigo);
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@IdMarca", art.MarcasCls.Id);
                datos.setearParametro("@IdCategoria", art.CategoriasCls.Id);
                datos.setearParametro("@Estado", art.Estado);

                SqlParameter parametroIdArticulo = new SqlParameter("@ArticuloId", SqlDbType.Int);
                parametroIdArticulo.Direction = ParameterDirection.Output;
                datos.comando.Parameters.Add(parametroIdArticulo);

                datos.EjecutarAccion();

                int articuloId = (int)parametroIdArticulo.Value;

                img.IdArticulo = articuloId;
                st.id_producto = articuloId;

                AgregarImagen(img, art);

                
                stNeg.Agregar(st);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el artículo: {ex.Message}\nDetalles: {ex.StackTrace}", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public void Eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("EXEC EliminarProducto @Id");
                datos.setearParametro("@Id", Id);  
                datos.EjecutarAccion();  

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error eliminando el articulo: " + ex.Message);
            }
        }

        public void Modificar(Articulo articulo, ArtImg img, Stock st)
        {
            AccesoDatos Datos = new AccesoDatos();
            StockNegocio stNeg = new StockNegocio();
            try
            {                
                Datos.comando.Parameters.Clear();

                
                Datos.SetearConsulta("UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, " +
                                      "IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @precio WHERE Id = @id");

                Datos.setearParametro("@codigo", articulo.Codigo);
                Datos.setearParametro("@nombre", articulo.Nombre);
                Datos.setearParametro("@descripcion", articulo.Descripcion);
                Datos.setearParametro("@IdMarca", articulo.MarcasCls.Id);
                Datos.setearParametro("@IdCategoria", articulo.CategoriasCls.Id);
                Datos.setearParametro("@precio", articulo.Precio);
                Datos.setearParametro("@id", articulo.Id);

                Datos.EjecutarAccion();

                AgregarImagen(img, articulo);                
                stNeg.Modificar(st);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar artículo.", ex);
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("spFiltrarArticulos");
                datos.setearParametro("@Campo", campo);
                datos.setearParametro("@Criterio", criterio);
                datos.setearParametro("@Filtro", filtro);
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo
                    {
                        Codigo = (string)datos.lector["Codigo"],
                        Id = (int)datos.lector["Id"],
                        Nombre = (string)datos.lector["Nombre"],
                        Descripcion = (string)datos.lector["Descripcion"],
                        Precio = (decimal)datos.lector["Precio"],
                        MarcasCls = new Marcas
                        {
                            Id = datos.lector["IdMarca"] as int? ?? 0,
                            nombre = datos.lector["MarcaDescripcion"] as string
                        },
                        CategoriasCls = new Categorias
                        {
                            Id = datos.lector["IdCategoria"] as int? ?? 0,
                            nombre = datos.lector["CategoriaDescripcion"] as string
                        },
                        Imagen = new ArtImg
                        {
                            ImagenUrl = datos.lector["Imagen"] as string
                        }
                    };
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void bajaLogica(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_BajaLogicaProducto");  
                datos.setearParametro("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
    }
}
