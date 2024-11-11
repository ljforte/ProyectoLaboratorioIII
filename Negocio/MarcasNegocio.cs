using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcasNegocio
    {
        public List<Marcas> ListarMarcas()
        {
           
            AccesoDatos datos = new AccesoDatos();
            List<Marcas> list = new List<Marcas>();

            try
            {
                datos.SetearConsulta("SELECT Id, Descripcion from MARCAS");
                datos.EjecutarLectura();
                

                while (datos.lector.Read())
                {
                    Marcas aux = new Marcas();

                    aux.Id = (int)datos.lector["Id"];
                    aux.Descripcion = (string)datos.lector["Descripcion"];
                    list.Add(aux);
                }
                return list;
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
    public void AgregarMarca(Marcas marcas)
    {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO Marcas (Descripcion) VALUES (@Descripcion)");
                datos.setearParametro("@Descripcion", marcas.Descripcion); 
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

    public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from MARCAS where id = @id");
                datos.setearParametro("@id", id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Modificar(Marcas marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.SetearConsulta("UPDATE MARCAS SET Descripcion = @descripcion WHERE id = @id");
                datos.setearParametro("@descripcion", marca.Descripcion);
                datos.setearParametro("@id", marca.Id);
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
