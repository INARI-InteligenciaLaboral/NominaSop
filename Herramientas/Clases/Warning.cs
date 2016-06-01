namespace Herramientas.Clases
{
    public class Warning
    {
        public static void MensajeWarning(string m_Mensaje)
        {
            Forms.FormWarning m_Form = new Forms.FormWarning();
            m_Form.lblTexto.Text = m_Mensaje;
            m_Form.Show();
        }
    }
}
