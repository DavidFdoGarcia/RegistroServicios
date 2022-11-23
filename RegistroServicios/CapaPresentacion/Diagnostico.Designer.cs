namespace RegistroServicios.CapaPresentacion
{
    partial class Diagnostico
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txDiagnostico = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDiagnostico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(126, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Diagnóstico";
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(220, 74);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(72, 20);
            this.txtOrden.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(69, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "No. Orden:";
            // 
            // txDiagnostico
            // 
            this.txDiagnostico.Location = new System.Drawing.Point(142, 138);
            this.txDiagnostico.Multiline = true;
            this.txDiagnostico.Name = "txDiagnostico";
            this.txDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txDiagnostico.Size = new System.Drawing.Size(216, 184);
            this.txDiagnostico.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(23, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Diagnóstico:";
            // 
            // btnDiagnostico
            // 
            this.btnDiagnostico.Font = new System.Drawing.Font("Century Gothic", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiagnostico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDiagnostico.Location = new System.Drawing.Point(250, 365);
            this.btnDiagnostico.Name = "btnDiagnostico";
            this.btnDiagnostico.Size = new System.Drawing.Size(108, 42);
            this.btnDiagnostico.TabIndex = 17;
            this.btnDiagnostico.Text = "Diagnostico";
            this.btnDiagnostico.UseVisualStyleBackColor = true;
            this.btnDiagnostico.Click += new System.EventHandler(this.btnDiagnostico_Click);
            // 
            // Diagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 446);
            this.Controls.Add(this.btnDiagnostico);
            this.Controls.Add(this.txDiagnostico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOrden);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Diagnostico";
            this.Text = "Diagnostico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txDiagnostico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDiagnostico;
    }
}