using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Herramientas.Clases
{
    public class Questions
    {
        public static void MensajeAceptar(string m_Mensaje)
        {
            Forms.FormQuestion m_Form = new Forms.FormQuestion();
            m_Form.lblTexto.Text = m_Mensaje;
            m_Form.Show();
        }
    }
}
