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
    public class ProductoNegocio
    {

        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    ListarArticulos"
                );

                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Producto aux = new Producto();
                    aux.sku = (int)datos.lector["sku"];
                    aux.Nombre = datos.lector["Nombre"] as string;
                    aux.Descripcion = datos.lector["Descripcion"] as string;
                    aux.Precio = (decimal)datos.lector["Precio"];

                    aux.MarcasCls = new Marcas
                    {
                        Id = (int)datos.lector["IdMarca"],
                        Descripcion = datos.lector["Marca"] as string
                    };

                    aux.CategoriasCls = new Categorias
                    {
                        Id = (int)datos.lector["IdCategoria"],
                        Descripcion = datos.lector["Categoria"] as string
                    };

                    aux.Imagen = new ArtImg
                    {
                        ImagenUrl = datos.lector["Imagen"] as string
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

        public void AgregarImagen(ArtImg Imagen, Producto art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO IMAGENES (IdProducto, ImagenUrl) VALUES (@IdProducto, @Url)");
                datos.setearParametro("@IdProducto", art.sku);
                datos.setearParametro("@Url", Imagen.ImagenUrl);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ConsultarId(Producto art)
        {
            AccesoDatos datos = new AccesoDatos();
            int id = 0;

            datos.SetearConsulta("SELECT sku FROM Productos WHERE Nombre = @Nombre");
            datos.setearParametro("@Nombre", art.Nombre);

            datos.EjecutarLectura();

            if (datos.lector.Read())
            {
                id = (int)datos.lector["sku"];
            }

            return id;
        }

        public void Agregar(Producto art, ArtImg img)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(
                    "INSERT INTO Productos (Nombre, Descripcion, Precio, IdMarca, IdCategoria, IdProveedor, Estado) " +
                    "VALUES (@Nombre, @Descripcion, @Precio, @IdMarca, @IdCategoria, @IdProveedor, @Estado)"
                );
                datos.setearParametro("@Nombre", art.Nombre);
                datos.setearParametro("@Descripcion", art.Descripcion);
                datos.setearParametro("@Precio", art.Precio);
                datos.setearParametro("@IdMarca", art.MarcasCls.Id);
                datos.setearParametro("@IdCategoria", art.CategoriasCls.Id);
                datos.setearParametro("@IdProveedor", art.IdProveedor);
                datos.setearParametro("@Estado", art.Estado);
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


        public void Eliminar(int sku)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM Productos WHERE sku = @sku");
                datos.setearParametro("@sku", sku);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(
                    "UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, " +
                    "IdCategoria = @IdCategoria, Precio = @Precio, IdProveedor = @IdProveedor, Estado = @Estado " +
                    "WHERE sku = @sku"
                );
                datos.setearParametro("@Nombre", producto.Nombre);
                datos.setearParametro("@Descripcion", producto.Descripcion);
                datos.setearParametro("@IdMarca", producto.MarcasCls.Id);
                datos.setearParametro("@IdCategoria", producto.CategoriasCls.Id);
                datos.setearParametro("@Precio", producto.Precio);
                datos.setearParametro("@IdProveedor", producto.IdProveedor);
                datos.setearParametro("@Estado", producto.Estado);
                datos.setearParametro("@sku", producto.sku);
                datos.EjecutarAccion();
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

        public List<Producto> filtrar(string campo, string criterio, string filtro)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"
                            SELECT
    A.sku,
    A.id_marca, 
    A.modelo AS Nombre, 
    A.id_categoria,
    A.precio,
    A.id_proveedor,
    A.estado,
    M.Descripcion AS MarcaDescripcion, 
    C.Descripcion AS CategoriaDescripcion, 
    I.ImagenUrl AS Imagen
FROM producto AS A
LEFT JOIN marcas AS M ON A.id_marca = M.Id
LEFT JOIN categorias AS C ON A.id_categoria = C.Id
LEFT JOIN imagenes AS I ON I.id_producto = A.sku
WHERE ";

                switch (campo)
                {
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion LIKE '%" + filtro + "'";
                                break;
                            default:
                                consulta += "M.Descripcion LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.modelo LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "A.modelo LIKE '%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.modelo LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "C.Descripcion LIKE '%" + filtro + "'";
                                break;
                            default:
                                consulta += "C.Descripcion LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "A.precio < " + filtro;
                                break;
                            default:
                                consulta += "A.precio = " + filtro;
                                break;
                        }
                        break;
                }

                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Producto aux = new Producto
                    {
                        sku = (int)datos.lector["sku"],
                        Nombre = (string)datos.lector["Nombre"],
                        Precio = (decimal)datos.lector["precio"],
                        Estado = (bool)datos.lector["estado"],
                        MarcasCls = new Marcas { Descripcion = (string)datos.lector["MarcaDescripcion"] },
                        CategoriasCls = new Categorias { Descripcion = (string)datos.lector["CategoriaDescripcion"] },
                        Imagen = new ArtImg()
                    };

                    if (!(datos.lector["Imagen"] is DBNull))
                        aux.Imagen.ImagenUrl = datos.lector["Imagen"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
