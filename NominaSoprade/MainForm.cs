using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NominaSoprade
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Inicial();
        }
        private void Inicial()
        {
            dgvOriginal.DataSource = null;
            btnProcesar.Enabled = false;
            btnVac.Enabled = false;
            btnExcTra.Enabled = false;
            btnIns.Enabled = false;
            btnLimpiar.Enabled = false;
            btnAus.Enabled = false;
        }
        #region eventosboton
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Actionbtn(false);
            BackgroundWorker Procesar = new BackgroundWorker();
            Procesar.DoWork += ProcesarError;
            Procesar.RunWorkerCompleted += ProcesarTerminado;
            Procesar.RunWorkerAsync();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Inicial();
        }
        private void btnCargar_Click(object sender, EventArgs e)
        {
            solicitararchivo();
        }
    #endregion
    #region Docexcel
        private void solicitararchivo()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            dialog.Title = "Seleccione el archivo de Excel";
            dialog.FileName = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LLenarGrid(dialog.FileName);
            }
        }
        private void LLenarGrid(string archivo)
        {
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string hoja = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre de la hoja que desea abrir:", this.Text, "Hoja1");
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
                    btnProcesar.Enabled = true;
                    btnLimpiar.Enabled = true;
                    btnVac.Enabled = true;
                    btnExcTra.Enabled = true;
                    btnIns.Enabled = true;
                    btnAus.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja \n" + ex.Message, this.Text);
                }
            }
        }
        #endregion
        #region SolAction
        public void ProcesarError(object o, DoWorkEventArgs e)
        {
            string m_valorError;
            Modelos.ProcesarDocumento m_Procesar = new Modelos.ProcesarDocumento();
            DataTable dataTabla = new DataTable();
            dataTabla = dgvOriginal.DataSource as DataTable;
            m_valorError =  m_Procesar.procesamiento(dataTabla);
            this.BeginInvoke(new Action(() =>
            {
                this.tbxPro.Text = m_valorError;
            }));
        }
        public void ProcesarTerminado(object o, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.Actionbtn(true);
            }));
            MessageBox.Show("Proceso Terminado");
        }
        private void Procesar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbStatus.Value = e.ProgressPercentage;
        }
        private void Actionbtn(bool m_valor)
        {
            btnProcesar.Enabled = m_valor;
            btnVac.Enabled = m_valor;
            btnExcTra.Enabled = m_valor;
            btnIns.Enabled = m_valor;
            btnLimpiar.Enabled = m_valor;
            btnAus.Enabled = m_valor;
            btnCargar.Enabled = m_valor;
        }
        #endregion
    }
}
