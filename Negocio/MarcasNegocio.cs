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
                datos.SetearConsulta("SELECT idMarca, nombre from MARCAS");
                datos.EjecutarLectura();
                

                while (datos.lector.Read())
                {
                    Marcas aux = new Marcas();

                    aux.Id = (int)datos.lector["idMarca"];
                    aux.nombre = (string)datos.lector["nombre"];
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
                datos.SetearConsulta("INSERT INTO Marcas (nombre) VALUES (@nombre)");
                datos.setearParametro("@nombre", marcas.nombre); 
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
                datos.SetearConsulta("delete from MARCAS where IdMarca = @id");
                datos.setearParametro("@IdMarca", id);
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
                
                datos.SetearConsulta("UPDATE MARCAS SET nombre = @nombre WHERE idMarca = @id");
                datos.setearParametro("@nombre", marca.nombre);
                datos.setearParametro("@idMarca", marca.Id);
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
