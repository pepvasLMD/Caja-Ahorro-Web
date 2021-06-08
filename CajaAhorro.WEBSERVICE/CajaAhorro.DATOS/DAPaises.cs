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
    public class DAPaises
    {
        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePais>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_listarPaises", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponsePais();
                            result.idPais = Convert.ToInt32(rdr["idpais"]);
                            result.pais = Convert.ToString(rdr["pais"]);
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
