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
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

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
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);
                    conexion.Open();
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, hoja);
                    dgvOriginal.DataSource = dataSet.Tables[0];
                    conexion.Close();
                    dgvOriginal.AllowUserToAddRows = false; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                }
            }
        }
    }
}
