using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Negocio
{
    public class CategoriaNegocio
    {
        public void agregar(Categorias categorias)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.SetearConsulta(
                    "insert into CATEGORIAS (nombre) values ('" +categorias.nombre+"')");
                datos.EjecutarAccion();
                    }

            catch { }   
            finally { }
        }

        public List<Categorias> ListarCategoria()
        {
            List<Categorias> listaCategoria = new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT IdCategoria,nombre from CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Categorias aux = new Categorias();

                    aux.Id = (int)datos.lector["IdCategoria"];
                    aux.nombre = (string)datos.lector["nombre"];
                    
                    listaCategoria.Add(aux);
                }
                return listaCategoria;
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

        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from CATEGORIAS where IdCategoria = @id");
                datos.setearParametro("@IdCategoria", id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void modificar(Categorias categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update CATEGORIAS set nombre = @nombre WHERE IdCategoria = @Id");
                datos.setearParametro("@IdCategoria", categoria.Id);
                datos.setearParametro("@nombre", categoria.nombre);                
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
            
        }
    }
}

