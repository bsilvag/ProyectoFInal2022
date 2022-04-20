using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
   public class LogicaUsuario
    {
       public static Usuario Logueo(string pNombUsu, string pPass)
        {
            return (PersistenciaUsuario.Logueo(pNombUsu, pPass));
        }

        public static void Alta(Usuario unUsu)
        {
            PersistenciaUsuario.Alta(unUsu);
        }

        public static void Modificar(Usuario unUsu)
        {
            PersistenciaUsuario.Modificar(unUsu);
        }

        public static void Eliminar(Usuario unUsu)
        {
            PersistenciaUsuario.Eliminar(unUsu);
        }

        public static Usuario Buscar(string pNombUsu)
        {
            return (PersistenciaUsuario.Buscar(pNombUsu));
        }

    }
}
