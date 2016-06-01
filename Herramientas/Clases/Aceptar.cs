using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Clases
{
    public class Aceptar
    {
        public static void MensajeAceptar(string m_Mensaje)
        {
            Forms.FormAceptar m_Form = new Forms.FormAceptar();
            m_Form.lblTexto.Text = m_Mensaje;
            m_Form.Show();
        } 
    }
}
