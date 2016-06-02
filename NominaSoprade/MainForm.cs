using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Herramientas.Clases;
using System.IO;

namespace NominaSoprade
{
    public partial class MainForm : Form
    {
        private string m_CentrosCosto;
        private ArrayList ListaInsidencias = new ArrayList();
        public MainForm()
        {
            InitializeComponent();
            Inicial();
        }
        private void Inicial()
        {
            dgvOriginal.DataSource = null;
            btnVac.Enabled = false;
            btnExcTra.Enabled = false;
            btnIns.Enabled = false;
            btnLimpiar.Enabled = false;
            btnAus.Enabled = false;
            btnAnalizar.Enabled = false;
            tbxPro.Text = "";
        }
        #region eventosboton
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
            dgvOriginal.ClearSelection();
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
            string hoja = Solicitar.MensajeSolicitar("Ingrese el nombre de la\nhoja que desea abrir:");
            string consultaHojaExcel = "Select *, '' AS DEPARTAMENTO, '' AS PUESTO from [" + hoja + "$]";
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";
            if (string.IsNullOrEmpty(hoja))
            {
                Warning.MensajeWarning("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    if (dgvOriginal.Columns.Count > 0)
                    {
                        dgvOriginal.ClearSelection();
                    }
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
                }
                catch 
                {
                    conexion.Close();
                    Warning.MensajeWarning("Verificar el archivo o \nel nombre de la hoja \n");
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
            ListaInsidencias =  m_Procesar.procesamiento(dataTabla);
            this.BeginInvoke(new Action(() =>
            {
                foreach(var obj in ListaInsidencias)
                {
                    if (obj is Modelos.Errores)
                    {
                        var m_Error = (Modelos.Errores)obj;
                        m_valorError += "Error con el empleado " + m_Error.ID_Empleado + " " +  m_Error.Nombre + " en la columna " + m_Error.Columna + " con valor " + m_Error.Concepto + System.Environment.NewLine;
                    }
                }
                this.tbxPro.Text = m_valorError;
            }));
        }
        public void ProcesarTerminado(object o, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if(this.tbxPro.Text.Equals(""))
                {
                    this.Actionbtn(true);
                    this.btnAus.Enabled = true;
                    this.btnVac.Enabled = true;
                    this.btnExcTra.Enabled = true;
                    this.btnIns.Enabled = true;
                    this.tbcMain.SelectedIndex = 1;
                    Aceptar.MensajeAceptar("Proceso Terminado Correctamente");
                }
                else
                {
                    this.Actionbtn(true);
                    this.btnAus.Enabled = true;
                    this.btnVac.Enabled = true;
                    this.btnExcTra.Enabled = true;
                    this.btnIns.Enabled = true;
                    this.tbcMain.SelectedIndex = 1;
                    Information.MensajeInformation("Proceso terminado con insidencias\n no calculadas revisar la\n pestaña Proceso para más\n informacion");
                }
            }));
            
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

