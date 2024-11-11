using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> ListarProveedores()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Proveedor> list = new List<Proveedor>();

            try
            {
                datos.SetearConsulta("SELECT id_proveedor, nombre, direccionID FROM PROVEEDORES");
                datos.EjecutarLectura();

                while (datos.lector.Read())
                {
                    Proveedor aux = new Proveedor();

                    aux.id_proveedor = (int)datos.lector["id_proveedor"];
                    aux.nombre = (string)datos.lector["nombre"];
                    aux.direccionID = (int)datos.lector["direccionID"];
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

        public void AgregarProveedor(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("INSERT INTO PROVEEDORES (nombre, direccionID) VALUES (@nombre, @direccionID)");
                datos.setearParametro("@nombre", proveedor.nombre);
                datos.setearParametro("@direccionID", proveedor.direccionID);
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
                datos.SetearConsulta("DELETE FROM PROVEEDORES WHERE id_proveedor = @id");
                datos.setearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("UPDATE PROVEEDORES SET nombre = @nombre, direccionID = @direccionID WHERE id_proveedor = @id");
                datos.setearParametro("@nombre", proveedor.nombre);
                datos.setearParametro("@direccionID", proveedor.direccionID);
                datos.setearParametro("@id", proveedor.id_proveedor);
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


        public Proveedor ObtenerProveedorConMasArticulos()
        {
            Proveedor proveedor = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ProveedorConMasArticulos");
                datos.EjecutarLectura();

                if (datos.lector.Read())
                {
                    proveedor = new Proveedor
                    {
                        id_proveedor = (int)datos.lector["id_proveedor"],
                        nombre = datos.lector["Nombre"].ToString(),
                        CantidadArticulos = (int)datos.lector["CantidadArticulos"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

            return proveedor;
        }

    }
}
