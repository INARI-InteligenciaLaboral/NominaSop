namespace Herramientas.Forms
{
    partial class FormSolicitar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSolicitar));
            this.lblTexto = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbxSolicitar = new System.Windows.Forms.PictureBox();
            this.tbxSolicitar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSolicitar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(149, 12);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(35, 13);
            this.lblTexto.TabIndex = 5;
            this.lblTexto.Text = "label1";
            // 
            // btnOk
            // 
            this.btnOk.AllowDrop = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(239, 90);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbxSolicitar
            // 
            this.pbxSolicitar.Image = global::Herramientas.Properties.Resources.registro;
            this.pbxSolicitar.Location = new System.Drawing.Point(24, 12);
            this.pbxSolicitar.Name = "pbxSolicitar";
            this.pbxSolicitar.Size = new System.Drawing.Size(100, 101);
            this.pbxSolicitar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxSolicitar.TabIndex = 3;
            this.pbxSolicitar.TabStop = false;
            // 
            // tbxSolicitar
            // 
            this.tbxSolicitar.Location = new System.Drawing.Point(152, 54);
            this.tbxSolicitar.MaxLength = 40;
            this.tbxSolicitar.Name = "tbxSolicitar";
            this.tbxSolicitar.Size = new System.Drawing.Size(162, 20);
            this.tbxSolicitar.TabIndex = 6;
            this.tbxSolicitar.Text = "Hoja1";
            // 
            // FormSolicitar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 125);
            this.Controls.Add(this.tbxSolicitar);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pbxSolicitar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 163);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 163);
            this.Name = "FormSolicitar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Introducir";
            ((System.ComponentModel.ISupportInitialize)(this.pbxSolicitar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pbxSolicitar;
        private System.Windows.Forms.TextBox tbxSolicitar;
    }
}