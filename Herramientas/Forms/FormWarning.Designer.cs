namespace Herramientas.Forms
{
    partial class FormWarning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWarning));
            this.lblTexto = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pbxWarning = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            resources.ApplyResources(this.lblTexto, "lblTexto");
            this.lblTexto.Name = "lblTexto";
            // 
            // btnOk
            // 
            this.btnOk.AllowDrop = true;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbxWarning
            // 
            this.pbxWarning.Image = global::Herramientas.Properties.Resources.warning_icon;
            resources.ApplyResources(this.pbxWarning, "pbxWarning");
            this.pbxWarning.Name = "pbxWarning";
            this.pbxWarning.TabStop = false;
            // 
            // FormWarning
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pbxWarning);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWarning";
            ((System.ComponentModel.ISupportInitialize)(this.pbxWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.PictureBox pbxWarning;
    }
}