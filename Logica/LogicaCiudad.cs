using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Persistencia;
using EntidadesCompartidas;


namespace Logica
{
    public class LogicaCiudad
    {
        public static void Alta(Ciudad unaC)
        {
            PersistenciaCiudad.Alta(unaC);
        }

        public static void Modificar(Ciudad unaC)
        {
            PersistenciaCiudad.Modificar(unaC);
        }

        public static void Eliminar(Ciudad unaC)
        {
            PersistenciaCiudad.Eliminar(unaC);
        }

        public static Ciudad Buscar(string pCodC, string pCodP)
        {
            return (PersistenciaCiudad.Buscar(pCodC, pCodP));
        }

        public static List<EntidadesCompartidas.Ciudad> ListarCiudadesPais(Pais unP)
        {
            List<Ciudad> _lista = new List<Ciudad>();
            _lista.AddRange(PersistenciaCiudad.ListarCiudadesPais(unP));
            return (_lista);
        }
        public static List<Ciudad> ListarCiudad()
        {
            return (PersistenciaCiudad.ListarCiudad());
        }

    }
}