        private void btnVac_Click(object sender, EventArgs e)
        {
            SaveFileDialog m_Archivo = new SaveFileDialog();
            StreamWriter l_Archivo;
            m_Archivo.Filter = "XLS|*.xls";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Vacaciones");
            try
            {
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                    {
                        if (m_Archivo.FileName.Equals(""))
                            m_Archivo.FileName = "Vacaciones";
                        l_Archivo = new StreamWriter(m_Archivo.FileName.Replace(".", String.Concat("", ".")));
                        l_Archivo.WriteLine("EMPLEADO\tCONCEPTO\tFECHA_INICIO\tDIAS" );
                        foreach (var obj in ListaInsidencias)
                        {
                            if (obj is Modelos.Vacaciones)
                            {
                                var m_Vaciones = (Modelos.Vacaciones)obj;
                                l_Archivo.WriteLine(m_Vaciones.ID_Empleado + "\t"+ m_Vaciones.Concepto + "\t" + m_Vaciones.Fecha.ToString("dd/MM/yyyy") + "\t" + m_Vaciones.Dias);
                            }
                        }
                        l_Archivo.Close();
                    }
                Aceptar.MensajeAceptar("Archivo guardado correctamente");
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
            
        }
        private void btnAus_Click(object sender, EventArgs e)
        {
            SaveFileDialog m_Archivo = new SaveFileDialog();
            StreamWriter l_Archivo;
            m_Archivo.Filter = "XLS|*.xls";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Ausencias");
            try
            { 
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (m_Archivo.FileName.Equals(""))
                        m_Archivo.FileName = "Ausencias";
                    l_Archivo = new StreamWriter(m_Archivo.FileName.Replace(".", String.Concat("", ".")));
                    l_Archivo.WriteLine("EMPLEADO\tTIPO_AUSENCIA\tFECHA_INICIO\tCANTIDAD");
                    foreach (var obj in ListaInsidencias)
                    {
                        if (obj is Modelos.Ausencias)
                        {
                            var m_Ausencias = (Modelos.Ausencias)obj;
                            l_Archivo.WriteLine(m_Ausencias.ID_Empleado + "\t" + m_Ausencias.Concepto + "\t" + m_Ausencias.Fecha.ToString("dd/MM/yyyy") + "\t" + m_Ausencias.Cantidad);
                        }
                    }
                    l_Archivo.Close();
                }
                Aceptar.MensajeAceptar("Archivo guardado correctamente");
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
}
        private void btnIns_Click(object sender, EventArgs e)
        {
            SaveFileDialog m_Archivo = new SaveFileDialog();
            StreamWriter l_Archivo;
            m_Archivo.Filter = "XLS|*.xls";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Insidencias");
            try
            {
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (m_Archivo.FileName.Equals(""))
                        m_Archivo.FileName = "Insidencias";
                    l_Archivo = new StreamWriter(m_Archivo.FileName.Replace(".", String.Concat("", ".")));
                    l_Archivo.WriteLine("EMPLEADO\tCONCEPTO\tIMPORTE\tFECHA\tCENTRO_COSTO\tDEPARTAMENTO\tPUESTO");
                    foreach (var obj in ListaInsidencias)
                    {
                        if (obj is Modelos.Insidencias)
                        {
                            var m_Insidencias = (Modelos.Insidencias)obj;
                            l_Archivo.WriteLine(m_Insidencias.ID_Empleado + "\t" + m_Insidencias.Concepto + "\t" + m_Insidencias.Importe + "\t" + m_Insidencias.Fecha.ToString("dd/MM/yyyy") + "\t" + m_CentrosCosto + "\t" + m_Insidencias.Departamento + "\t" + m_Insidencias.Puesto);
                        }
                    }
                    l_Archivo.Close();
                }
                Aceptar.MensajeAceptar("Archivo guardado correctamente");
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
}

        private void btnExcTra_Click(object sender, EventArgs e)
        {
            SaveFileDialog m_Archivo = new SaveFileDialog();
            StreamWriter l_Archivo;
            m_Archivo.Filter = "XLS|*.xls";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Excepciones Trabajadas");
            try
            {
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (m_Archivo.FileName.Equals(""))
                        m_Archivo.FileName = "Excepciones Trabajadas";
                    l_Archivo = new StreamWriter(m_Archivo.FileName.Replace(".", String.Concat("", ".")));
                    l_Archivo.WriteLine("EMPLEADO\tTIPO_EXCEP_TRABAJADA\tFECHA\tMINUTOS_RETARDO");
                    foreach (var obj in ListaInsidencias)
                    {
                        if (obj is Modelos.ExcepcionTrabajada)
                        {
                            var m_ExcTra = (Modelos.ExcepcionTrabajada)obj;
                            l_Archivo.WriteLine(m_ExcTra.ID_Empleado + "\t" + m_ExcTra.Concepto + "\t" + m_ExcTra.Fecha.ToString("dd/MM/yyyy") + "\t" + m_ExcTra.Min_Retardo);
                        }
                    }
                    l_Archivo.Close();
                }
                Aceptar.MensajeAceptar("Archivo guardado correctamente");
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
        }
    }
}
