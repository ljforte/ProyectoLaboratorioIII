using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using static System.Net.Mime.MediaTypeNames;



namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta SQL
                datos.SetearConsulta(@"
                            SELECT 
            A.Id,
            A.Codigo, 
            A.Nombre, 
            A.Descripcion, 
            M.Descripcion AS Marca, 
            C.Descripcion AS Categoria, 
            A.Precio,
            M.Id as IdMarca,
            C.Id as IdCategoria,
            I.ImagenUrl as Imagen,
            P.Nombre AS ProveedorNombre,
            P.id_proveedor AS IdProveedor,
			s.stock as Stock
        FROM ARTICULOS AS A 
        LEFT JOIN Marcas AS M ON A.IdMarca = M.Id 
        LEFT JOIN Categorias AS C ON A.IdCategoria = C.Id
        LEFT JOIN IMAGENES AS I ON I.IdArticulo = A.Id
        LEFT JOIN Proveedor AS P ON A.id_proveedor = P.id_proveedor
		LEFT JOIN Stock as S ON A.id = S.id");

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.lector["Id"];
                    aux.Codigo = (datos.lector["Codigo"] is DBNull) ? string.Empty : (string)datos.lector["Codigo"];
                    aux.Nombre = (datos.lector["Nombre"] is DBNull) ? string.Empty : (string)datos.lector["Nombre"];
                    aux.Descripcion = (datos.lector["Descripcion"] is DBNull) ? string.Empty : (string)datos.lector["Descripcion"];
                    aux.Precio = (datos.lector["Precio"] is DBNull) ? 0 : (decimal)datos.lector["Precio"];

                    // Asignar Marca
                    aux.MarcasCls = new Marcas();
                    aux.MarcasCls.Descripcion = (datos.lector["Marca"] is DBNull) ? string.Empty : (string)datos.lector["Marca"];

                    // Asignar Categoria
                    aux.CategoriasCls = new Categorias();
                    if (!(datos.lector["IdCategoria"] is DBNull))
                        aux.CategoriasCls.Id = (int)datos.lector["IdCategoria"];
                    aux.CategoriasCls.Descripcion = (datos.lector["Categoria"] is DBNull) ? string.Empty : (string)datos.lector["Categoria"];

                    // Asignar Imagen
                    aux.Imagen = new ArtImg();
                    aux.Imagen.ImagenUrl = (datos.lector["Imagen"] is DBNull) ? string.Empty : datos.lector["Imagen"].ToString();

                    // Asignar Proveedor
                    aux.ProveedorCls = new Proveedor();
                    aux.ProveedorCls.id_proveedor = (datos.lector["IdProveedor"] is DBNull) ? 0 : (int)datos.lector["IdProveedor"];
                    aux.ProveedorCls.nombre = (datos.lector["ProveedorNombre"] is DBNull) ? "Proveedor no disponible" : (string)datos.lector["ProveedorNombre"];

                    // Asignar Stock
                    aux.StockCls = new Stock();
                    aux.StockCls.stock = (datos.lector["Stock"] is DBNull) ? 0 : (int)datos.lector["Stock"]; 

                    // Para verificación
                    Console.WriteLine("Proveedor: " + aux.ProveedorCls.nombre);

                    // Agregar a la lista
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



        public void AgregarImagen(ArtImg Imagen, Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @Url)");

                datos.setearParametro("@IdArticulo", ConsultarId(art));
                datos.setearParametro("@Url", Imagen.ImagenUrl);
                datos.EjecutarAccion();
                    
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int ConsultarId(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            int id=0;

            datos.SetearConsulta("select Id from ARTICULOS where Codigo = '" + art.Codigo + "'");

            datos.EjecutarLectura();

            while (datos.lector.Read())
            {
                id = (int)datos.lector["Id"];

            }
            return id;



        }
        public void Agregar(Articulo art, ArtImg img)
        {
            AccesoDatos datos = new AccesoDatos();
            AccesoDatos datosImagen = new AccesoDatos();
            try
            {

                datos.SetearConsulta(
                                     "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, Precio, idMarca, idCategoria) " +
                                     "VALUES (@Codigo, @Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria); "
                                     );
                // Tabla articulos
                datos.setearParametro("@Codigo", art.Codigo);
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@IdMarca", art.MarcasCls.Id);
                datos.setearParametro("@IdCategoria", art.CategoriasCls.Id);
                //Tabla imagenes, insertados en 2do insert
                datos.EjecutarAccion();

                AgregarImagen(img, art);


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

        public void Eliminar(int Id)
        {

            try
            {
                // Crear una instancia de la clase AccesoDatos para manejar las consultas
                AccesoDatos datos = new AccesoDatos();

                // Realizar la eliminación, el trigger se encargará de evitarla si hay stock
                datos.SetearConsulta("DELETE FROM ARTICULOS WHERE id = @Id");
                datos.setearParametro("@Id", Id);
                datos.EjecutarAccion();  // Si el trigger lanza un error, la ejecución se detendrá

            }
            catch (SqlException ex)
            {
                // Si ocurre un error con el trigger, lanzamos la excepción para que sea manejada en el formulario
                throw new Exception("Error al eliminar el artículo: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error: " + ex.Message);
            }

        }

        public void Modificar(Articulo articulo)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {

                Datos.SetearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria,  Precio = @precio  Where Id = @id");
                Datos.setearParametro("@codigo", articulo.Codigo);
                Datos.setearParametro("@nombre", articulo.Nombre);
                Datos.setearParametro("@descripcion", articulo.Descripcion);
                Datos.setearParametro("@IdMarca", articulo.MarcasCls.Id);
                Datos.setearParametro("@IdCategoria", articulo.CategoriasCls.Id);
                Datos.setearParametro("@precio", articulo.Precio);
                Datos.setearParametro("@id", articulo.Id);
                Datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
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
                            Descripcion = datos.lector["MarcaDescripcion"] as string
                        },
                        CategoriasCls = new Categorias
                        {
                            Id = datos.lector["IdCategoria"] as int? ?? 0,
                            Descripcion = datos.lector["CategoriaDescripcion"] as string
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


    }
}
