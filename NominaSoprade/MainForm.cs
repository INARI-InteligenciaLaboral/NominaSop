using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace NominaSoprade
{
    public partial class MainForm : Form
    {
        private string m_CentrosCosto;
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
            btnAnalizar.Enabled = false;
            tbxPro.Text = "";
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
        private void btnAnalizar_Click(object sender, EventArgs e)
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
            solicitarInfEmp();
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
            string consultaHojaExcel = "Select *, '' AS DEPARTAMENTO, '' AS PUESTO from [" + hoja + "$]";
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
                    btnLimpiar.Enabled = true;
                    btnAnalizar.Enabled = true;
                    dgvOriginal.Columns.Add("PUESTO","PUESTO");
                    dgvOriginal.Columns.Add("DEPARTAMENTO", "DEPARTAMENTO");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja \n" + ex.Message, this.Text);
                }
            }
        }
        #endregion
        #region SolicitarAction
        public void ProcesarError(object o, DoWorkEventArgs e)
        {
            string m_valorError="";
            Modelos.ProcesarDocumento m_Procesar = new Modelos.ProcesarDocumento();
            DataTable dataTabla = new DataTable();
            dataTabla = dgvOriginal.DataSource as DataTable;
            ArrayList ListaInsidencias = new ArrayList();
            ListaInsidencias =  m_Procesar.procesamiento(dataTabla);
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
                if (!this.tbxPro.Text.Equals(""))
                {
                    this.btnProcesar.Enabled = false;
                    this.btnAus.Enabled = false;
                    this.btnVac.Enabled = false;
                    this.btnExcTra.Enabled = false;
                    this.btnIns.Enabled = false;
                }
                else
                {
                    this.btnProcesar.Enabled = true;
                    this.btnAus.Enabled = true;
                    this.btnVac.Enabled = true;
                    this.btnExcTra.Enabled = true;
                    this.btnIns.Enabled = true;
                }
            }));
            MessageBox.Show("Proceso Terminado","INARI Inteligencia Laboral",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void Actionbtn(bool m_valor)
        {
            btnLimpiar.Enabled = m_valor;
            btnAus.Enabled = m_valor;
            btnCargar.Enabled = m_valor;
            btnAnalizar.Enabled = m_valor;
            btnExcTra.Enabled = m_valor;
            btnVac.Enabled = m_valor;
            btnIns.Enabled = m_valor;
            btnProcesar.Enabled = m_valor;
        }
        private void solicitarInfEmp()
        {
            Modelos.SqlClass m_ConBD = new Modelos.SqlClass();
            DataTable m_empleados = new DataTable();
            m_empleados = m_ConBD.ObtenerEmp();
            for (int i = 0; i < dgvOriginal.Rows.Count; i++)
            {
                DataRow[] result = m_empleados.Select("contIDEmpl LIKE '%" + ClaEmp(dgvOriginal.Rows[i].Cells[2].Value.ToString()) + "'");
                foreach (DataRow rowresult in result)
                {
                    dgvOriginal.Rows[i].Cells["PUESTO"].Value = rowresult[2];
                    dgvOriginal.Rows[i].Cells["DEPARTAMENTO"].Value = rowresult[3];
                    dgvOriginal.Rows[i].Cells[2].Value = rowresult[0];
                }
            }
            m_CentrosCosto = m_ConBD.ObtCentroCosto();
        }
        private string ClaEmp(string m_Clave)
        {
            if (m_Clave.Length < 5)
            {
                for (int i = m_Clave.Length; i < 5; i++)
                {
                    m_Clave = "0" + m_Clave;
                }
            }
            return m_Clave;
        }
        #endregion
    }
}
