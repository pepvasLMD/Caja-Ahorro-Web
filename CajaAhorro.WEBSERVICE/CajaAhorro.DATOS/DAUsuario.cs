using CajaAhorro.ENTITY.Parametros;
using CajaAhorro.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CajaAhorro.DATOS
{
    public class DAUsuario
    {
        public List<ResponseEstadoCuenta> getEstadoCuenta(ENUsuario paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseEstadoCuenta>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_obtenerEstadoCuentaUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idcuenta", paramss.idcuenta));

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEstadoCuenta();
                            result.idcuenta = Convert.ToInt32(rdr["idcuenta"]);
                            result.idusuario = Convert.ToInt32(rdr["idusuario"]);
                            result.dinero = Convert.ToDouble(rdr["dinero"]);
                            result.disponible = Convert.ToDouble(rdr["disponible"]);
                            result.deudaTotal = Convert.ToDouble(rdr["deuda_total"]);
                            result.response = Convert.ToString(rdr["response"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponseTransaccion> getDarAportacion(ENTransaccion paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseTransaccion>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_darAportacion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idcuenta", paramss.idcuenta));
                    cmd.Parameters.Add(new SqlParameter("@monto", paramss.monto));

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseTransaccion();
                            result.msg = Convert.ToString(rdr["response"]);
                            lista.Add(result);
                        }
                    }
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
