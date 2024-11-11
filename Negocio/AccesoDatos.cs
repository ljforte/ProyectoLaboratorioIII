﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader Lector;
        public SqlDataReader lector
        {
            get { return Lector; }
        }
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=(local)\\SQLEXPRESS; database=Compumundo_hipermegared; integrated security=true");
            comando = new SqlCommand();
        }

        public void 
            SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                Lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void CerrarConexion() {
            if (lector != null)
            {
                lector.Close(); 
                conexion.Close();
            }
        }

        public void EjecutarAccion()
        {

            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                throw ex;
            }

        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

    }
}
