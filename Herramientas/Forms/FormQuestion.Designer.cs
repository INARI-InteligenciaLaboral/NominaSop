namespace Herramientas.Forms
{
    partial class FormQuestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuestion));
            this.lblTexto = new System.Windows.Forms.Label();
            this.pbxQuestion = new System.Windows.Forms.PictureBox();
            this.btnsi = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTexto
            // 
            this.lblTexto.AutoSize = true;
            this.lblTexto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTexto.Location = new System.Drawing.Point(158, 12);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(35, 13);
            this.lblTexto.TabIndex = 7;
            this.lblTexto.Text = "label1";
            // 
            // pbxQuestion
            // 
            this.pbxQuestion.Image = global::Herramientas.Properties.Resources.Ambox_blue_question;
            this.pbxQuestion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbxQuestion.Location = new System.Drawing.Point(28, 12);
            this.pbxQuestion.Name = "pbxQuestion";
            this.pbxQuestion.Size = new System.Drawing.Size(100, 101);
            this.pbxQuestion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxQuestion.TabIndex = 6;
            this.pbxQuestion.TabStop = false;
            // 
            // btnsi
            // 
            this.btnsi.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnsi.Location = new System.Drawing.Point(148, 90);
            this.btnsi.Name = "btnsi";
            this.btnsi.Size = new System.Drawing.Size(75, 23);
            this.btnsi.TabIndex = 8;
            this.btnsi.Text = "Sí";
            this.btnsi.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(239, 90);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 9;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            // 
            // FormQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 125);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnsi);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.pbxQuestion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 163);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(342, 163);
            this.Name = "FormQuestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregunta";
            ((System.ComponentModel.ISupportInitialize)(this.pbxQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.PictureBox pbxQuestion;
        private System.Windows.Forms.Button btnsi;
        private System.Windows.Forms.Button btnNo;
    }
}