using CajaAhorro.ENTITY.Parametros;
using CajaAhorro.ENTITY.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaAhorro.DATOS
{
    public class DAPrestamo
    {
        public List<ResponseUsuario> getPrestar(ENPrestamo paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseUsuario>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_darPrestamo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idusuario", paramss.idusuario));
                    cmd.Parameters.Add(new SqlParameter("@dinero", paramss.dinero));
                    cmd.Parameters.Add(new SqlParameter("@opcion", paramss.opcion));

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseUsuario();
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
    }
}
