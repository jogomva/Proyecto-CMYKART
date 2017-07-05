using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    public class VerificarReglasUsuario
    {
        public string[] ReglasVerificar { get; set; }

        public bool TieneRegla(string reglasVerificar)
        {
            string[] aReglas_a_verificar = reglasVerificar.Split(',');
            foreach (string s in aReglas_a_verificar)
            {
                if (s != "" && ReglasVerificar.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
