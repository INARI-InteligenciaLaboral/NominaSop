using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Clases
{
    public class Solicitar
    {
        public static string MensajeSolicitar(string m_Mensaje)
        {
            Forms.FormSolicitar m_Form = new Forms.FormSolicitar();
            m_Form.lblTexto.Text = m_Mensaje;
            if (m_Form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                return m_Form.ValorRetorno;
            else
                return "";
            //m_Form.Show();
        }
    }
}
