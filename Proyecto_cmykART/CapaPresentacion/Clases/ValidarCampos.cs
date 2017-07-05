using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class ValidarCampos
    {
        public bool ValidarControlesEnteros(TextBox enteros)
        {
            try
            {
                int entero = Convert.ToInt32(enteros.Text);
                return true;
            }
            catch (Exception)
            {

                enteros.Text = "0";
                enteros.Select(0, enteros.Text.Length);
                return false;
            }
        }

        public bool ValidarControlesDecimales(TextBox decimales)
        {
            try
            {
                decimal dem= Convert.ToDecimal(decimales.Text);
                return true;
            }
            catch (Exception)
            {

                decimales.Text = "0.00";
                decimales.Select(0, decimales.Text.Length);
                return false;
            }
        }
        
    }
}
