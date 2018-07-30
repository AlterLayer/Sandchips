using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sandchips.DAL
{
    class NoEspacios
    {
        public static void SoloEspacios(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                //Controla la tecla de borrar o cualquier tecla de control,
                //Sí es false permite el uso, si es true le niega el uso
                else if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
