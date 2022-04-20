using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pronostico
    {
        //Atributos
        private int _CodIntP;
        private DateTime _FechaHora;
        private int _Velocidad;
        private int _ProbL;
        private int _ProbT;
        private string _TipoCielo;
        private int _TempMax;
        private int _TempMin;

        //Atributos de Asoc. 
        private Ciudad _Ciudad;
        private Usuario _Usuario;

        //Propiedades
        public int CodIntP
        {
            set { _CodIntP = value; }
            get { return _CodIntP; }
        }

        public DateTime FechaHora
        {
            set { _FechaHora = value; } 
            get { return _FechaHora; }
        }

        public int TempMax 
        {
            set
            {
                if (value > 56 || value < -89)
                    throw new Exception("La temperatura indicada no es válida");
                else
                    _TempMax = value;
            }
            get { return _TempMax; }
        }

        public int TempMin 
        {
            set
            {
                if (value > 56 || value < -89)
                    throw new Exception("La temperatura indicada no es válida");
                else
                    _TempMin = value;
            }
            get { return _TempMin; }
        }

        public int Velocidad
        {
            set
            {
                if (value < 0 || value > 200 )
                    throw new Exception("La velocidad tiene que ser mayor que cero");
                else
                    _Velocidad = value;
            }
            get { return _Velocidad; }
        }

        public string TipoCielo
        {
            get { return _TipoCielo; }
            set
            {
                if (value.Trim() == "Despejado")
                    _TipoCielo = value;
                else if (value.Trim() == "Parcialmente Nuboso")
                    _TipoCielo = value;
                else if (value.Trim() == "Nuboso")
                    _TipoCielo = value;
                else throw new Exception("Error - El tipo de cielo debe de ser del formato indicado");
            }
        }

        public int ProbL
        {
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("La probabilidad tiene que ser de 0 a 100%");
                else
                    _ProbL = value;
            }
            get { return _ProbL; }
        }

        public int ProbT
        {
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("La probabilidad tiene que ser de 0 a 100%");
                else
                    _ProbT = value;
            }
            get { return _ProbT; }
        }

        public Ciudad Ciudad
        {
            set
            {
                if (value == null)
                    throw new Exception("La ciudad debe corresponder al País elegido ");
                else
                    _Ciudad = value;
            }
            get { return _Ciudad; }
        }
        public Usuario Usuario
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse el usuario");
                else
                    _Usuario = value;
            }
            get { return _Usuario; }
        }

        
        //Constructores Completo
        public Pronostico(int pCodIntP, DateTime pFechaHora, int pVelocidad, int pProbL, int pProbT, string pTipoCielo, int pTempMax, int pTempMin, Ciudad unaC, Usuario unUsu)
        {
            CodIntP = pCodIntP;
            FechaHora = pFechaHora;
            Velocidad = pVelocidad;
            ProbL = pProbL;
            ProbT = pProbT;
            TipoCielo = pTipoCielo;
            TempMax = pTempMax;
            TempMin = pTempMin;
            Ciudad = unaC;
            Usuario = unUsu;

        }


        //Operaciónes 
        public override string ToString()
        {
            return ("Código interno: " + _CodIntP + " - Fecha del pronóstico: " + _FechaHora.ToShortDateString() + DateTime.Now.ToString(" hh:mm:ss tt ") + " - Velocidad del viento: " + _Velocidad +
                " - Probabilidad de lluvia: " + _ProbL + " - probabilidad de tormenta: " + _ProbT + " - Tipo de cielo: " + _TipoCielo +
                " - Temperatura máxima: " + _TempMax + " - Temperatura mínima: " + _TempMin + " - Ciudad: " + this.Ciudad.NombreC + " - Usuario: " + this.Usuario.NombUsu);
        }
    }
}
