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
                    "insert into CATEGORIAS (Descripcion) values ('" +categorias.Descripcion+"')");
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
                datos.SetearConsulta("SELECT Id,Descripcion from CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Categorias aux = new Categorias();

                    aux.Id = (int)datos.lector["Id"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    
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
                datos.SetearConsulta("delete from CATEGORIAS where id = @id");
                datos.setearParametro("@id", id);
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
                datos.SetearConsulta("update CATEGORIAS set Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametro("@Id", categoria.Id);
                datos.setearParametro("@Descripcion", categoria.Descripcion);                
                datos.EjecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.CerrarConexion(); }
            
        }
    }
}

