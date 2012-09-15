namespace uCom
{
    partial class FormularioCharla
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tbIntro = new System.Windows.Forms.TextBox();
            this.botonEnviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLog
            // 
            this.tbLog.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog.Location = new System.Drawing.Point(12, 12);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(674, 427);
            this.tbLog.TabIndex = 0;
            // 
            // tbIntro
            // 
            this.tbIntro.BackColor = System.Drawing.Color.MistyRose;
            this.tbIntro.Location = new System.Drawing.Point(12, 450);
            this.tbIntro.Name = "tbIntro";
            this.tbIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbIntro.Size = new System.Drawing.Size(593, 20);
            this.tbIntro.TabIndex = 1;
            // 
            // botonEnviar
            // 
            this.botonEnviar.Location = new System.Drawing.Point(611, 445);
            this.botonEnviar.Name = "botonEnviar";
            this.botonEnviar.Size = new System.Drawing.Size(75, 28);
            this.botonEnviar.TabIndex = 2;
            this.botonEnviar.Text = "Enviar";
            this.botonEnviar.UseVisualStyleBackColor = true;
            this.botonEnviar.Click += new System.EventHandler(this.botonEnviar_Click);
            // 
            // FormularioCharla
            // 
            this.AcceptButton = this.botonEnviar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(698, 482);
            this.Controls.Add(this.botonEnviar);
            this.Controls.Add(this.tbIntro);
            this.Controls.Add(this.tbLog);
            this.Name = "FormularioCharla";
            this.Text = "Charla";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormularioCharla_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.TextBox tbIntro;
        private System.Windows.Forms.Button botonEnviar;
    }
}