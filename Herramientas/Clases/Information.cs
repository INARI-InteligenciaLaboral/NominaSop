using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Clases
{
    public class Information
    {
        public static void MensajeInformation(string m_Mensaje)
        {
            Forms.FormInformation m_Form = new Forms.FormInformation();
            m_Form.lblTexto.Text = m_Mensaje;
            m_Form.Show();
        }
    }
}
