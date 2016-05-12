namespace NominaSoprade
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpOriginal = new System.Windows.Forms.TabPage();
            this.dgvOriginal = new System.Windows.Forms.DataGridView();
            this.tbpNoPro = new System.Windows.Forms.TabPage();
            this.tbxNoPro = new System.Windows.Forms.TextBox();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnExcTra = new System.Windows.Forms.Button();
            this.btnAus = new System.Windows.Forms.Button();
            this.btnVac = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tbpOriginal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOriginal)).BeginInit();
            this.tbpNoPro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpOriginal);
            this.tbcMain.Controls.Add(this.tbpNoPro);
            this.tbcMain.Location = new System.Drawing.Point(12, 75);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(760, 474);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpOriginal
            // 
            this.tbpOriginal.Controls.Add(this.dgvOriginal);
            this.tbpOriginal.Location = new System.Drawing.Point(4, 22);
            this.tbpOriginal.Name = "tbpOriginal";
            this.tbpOriginal.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOriginal.Size = new System.Drawing.Size(752, 448);
            this.tbpOriginal.TabIndex = 0;
            this.tbpOriginal.Text = "Original";
            this.tbpOriginal.UseVisualStyleBackColor = true;
            // 
            // dgvOriginal
            // 
            this.dgvOriginal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOriginal.Location = new System.Drawing.Point(6, 6);
            this.dgvOriginal.Name = "dgvOriginal";
            this.dgvOriginal.Size = new System.Drawing.Size(740, 436);
            this.dgvOriginal.TabIndex = 0;
            // 
            // tbpNoPro
            // 
            this.tbpNoPro.Controls.Add(this.btnIns);
            this.tbpNoPro.Controls.Add(this.btnExcTra);
            this.tbpNoPro.Controls.Add(this.btnAus);
            this.tbpNoPro.Controls.Add(this.btnVac);
            this.tbpNoPro.Controls.Add(this.tbxNoPro);
            this.tbpNoPro.Location = new System.Drawing.Point(4, 22);
            this.tbpNoPro.Name = "tbpNoPro";
            this.tbpNoPro.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNoPro.Size = new System.Drawing.Size(752, 448);
            this.tbpNoPro.TabIndex = 1;
            this.tbpNoPro.Text = "No procesados";
            this.tbpNoPro.UseVisualStyleBackColor = true;
            // 
            // tbxNoPro
            // 
            this.tbxNoPro.Location = new System.Drawing.Point(6, 6);
            this.tbxNoPro.Multiline = true;
            this.tbxNoPro.Name = "tbxNoPro";
            this.tbxNoPro.Size = new System.Drawing.Size(614, 436);
            this.tbxNoPro.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxLogo.Image = global::NominaSoprade.Properties.Resources.logoInaari;
            this.pbxLogo.Location = new System.Drawing.Point(704, -1);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(58, 92);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 4;
            this.pbxLogo.TabStop = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Image = global::NominaSoprade.Properties.Resources.Custom_Icon_Design_Flatastic_9_Generate_tables;
            this.btnProcesar.Location = new System.Drawing.Point(142, 12);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(120, 38);
            this.btnProcesar.TabIndex = 3;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Image = global::NominaSoprade.Properties.Resources.Seanau_Email_Clear;
            this.btnLimpiar.Location = new System.Drawing.Point(268, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Image = global::NominaSoprade.Properties.Resources.Treetog_Junior_Document_excel;
            this.btnCargar.Location = new System.Drawing.Point(16, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(120, 38);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Text = "Cargar Archivo";
            this.btnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnIns
            // 
            this.btnIns.Image = global::NominaSoprade.Properties.Resources.User_Folder;
            this.btnIns.Location = new System.Drawing.Point(626, 185);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(120, 55);
            this.btnIns.TabIndex = 5;
            this.btnIns.Text = "Insidencias";
            this.btnIns.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIns.UseVisualStyleBackColor = true;
            // 
            // btnExcTra
            // 
            this.btnExcTra.Image = global::NominaSoprade.Properties.Resources.Timetable;
            this.btnExcTra.Location = new System.Drawing.Point(626, 124);
            this.btnExcTra.Name = "btnExcTra";
            this.btnExcTra.Size = new System.Drawing.Size(120, 55);
            this.btnExcTra.TabIndex = 4;
            this.btnExcTra.Text = "Excepciones Trabajadas";
            this.btnExcTra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcTra.UseVisualStyleBackColor = true;
            // 
            // btnAus
            // 
            this.btnAus.Image = global::NominaSoprade.Properties.Resources.Mythique_Design_Original_Messenger_Absent_blue;
            this.btnAus.Location = new System.Drawing.Point(626, 63);
            this.btnAus.Name = "btnAus";
            this.btnAus.Size = new System.Drawing.Size(120, 55);
            this.btnAus.TabIndex = 3;
            this.btnAus.Text = "Ausencias";
            this.btnAus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAus.UseVisualStyleBackColor = true;
            // 
            // btnVac
            // 
            this.btnVac.Image = global::NominaSoprade.Properties.Resources.Corwins_Mountains_Of_Madness_Tracking_route;
            this.btnVac.Location = new System.Drawing.Point(626, 6);
            this.btnVac.Name = "btnVac";
            this.btnVac.Size = new System.Drawing.Size(120, 51);
            this.btnVac.TabIndex = 2;
            this.btnVac.Text = "Vacaciones";
            this.btnVac.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVac.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.tbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inari Inteligencia Laboral";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tbcMain.ResumeLayout(false);
            this.tbpOriginal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOriginal)).EndInit();
            this.tbpNoPro.ResumeLayout(false);
            this.tbpNoPro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpOriginal;
        private System.Windows.Forms.TabPage tbpNoPro;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.DataGridView dgvOriginal;
        private System.Windows.Forms.Button btnVac;
        private System.Windows.Forms.TextBox tbxNoPro;
        private System.Windows.Forms.Button btnAus;
        private System.Windows.Forms.Button btnExcTra;
        private System.Windows.Forms.Button btnIns;
    }
}

