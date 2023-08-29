using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public static class Helper
    {
        /// <summary>
        /// textBox:
        ///     Solo se ingresan enteros.
        /// </summary>
        /// <param name="e"></param>
        public static void SoloEnteros(ref KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8) { e.Handled = true; }
        }
        /// <summary>
        /// textBox:
        ///     Solo se ingresan decimales.
        /// </summary>
        /// <param name="e"></param>
        public static void SoloDecimales(ref KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 59) && e.KeyChar != 8 && e.KeyChar != 46) { e.Handled = true; }
        }
    }
}
