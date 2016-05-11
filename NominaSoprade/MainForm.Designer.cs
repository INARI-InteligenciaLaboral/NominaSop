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
            this.tbpNoPro = new System.Windows.Forms.TabPage();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.dgvOriginal = new System.Windows.Forms.DataGridView();
            this.tbcMain.SuspendLayout();
            this.tbpOriginal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOriginal)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpOriginal);
            this.tbcMain.Controls.Add(this.tbpNoPro);
            this.tbcMain.Location = new System.Drawing.Point(12, 75);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(660, 374);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpOriginal
            // 
            this.tbpOriginal.Controls.Add(this.dgvOriginal);
            this.tbpOriginal.Location = new System.Drawing.Point(4, 22);
            this.tbpOriginal.Name = "tbpOriginal";
            this.tbpOriginal.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOriginal.Size = new System.Drawing.Size(652, 348);
            this.tbpOriginal.TabIndex = 0;
            this.tbpOriginal.Text = "Original";
            this.tbpOriginal.UseVisualStyleBackColor = true;
            // 
            // tbpNoPro
            // 
            this.tbpNoPro.Location = new System.Drawing.Point(4, 22);
            this.tbpNoPro.Name = "tbpNoPro";
            this.tbpNoPro.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNoPro.Size = new System.Drawing.Size(652, 348);
            this.tbpNoPro.TabIndex = 1;
            this.tbpNoPro.Text = "No procesados";
            this.tbpNoPro.UseVisualStyleBackColor = true;
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxLogo.Image = global::NominaSoprade.Properties.Resources.logoInaari;
            this.pbxLogo.Location = new System.Drawing.Point(604, -1);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(58, 92);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 4;
            this.pbxLogo.TabStop = false;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Image = global::NominaSoprade.Properties.Resources.Custom_Icon_Design_Flatastic_9_Generate_tables;
            this.btnProcesar.Location = new System.Drawing.Point(142, 12);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(120, 38);
            this.btnProcesar.TabIndex = 3;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProcesar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::NominaSoprade.Properties.Resources.Seanau_Email_Clear;
            this.btnLimpiar.Location = new System.Drawing.Point(268, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 38);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
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
            // dgvOriginal
            // 
            this.dgvOriginal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOriginal.Location = new System.Drawing.Point(6, 6);
            this.dgvOriginal.Name = "dgvOriginal";
            this.dgvOriginal.Size = new System.Drawing.Size(640, 336);
            this.dgvOriginal.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.tbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inari Inteligencia Laboral";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tbcMain.ResumeLayout(false);
            this.tbpOriginal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOriginal)).EndInit();
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
    }
}

