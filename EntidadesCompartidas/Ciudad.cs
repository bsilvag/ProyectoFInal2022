using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
   public class Ciudad
    {
        //Atributos
        private string _CodC;
        private string _NombreC;

        //Atributos de Asoc. 
        private Pais _Pais;

        //Propiedades
        public string CodC
        {
            set
            {
                if (value.Trim().Length == 3)
                    _CodC = value;
                else
                {
                    throw new Exception("Código de ciudad inválido");
                }
            }
            get { return _CodC; }
        }

        public string NombreC
        {
            get { return _NombreC; }
            set
            {
                if (value.Trim().Length > 0 || value.Trim().Length <= 25)
                    _NombreC = value;
                else
                    throw new Exception("Error - El nombre debe estar lleno");
            }
        }

        public Pais Pais
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse el País");
                else
                    _Pais = value;
            }
            get { return _Pais; }
        }

        //Cosntructor
        public Ciudad(string pCodC, string pNombreC, Pais unP)
        {
            CodC = pCodC;
            NombreC = pNombreC;
            Pais = unP;
        }

        //Operaciones
        public override string ToString()
        {
            return ("- " + _CodC + " - " + _NombreC + " - País: " + this.Pais.NombreP);
        }
    }
}
