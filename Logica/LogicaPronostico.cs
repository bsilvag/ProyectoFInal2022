using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    public class LogicaPronostico
    {
        public static void Alta(Pronostico unPro)
        {
            if (unPro.FechaHora > DateTime.Now)
            {
                PersistenciaPronostico.Alta(unPro);
            }
        }

        public static List<EntidadesCompartidas.Pronostico> ListarPronxCiudad(Ciudad unaC)
        {
            return (PersistenciaPronostico.ListarPronxCiudad(unaC));
        }

        public static List<EntidadesCompartidas.Pronostico> ListarPronosticoxDia(DateTime pFechaHora)
        {
            List<Pronostico> _lista = new List<Pronostico>();
            _lista.AddRange(PersistenciaPronostico.ListarPronosticoxDia(pFechaHora));
            return (_lista);
        }

        

    }
}
