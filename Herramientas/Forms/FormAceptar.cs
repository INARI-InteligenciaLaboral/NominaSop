using System;
using System.Windows.Forms;

namespace Herramientas.Forms
{
    public partial class FormAceptar : Form
    {
        public FormAceptar()
        {
            InitializeComponent();
        }

        private void FormAceptar_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
