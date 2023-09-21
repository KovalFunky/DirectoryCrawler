namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusLabel1 = new System.Windows.Forms.Label();
            this.statusLabel2 = new System.Windows.Forms.Label();
            this.buttonSingle = new System.Windows.Forms.Button();
            this.buttonMulti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLabel1
            // 
            this.statusLabel1.AutoSize = true;
            this.statusLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusLabel1.Location = new System.Drawing.Point(12, 9);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(73, 28);
            this.statusLabel1.TabIndex = 0;
            this.statusLabel1.Text = "label1";
            // 
            // statusLabel2
            // 
            this.statusLabel2.AutoSize = true;
            this.statusLabel2.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusLabel2.Location = new System.Drawing.Point(12, 53);
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Size = new System.Drawing.Size(73, 28);
            this.statusLabel2.TabIndex = 0;
            this.statusLabel2.Text = "label1";
            // 
            // buttonSingle
            // 
            this.buttonSingle.Location = new System.Drawing.Point(17, 113);
            this.buttonSingle.Name = "buttonSingle";
            this.buttonSingle.Size = new System.Drawing.Size(118, 46);
            this.buttonSingle.TabIndex = 1;
            this.buttonSingle.Text = "single";
            this.buttonSingle.UseVisualStyleBackColor = true;
            this.buttonSingle.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonMulti
            // 
            this.buttonMulti.Location = new System.Drawing.Point(151, 113);
            this.buttonMulti.Name = "buttonMulti";
            this.buttonMulti.Size = new System.Drawing.Size(118, 46);
            this.buttonMulti.TabIndex = 1;
            this.buttonMulti.Text = "multi";
            this.buttonMulti.UseVisualStyleBackColor = true;
            this.buttonMulti.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMulti);
            this.Controls.Add(this.buttonSingle);
            this.Controls.Add(this.statusLabel2);
            this.Controls.Add(this.statusLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel1;
        private System.Windows.Forms.Label statusLabel2;
        private System.Windows.Forms.Button buttonSingle;
        private System.Windows.Forms.Button buttonMulti;
    }
}

