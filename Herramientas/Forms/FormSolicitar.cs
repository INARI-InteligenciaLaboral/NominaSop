using System;
using System.Windows.Forms;

namespace Herramientas.Forms
{
    public partial class FormSolicitar : Form
    {
        public string ValorRetorno;
        public FormSolicitar()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ValorRetorno = tbxSolicitar.Text;
        }
    }
}
