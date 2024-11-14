using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SitioNegocio
    {

        List<Sitio> sitios = new List<Sitio>();
        AccesoDatos datos = new AccesoDatos();

        // Método para listar todos los sitios
        public List<Sitio> Listar()
        {
                     

            try
            {              
                datos.SetearConsulta("SELECT Id_Sitio, Nombre FROM sitio");
                datos.EjecutarLectura();
  
                while (datos.lector.Read())
                {
                    Sitio sitio = new Sitio
                    {
                        Id_Sitio = (int)datos.lector["Id_Sitio"],
                        Nombre = (string)datos.lector["Nombre"]
                    };

                    sitios.Add(sitio);
                }

                return sitios;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los sitio.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // Método para agregar un nuevo sitio
        public void Agregar(Sitio sitio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO sitio (Nombre) VALUES (@Nombre)");
                datos.setearParametro("@Nombre", sitio.Nombre);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el sitio.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // Método para modificar un sitio existente
        public void Modificar(Sitio sitio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("UPDATE sitio SET Nombre = @Nombre WHERE Id_Sitio = @Id_Sitio");
                datos.setearParametro("@Nombre", sitio.Nombre);
                datos.setearParametro("@Id_Sitio", sitio.Id_Sitio);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el sitio.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        // Método para eliminar un sitio
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("DELETE FROM sitio WHERE Id_Sitio = @Id_Sitio");
                datos.setearParametro("@Id_Sitio", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el sitio.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public string BuscarSitioPorId(int idStock)
        {
            AccesoDatos datos = new AccesoDatos();
            string nombreSitio = string.Empty;

            try
            {
                // Consulta para obtener el nombre del sitio relacionado con el stock
                datos.SetearConsulta(@"
            SELECT s.Nombre
            FROM STOCK st
            INNER JOIN sitio s ON s.Id_Sitio = st.id_sitio
            WHERE st.id = @idStock");

                // Establecer el parámetro de entrada
                datos.setearParametro("@idStock", idStock);

                // Ejecutar la consulta y obtener los resultados
                datos.EjecutarLectura();

                // Si hay resultados, obtener el nombre del sitio
                if (datos.lector.Read())
                {
                    nombreSitio = (string)datos.lector["Nombre"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el sitio por ID.", ex);
            }
            finally
            {
                datos.CerrarConexion();
            }

            return nombreSitio;
        }
    }
}