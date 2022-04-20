using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    public class PersistenciaPronostico
    {
        public static void Alta(Pronostico unPro)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaPronostico", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@FechaHora", unPro.FechaHora);
            _Comando.Parameters.AddWithValue("@Velocidad", unPro.Velocidad);
            _Comando.Parameters.AddWithValue("@ProbL", unPro.ProbL);
            _Comando.Parameters.AddWithValue("@ProbT", unPro.ProbT);
            _Comando.Parameters.AddWithValue("@TipoCielo", unPro.TipoCielo);
            _Comando.Parameters.AddWithValue("@Tmax", unPro.TempMax);
            _Comando.Parameters.AddWithValue("@Tmin", unPro.TempMin);
            _Comando.Parameters.AddWithValue("@NombreUsu", unPro.Usuario.NombUsu);
            _Comando.Parameters.AddWithValue("@CodC", unPro.Ciudad.CodC);
            _Comando.Parameters.AddWithValue("@CodP", unPro.Ciudad.Pais.CodP);
           

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe la Ciudad");
                else if (oAfectados == -2)
                    throw new Exception("No existe el Usuario");
                else if (oAfectados == -3)
                    throw new Exception("Ya existe Pronostico asociado a esta Fecha");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
        }

        public static List<Pronostico> ListarPronxCiudad(Ciudad unaC)
        {
            List<Pronostico> _lista = new List<Pronostico>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarPronxCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodC", unaC.CodC);
            _Comando.Parameters.AddWithValue("@CodP", unaC.Pais.CodP);
           
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Pronostico P = new Pronostico(Convert.ToInt32(_Reader["CodIntP"]), Convert.ToDateTime(_Reader["FechaHora"]), Convert.ToInt32(_Reader["Velocidad"]), Convert.ToInt32(_Reader["ProbL"]), Convert.ToInt32(_Reader["ProbT"]), _Reader["TipoCielo"].ToString(), Convert.ToInt32(_Reader["Tmax"]), Convert.ToInt32(_Reader["Tmin"]), unaC, PersistenciaUsuario.Buscar(_Reader["NombreUsu"].ToString()));
                        _lista.Add(P);
                    }
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("No existe Pronóstico asociado a la Ciudad" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _lista;
        }

        public static List<Pronostico> ListarPronosticoxDia(DateTime pFechaHora)
        {
            List<Pronostico> _lista = new List<Pronostico>();

            SqlDataReader _Reader;
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarPronosticoxDia", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
            _Comando.Parameters.AddWithValue("@FechaHora", pFechaHora.ToString("yyyyMMdd"));
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Pronostico P = new Pronostico(Convert.ToInt32(_Reader["CodIntP"]), pFechaHora, Convert.ToInt32(_Reader["Velocidad"]), Convert.ToInt32(_Reader["ProbL"]), Convert.ToInt32(_Reader["ProbT"]), _Reader["TipoCielo"].ToString(), Convert.ToInt32(_Reader["Tmax"]), Convert.ToInt32(_Reader["Tmin"]), PersistenciaCiudad.Buscar(_Reader["CodC"].ToString(), _Reader["CodP"].ToString()), PersistenciaUsuario.Buscar(_Reader["NombreUsu"].ToString()));
                        _lista.Add(P);
                    }
                }

                _Reader.Close();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _lista;
        }

    }
}
