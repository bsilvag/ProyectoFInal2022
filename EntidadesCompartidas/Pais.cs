using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pais
    {
        //Atributos
        private string _CodP;
        private string _NombreP;

        //Propiedades
        public string CodP
        {
            set
            {
                if (value.Trim().Length == 3)
                    _CodP = value;
                else
                {
                    throw new Exception("Código de país inválido");
                }
            }
            get { return _CodP; }
        }

        public string NombreP
        {
            get { return _NombreP; }
            set
            {
                if (value.Trim().Length > 0 || value.Trim().Length <= 25)
                    _NombreP = value;
                else
                    throw new Exception("Error - El nombre debe estar lleno");
            }
        }

        //Cosntructor
        public Pais(string pCodP, string pNombreP)
        {
            CodP = pCodP;
            NombreP = pNombreP;
        }

        //Operaciones
        public override string ToString()
        {
            return ("- " + CodP + " - " + NombreP);
        }
    }
}
