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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pacman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pacman
            // 
            this.pacman.BackColor = System.Drawing.Color.Transparent;
            this.pacman.Location = new System.Drawing.Point(0, 0);
            this.pacman.Name = "pacman";
            this.pacman.Size = new System.Drawing.Size(18, 18);
            this.pacman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pacman.TabIndex = 0;
            this.pacman.TabStop = false;
            this.pacman.Click += new System.EventHandler(this.pacman_Click);
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.Color.Transparent;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(800, 739);
            this.map.TabIndex = 1;
            this.map.TabStop = false;
            // 
            // TIMER
            // 
            this.TIMER.Enabled = true;
            this.TIMER.Interval = 10;
            this.TIMER.Tick += new System.EventHandler(this.TIMER_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pacman);
            this.panel1.Controls.Add(this.map);
            this.panel1.Location = new System.Drawing.Point(150, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 739);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1112, 813);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pacman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pacman;
        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.Timer TIMER;
        private System.Windows.Forms.Panel panel1;
    }
}

