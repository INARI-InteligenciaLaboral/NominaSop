namespace Herramientas.Forms
{
    partial class FormInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformation));
            this.lblTexto = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbxInformation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.Location = new System.Drawing.Point(150, 12);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(35, 13);
            this.lblTexto.TabIndex = 5;
            this.lblTexto.Text = "label1";
            // 
            // btnOk
            // 
            this.btnOk.AllowDrop = true;
            this.btnOk.Location = new System.Drawing.Point(180, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbxInformation
            // 
            this.pbxInformation.Image = global::Herramientas.Properties.Resources.Informacion;
            this.pbxInformation.Location = new System.Drawing.Point(21, 12);
            this.pbxInformation.Name = "pbxInformation";
            this.pbxInformation.Size = new System.Drawing.Size(100, 101);
            this.pbxInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxInformation.TabIndex = 3;
            this.pbxInformation.TabStop = false;
            // 
            // FormInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 125);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pbxInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 163);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 163);
            this.Name = "FormInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Information";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbxInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pbxInformation;
    }
}