using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        //Atributos
        private string _NombUsu;
        private string _Nombre;
        private string _Pass;
  

        //Propiedades
        public string NombUsu
        {
            get { return _NombUsu; }
            set
            {
                if (value.Trim().Length > 0 || value.Trim().Length <= 30)
                    _NombUsu = value;
                else
                    throw new Exception("Error - El nombre debe estar lleno");
            }
        }

        public string Pass
        {
            get { return _Pass; }
            set
            {
                if (value.Trim().Length > 0 || value.Trim().Length <= 20)
                    _Pass = value;
                else
                    throw new Exception("Error - Debe escribir una contraseña");
            }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set
            {
                if (value.Trim().Length > 0 || value.Trim().Length <= 20)
                    _Nombre = value;
                else
                    throw new Exception("Error - El nombre debe estar lleno");
            }
        }

        //Constructores
        public Usuario(string pNombUsu, string pNombre, string pPass)
        {
            NombUsu = pNombUsu;
            Nombre = pNombre;
            Pass = pPass;
            
        }
    }
}
