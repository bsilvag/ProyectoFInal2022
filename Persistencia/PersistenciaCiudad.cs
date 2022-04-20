using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;



namespace Persistencia
{
   public class PersistenciaCiudad
    {
        public static void Alta(Ciudad unaC)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodC", unaC.CodC);
            _Comando.Parameters.AddWithValue("@NombreC", unaC.NombreC);
            _Comando.Parameters.AddWithValue("@CodP", unaC.Pais.CodP);
            
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe la Ciudad");
                else if (oAfectados == -2)
                    throw new Exception("No existe el país indicado");
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

        public static void Modificar(Ciudad unaC)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ModificarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@CodC", unaC.CodC);
            _Comando.Parameters.AddWithValue("@NombreC", unaC.NombreC);
            _Comando.Parameters.AddWithValue("@CodP", unaC.Pais.CodP);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe la ciudad - NO SE MODIFICA");
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

        public static void Eliminar(Ciudad unaC)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("BajaCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@CodC", unaC.CodC);
            SqlParameter _codigo2 = new SqlParameter("@CodP", unaC.Pais.CodP);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            _Comando.Parameters.Add(_codigo);
            _Comando.Parameters.Add(_codigo2);

            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery(); 

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe la Ciudad - No se elimina");
                else if (oAfectados == -2)
                    throw new Exception("Error en eliminación de Pronóstico - No se elimina");
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

        public static Ciudad Buscar(string pCodC, string pCodP)
        {
            Ciudad C = null; 
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscarCiudad " + pCodC + "," + pCodP, _Conexion);
          

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())

                    C = new Ciudad(_Reader["CodC"].ToString(), _Reader["NombreC"].ToString(), PersistenciaPais.Buscar(_Reader["CodP"].ToString()));


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

            return C;
        }


        public static List<Ciudad> ListarCiudadesPais(Pais unP)
        {
            List<Ciudad> _lista = new List<Ciudad>(); ;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarCxP ", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;
           
            _Comando.Parameters.AddWithValue("@CodP", unP.CodP);
           
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Ciudad C = new Ciudad(Convert.ToString(_Reader["CodC"]), _Reader["NombreC"].ToString(),unP);
                        _lista.Add(C);
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


        public static List<Ciudad> ListarCiudad()
        {
            List<Ciudad> _ListaC = new List<Ciudad>();
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ListarCiudad", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Ciudad C = new Ciudad(Convert.ToString(_Reader["CodC"]), _Reader["NombreC"].ToString(), PersistenciaPais.Buscar(_Reader["CodP"].ToString()));
                        _ListaC.Add(C);
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

            return _ListaC;
        }
    }
}
