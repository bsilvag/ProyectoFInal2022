using System;
using System.Collections.Generic;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;


namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static EntidadesCompartidas.Usuario Logueo(string pNombUsu, string pPass)
        {
            SqlConnection _cnn = new SqlConnection(Conexion._Cnn);
            SqlCommand _comando = new SqlCommand("Logueo", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;

            Usuario unUsu = null;

            _comando.Parameters.AddWithValue("@NombreUsu", pNombUsu);
            _comando.Parameters.AddWithValue("@Contrasenia", pPass);

            try
            {
                _cnn.Open();

                SqlDataReader _lector = _comando.ExecuteReader();

                if (_lector.HasRows)
                {
                    _lector.Read();
                    string _NombUsu = (string)_lector["NombreUsu"];
                    string _Nombre = (string)_lector["Nombre"];
                    string _Pass = (string)_lector["Contrasenia"];
                    unUsu = new EntidadesCompartidas.Usuario(_NombUsu, _Nombre, _Pass);
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            return unUsu;
        }

        public static Usuario Buscar(string pNombUsu)
        {
            Usuario unUsu = null;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("Exec BuscarUsuario " + pNombUsu, _Conexion);

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.Read())
                    unUsu = new Usuario(Convert.ToString(_Reader["NombreUsu"]), _Reader["Contrasenia"].ToString(), _Reader["Nombre"].ToString());

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

            return unUsu;
        }

        public static void Modificar(Usuario unUsu)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("ModificarUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@NombreUsu", unUsu.NombUsu);
            _Comando.Parameters.AddWithValue("@Contrasenia", unUsu.Pass);
            _Comando.Parameters.AddWithValue("@Nombre", unUsu.Nombre);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe el Usuario - NO SE MODIFICA");
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

        public static void Eliminar(Usuario unUsu)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("BajaUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlParameter _codigo = new SqlParameter("@NombreUsu", unUsu.NombUsu);

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
                    throw new Exception("No existe ese Usuario - No se elimina");
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

        public static void Alta(Usuario unUsu)
        {
            SqlConnection _Conexion = new SqlConnection(Conexion._Cnn);
            SqlCommand _Comando = new SqlCommand("AltaUsuario", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@NombreUsu", unUsu.NombUsu);
            _Comando.Parameters.AddWithValue("@Contrasenia", unUsu.Pass);
            _Comando.Parameters.AddWithValue("@Nombre", unUsu.Nombre);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _Comando.Parameters.Add(_Retorno);

            try
            {
                _Conexion.Open();
                _Comando.ExecuteNonQuery();

                int oAfectados = (int)_Comando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya existe el Usuario");
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
    }
}
