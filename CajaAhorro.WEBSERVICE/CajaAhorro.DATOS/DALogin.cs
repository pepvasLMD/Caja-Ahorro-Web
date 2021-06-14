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
    public class DALogin
    {
        public ResponseLogin Authenticate(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseLogin>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_validarUserToken", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usertoken", paramss.usertoken));
                    cmd.Parameters.Add(new SqlParameter("@passwordtoken", paramss.passwordtoken));

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseLogin();
                            result.responsetoken = Convert.ToString(rdr["response"]);
                            lista.Add(result);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseLogin>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    //Se llama al store procedure
                    SqlCommand cmd = new SqlCommand("usp_validarAccesos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@user", paramss.user));
                    cmd.Parameters.Add(new SqlParameter("@password", paramss.pass));

                    //Ejecuta el SP
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseLogin();
                            result.iduser = Convert.ToInt32(rdr["iduser"]);
                            result.response = Convert.ToString(rdr["response"]);
                            result.username = Convert.ToString(rdr["username"]);
                            result.tipo = Convert.ToString(rdr["tipo"]);                            

                            lista.Add(result);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
