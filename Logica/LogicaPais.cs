using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Persistencia;
using EntidadesCompartidas;


namespace Logica
{
    public class LogicaPais
    {
        public static void Alta(Pais unaP)
        {
            PersistenciaPais.Alta(unaP);
        }

        public static void Modificar(Pais unaP)
        {
            PersistenciaPais.Modificar(unaP);
        }

        public static void Eliminar(Pais unaP)
        {
            PersistenciaPais.Eliminar(unaP);
        }

        public static Pais Buscar(string pCodP)
        {
            return (PersistenciaPais.Buscar(pCodP));
        }

        public static List<Pais> ListarPaises()
        {
            return (PersistenciaPais.ListarPaises());
        }

    }
}
