using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Herramientas.Clases;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

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
            m_Archivo.Filter = "XLSX|*.xlsx";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Vacaciones");
            try
            {
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                    {
                        if (m_Archivo.FileName.Equals(""))
                                m_Archivo.FileName = "Vacaciones";
                        int m_Filas = 0;
                        using (FileStream stream = new FileStream(m_Archivo.FileName, FileMode.Create, FileAccess.Write))
                        {
                            IWorkbook wb = new XSSFWorkbook();
                            ISheet sheet = wb.CreateSheet("Vacaciones");
                            ICreationHelper cH = wb.GetCreationHelper();
                            IRow row = sheet.CreateRow(m_Filas);
                            ICell cellID = row.CreateCell(0);
                            cellID.SetCellValue(cH.CreateRichTextString("EMPLEADO"));
                            ICell cellCo = row.CreateCell(1);
                            cellCo.SetCellValue(cH.CreateRichTextString("CONCEPTO"));
                            ICell cellUn = row.CreateCell(2);
                            cellUn.SetCellValue(cH.CreateRichTextString("FECHA_INICIO"));
                            ICell cellIm = row.CreateCell(3);
                            cellIm.SetCellValue(cH.CreateRichTextString("DIAS"));
                            m_Filas++;
                            foreach (var obj in ListaInsidencias)
                            {
                                IRow rows = sheet.CreateRow(m_Filas);
                                if (obj is Modelos.Vacaciones)
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        var m_Vacaciones = (Modelos.Vacaciones)obj;
                                        if (!m_Vacaciones.ID_Empleado.ToString().Equals("") && !(m_Vacaciones.ID_Empleado == string.Empty))
                                        {
                                            ICell cell = rows.CreateCell(j);
                                            if (j == 0)
                                                cell.SetCellValue(cH.CreateRichTextString(m_Vacaciones.ID_Empleado.ToString()));
                                            else if (j == 1)
                                                cell.SetCellValue(cH.CreateRichTextString(m_Vacaciones.Concepto.ToString()));
                                            else if (j == 2)
                                                cell.SetCellValue(cH.CreateRichTextString(m_Vacaciones.Fecha.ToString("dd/MM/yyyy")));
                                            else if (j == 3)
                                                cell.SetCellValue(cH.CreateRichTextString(m_Vacaciones.Dias.ToString()));
                                        }
                                    }
                                    m_Filas++;
                                }
                            }
                            wb.Write(stream);
                            Aceptar.MensajeAceptar("Archivo guardado correctamente");
                        }
                    }
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
        }
        private void btnAus_Click(object sender, EventArgs e)
        {
            SaveFileDialog m_Archivo = new SaveFileDialog();
            int m_Filas = 0;
            m_Archivo.Filter = "XLSX|*.xlsx";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Ausencias");
            try
            { 
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (m_Archivo.FileName.Equals(""))
                        m_Archivo.FileName = "Ausencias";
                    using (FileStream stream = new FileStream(m_Archivo.FileName, FileMode.Create, FileAccess.Write))
                    {
                        IWorkbook wb = new XSSFWorkbook();
                        ISheet sheet = wb.CreateSheet("Ausencias");
                        ICreationHelper cH = wb.GetCreationHelper();
                        IRow row = sheet.CreateRow(m_Filas);
                        ICell cellID = row.CreateCell(0);
                        cellID.SetCellValue(cH.CreateRichTextString("EMPLEADO"));
                        ICell cellAu = row.CreateCell(1);
                        cellAu.SetCellValue(cH.CreateRichTextString("TIPO_AUSENCIA"));
                        ICell cellIn = row.CreateCell(2);
                        cellIn.SetCellValue(cH.CreateRichTextString("FECHA_INICIO"));
                        ICell cellCa = row.CreateCell(3);
                        cellCa.SetCellValue(cH.CreateRichTextString("CANTIDAD"));
                        m_Filas++;
                        foreach (var obj in ListaInsidencias)
                        {
                            IRow rows = sheet.CreateRow(m_Filas);
                            if (obj is Modelos.Ausencias)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    var m_Ausencias = (Modelos.Ausencias)obj;
                                    ICell cell = rows.CreateCell(j);
                                    if (j == 0)
                                        cell.SetCellValue(cH.CreateRichTextString(m_Ausencias.ID_Empleado.ToString()));
                                    else if (j == 1)
                                        cell.SetCellValue(cH.CreateRichTextString(m_Ausencias.Concepto.ToString()));
                                    else if (j == 2)
                                        cell.SetCellValue(cH.CreateRichTextString(m_Ausencias.Fecha.ToString("dd/MM/yyyy")));
                                    else if (j == 3)
                                        cell.SetCellValue(cH.CreateRichTextString(m_Ausencias.Cantidad.ToString()));
                                }
                                m_Filas++;
                            }
                        }
                        wb.Write(stream);
                        Aceptar.MensajeAceptar("Archivo guardado correctamente");
                    }
                }
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
            
        }
        private void btnIns_Click(object sender, EventArgs e)
        {
            SaveFileDialog m_Archivo = new SaveFileDialog();
            m_Archivo.Filter = "XLSX|*.xlsx";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Insidencias");
            try
            {
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (m_Archivo.FileName.Equals(""))
                        m_Archivo.FileName = "Insidencias";
                    int m_Filas = 0;
                    using (FileStream stream = new FileStream(m_Archivo.FileName, FileMode.Create, FileAccess.Write))
                    {
                        IWorkbook wb = new XSSFWorkbook();
                        ISheet sheet = wb.CreateSheet("Incidencias");
                        ICreationHelper cH = wb.GetCreationHelper();
                        IRow row = sheet.CreateRow(m_Filas);
                        ICell cellID = row.CreateCell(0);
                        cellID.SetCellValue(cH.CreateRichTextString("EMPLEADO"));
                        ICell cellCo = row.CreateCell(1);
                        cellCo.SetCellValue(cH.CreateRichTextString("CONCEPTO"));
                        ICell cellUn = row.CreateCell(2);
                        cellUn.SetCellValue(cH.CreateRichTextString("UNIDADES"));
                        ICell cellIm = row.CreateCell(3);
                        cellIm.SetCellValue(cH.CreateRichTextString("IMPORTE"));
                        ICell cellFe = row.CreateCell(4);
                        cellFe.SetCellValue(cH.CreateRichTextString("FECHA"));
                        ICell cellCe = row.CreateCell(5);
                        cellCe.SetCellValue(cH.CreateRichTextString("CENTRO_COSTO"));
                        ICell cellDe = row.CreateCell(6);
                        cellDe.SetCellValue(cH.CreateRichTextString("DEPARTAMENTO"));
                        ICell cellPu = row.CreateCell(7);
                        cellPu.SetCellValue(cH.CreateRichTextString("PUESTO"));
                        m_Filas++;
                        foreach (var obj in ListaInsidencias)
                        {
                            IRow rows = sheet.CreateRow(m_Filas);
                            if (obj is Modelos.Insidencias)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    var m_Insidencias = (Modelos.Insidencias)obj;
                                    if (!m_Insidencias.ID_Empleado.ToString().Equals("") && !(m_Insidencias.ID_Empleado == string.Empty))
                                    {
                                        ICell cell = rows.CreateCell(j);
                                        if (j == 0)
                                            cell.SetCellValue(cH.CreateRichTextString(m_Insidencias.ID_Empleado.ToString()));
                                        else if (j == 1)
                                            cell.SetCellValue(cH.CreateRichTextString(m_Insidencias.Concepto.ToString()));
                                        else if (j == 2)
                                            cell.SetCellValue(cH.CreateRichTextString(m_Insidencias.Unidades.ToString()));
                                        else if (j == 3)
                                            cell.SetCellValue(cH.CreateRichTextString(m_Insidencias.Importe.ToString()));
                                        else if (j == 4)
                                            cell.SetCellValue(cH.CreateRichTextString(m_Insidencias.Fecha.ToString("dd/MM/yyyy")));
                                        else if (j == 5)
                                            cell.SetCellValue(cH.CreateRichTextString(m_CentrosCosto));
                                        else if (j == 6)
                                            cell.SetCellValue(cH.CreateRichTextString(m_Insidencias.Departamento.ToString()));
                                        else if (j == 7)
                                            cell.SetCellValue(cH.CreateRichTextString(m_Insidencias.Puesto.ToString()));
                                    }
                                }
                                m_Filas++;
                            }
                        }
                        wb.Write(stream);
                        Aceptar.MensajeAceptar("Archivo guardado correctamente");
                    }
                }
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
}

        private void btnExcTra_Click(object sender, EventArgs e)
        {
            SaveFileDialog m_Archivo = new SaveFileDialog();
            m_Archivo.Filter = "XLSX|*.xlsx";
            m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Excepciones Trabajadas");
            try
            {
                if (m_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (m_Archivo.FileName.Equals(""))
                        m_Archivo.FileName = "Excepciones Trabajadas";

                    int m_Filas = 0;
                    using (FileStream stream = new FileStream(m_Archivo.FileName, FileMode.Create, FileAccess.Write))
                    {
                        IWorkbook wb = new XSSFWorkbook();
                        ISheet sheet = wb.CreateSheet("Excepciones Trabajadas");
                        ICreationHelper cH = wb.GetCreationHelper();
                        IRow row = sheet.CreateRow(m_Filas);
                        ICell cellID = row.CreateCell(0);
                        cellID.SetCellValue(cH.CreateRichTextString("EMPLEADO"));
                        ICell cellCo = row.CreateCell(1);
                        cellCo.SetCellValue(cH.CreateRichTextString("TIPO_EXCEP_TRABAJADA"));
                        ICell cellUn = row.CreateCell(2);
                        cellUn.SetCellValue(cH.CreateRichTextString("FECHA"));
                        ICell cellIm = row.CreateCell(3);
                        cellIm.SetCellValue(cH.CreateRichTextString("MINUTOS_RETARDO"));
                        m_Filas++;
                        foreach (var obj in ListaInsidencias)
                        {
                            IRow rows = sheet.CreateRow(m_Filas);
                            if (obj is Modelos.ExcepcionTrabajada)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    var m_ExcepcionTrabajada = (Modelos.ExcepcionTrabajada)obj;
                                    if (!m_ExcepcionTrabajada.ID_Empleado.ToString().Equals("") && !(m_ExcepcionTrabajada.ID_Empleado == string.Empty))
                                    {
                                        ICell cell = rows.CreateCell(j);
                                        if (j == 0)
                                            cell.SetCellValue(cH.CreateRichTextString(m_ExcepcionTrabajada.ID_Empleado.ToString()));
                                        else if (j == 1)
                                            cell.SetCellValue(cH.CreateRichTextString(m_ExcepcionTrabajada.Concepto.ToString()));
                                        else if (j == 2)
                                            cell.SetCellValue(cH.CreateRichTextString(m_ExcepcionTrabajada.Fecha.ToString("dd/MM/yyyy")));
                                        else if (j == 3)
                                            cell.SetCellValue(cH.CreateRichTextString(m_ExcepcionTrabajada.Min_Retardo.ToString()));
                                    }
                                }
                                m_Filas++;
                            }
                        }
                        wb.Write(stream);
                        Aceptar.MensajeAceptar("Archivo guardado correctamente");
                    }
                }
            }
            catch
            {
                Warning.MensajeWarning("Error al crear archivos");
            }
        }
    }
}
