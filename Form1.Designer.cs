namespace pac_man
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pacman = new System.Windows.Forms.PictureBox();
            this.map = new System.Windows.Forms.PictureBox();
            this.TIMER = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pacman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // pacman
            // 
            this.pacman.BackColor = System.Drawing.Color.Transparent;
            this.pacman.Location = new System.Drawing.Point(153, 32);
            this.pacman.Name = "pacman";
            this.pacman.Size = new System.Drawing.Size(15, 15);
            this.pacman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pacman.TabIndex = 0;
            this.pacman.TabStop = false;
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.Color.Transparent;
            this.map.Location = new System.Drawing.Point(150, 30);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(600, 600);
            this.map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.map.TabIndex = 1;
            this.map.TabStop = false;
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 10;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(851, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "score";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1112, 813);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pacman);
            this.Controls.Add(this.map);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pacman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pacman;
        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Label label1;
    }
}

