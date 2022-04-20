using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
   public class PersistenciaPais
    {
        public static void Alta(Pais unaP)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodP", unaP.CodP);
            _Comando.Parameters.AddWithValue("@NombreP", unaP.NombreP);


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe el Pais");
                else if (oAfectados == -2)
                    throw new Exception("Error");
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
        
        public static void Modificar(Pais unaP)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ModPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodP", unaP.CodP);
            _Comando.Parameters.AddWithValue("@NombreP", unaP.NombreP);
       


            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el País - NO SE MODIFICA");
                else if (oAfectados == -2)
                    throw new Exception("Error");
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

        public static void Eliminar(Pais unaP)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("BajaPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@CodP", unaP.CodP);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            _Comando.Parameters.Add(_codigo);
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el Pais - No se elimina");
                else if (oAfectados == -2)
                    throw new Exception("Tiene Pronósticos asociadas - No se elimina");
                else if (oAfectados == -3)
                    throw new Exception("Error");

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

        public static Pais Buscar(string pCodP)
        {
            Pais P = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscarPais " + pCodP, _Conexion);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    P = new Pais(_Reader["CodP"].ToString(), _Reader["NombreP"].ToString());

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

            return P;
        }

        public static List<Pais> ListarPaises()
        {
            List<Pais> _lista = new List<Pais>(); 
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarPais", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Pais P = new Pais(Convert.ToString(_Reader["CodP"]), _Reader["NombreP"].ToString());
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
