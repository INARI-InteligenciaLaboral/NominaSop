namespace Herramientas.Forms
{
    partial class FormAceptar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAceptar));
            this.pbxAceptar = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblTexto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAceptar)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxAceptar
            // 
            this.pbxAceptar.Image = global::Herramientas.Properties.Resources.ck_tick;
            this.pbxAceptar.Location = new System.Drawing.Point(22, 12);
            this.pbxAceptar.Name = "pbxAceptar";
            this.pbxAceptar.Size = new System.Drawing.Size(100, 101);
            this.pbxAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAceptar.TabIndex = 0;
            this.pbxAceptar.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.AllowDrop = true;
            this.btnOk.Location = new System.Drawing.Point(181, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(138, 31);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(35, 13);
            this.lblTexto.TabIndex = 2;
            this.lblTexto.Text = "label1";
            // 
            // FormAceptar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 125);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pbxAceptar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 163);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 163);
            this.Name = "FormAceptar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aceptar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAceptar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAceptar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAceptar;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.Label lblTexto;
    }
}