using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<ArtImg> ListarImagenes(Articulo art)
        {
            List<ArtImg> lista = new List<ArtImg>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT A.Nombre, i.ImagenUrl, i.Id from IMAGENES i right join ARTICULOS as A on A.id = i.IdArticulo where i.IdArticulo = @artId");
                datos.setearParametro("@artId", art.Id);
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    ArtImg aux = new ArtImg();
                    if (!(datos.lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.lector["ImagenUrl"];
                    aux.Desc = (string)datos.lector["Nombre"];
                    aux.Id = (int)datos.lector["Id"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void Agregar(string url, Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();;
            try
            {
                datos.SetearConsulta("insert into IMAGENES (ImagenUrl, IdArticulo) VALUES (@url, @Id)");
                datos.setearParametro("@url", url);
                datos.setearParametro("@Id", art.Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void EliminarImagen(ArtImg img)
        {
            try
            {

                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from IMAGENES where id = " + img.Id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Modificar(ArtImg img)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.SetearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE id = " + img.Id);
                datos.setearParametro("@ImagenUrl", img.ImagenUrl);
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
    }
}
