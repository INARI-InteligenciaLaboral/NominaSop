using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaSoprade
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void solicitararchivo()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.Title = "Seleccione el archivo de Excel";
            dialog.FileName = string.Empty;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LLenarGrid(dialog.FileName, "Hoja1");
            }
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            solicitararchivo();
        }
        private void LLenarGrid(string archivo, string hoja)
        {
        }
    }
}
