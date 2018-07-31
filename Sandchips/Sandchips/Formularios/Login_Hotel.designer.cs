namespace Sandchips.Formularios
{
    partial class Login_Hotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Hotel));
            this.btnacceder = new System.Windows.Forms.Button();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.mtbcontraseña = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnacceder
            // 
            this.btnacceder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnacceder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnacceder.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnacceder.ForeColor = System.Drawing.Color.White;
            this.btnacceder.Location = new System.Drawing.Point(248, 587);
            this.btnacceder.Margin = new System.Windows.Forms.Padding(4);
            this.btnacceder.Name = "btnacceder";
            this.btnacceder.Size = new System.Drawing.Size(175, 74);
            this.btnacceder.TabIndex = 26;
            this.btnacceder.Text = "Acceder";
            this.btnacceder.UseVisualStyleBackColor = true;
            this.btnacceder.Click += new System.EventHandler(this.btnacceder_Click);
            this.btnacceder.Enter += new System.EventHandler(this.btnacceder_Enter);
            // 
            // txtusuario
            // 
            this.txtusuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtusuario.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.Location = new System.Drawing.Point(143, 287);
            this.txtusuario.Margin = new System.Windows.Forms.Padding(600, 0, 0, 600);
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(387, 54);
            this.txtusuario.TabIndex = 1;
            this.txtusuario.TextChanged += new System.EventHandler(this.txtusuario_TextChanged);
            this.txtusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusuario_KeyPress);
            // 
            // mtbcontraseña
            // 
            this.mtbcontraseña.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mtbcontraseña.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbcontraseña.Location = new System.Drawing.Point(143, 477);
            this.mtbcontraseña.Margin = new System.Windows.Forms.Padding(4);
            this.mtbcontraseña.Name = "mtbcontraseña";
            this.mtbcontraseña.PasswordChar = '*';
            this.mtbcontraseña.Size = new System.Drawing.Size(387, 54);
            this.mtbcontraseña.TabIndex = 2;
            this.mtbcontraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbcontraseña_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(820, 794);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(822, 795);
            this.Controls.Add(this.mtbcontraseña);
            this.Controls.Add(this.btnacceder);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login_Hotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel_Reservacion_y_Chequeo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Enter += new System.EventHandler(this.Login_Hotel_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnacceder;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.MaskedTextBox mtbcontraseña;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}