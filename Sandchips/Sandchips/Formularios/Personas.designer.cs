
namespace Sandchips.Formularios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txta = new System.Windows.Forms.Label();
            this.txtT = new System.Windows.Forms.Label();
            this.txtG = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.Label();
            this.txtEC = new System.Windows.Forms.Label();
            this.txtTe = new System.Windows.Forms.Label();
            this.txtMu = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtEstadoCivil = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdPersonas = new System.Windows.Forms.TextBox();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.cmbGenero = new System.Windows.Forms.ComboBox();
            this.cmbMunicipio = new System.Windows.Forms.ComboBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(53, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txta
            // 
            this.txta.AutoSize = true;
            this.txta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txta.Location = new System.Drawing.Point(51, 224);
            this.txta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txta.Name = "txta";
            this.txta.Size = new System.Drawing.Size(62, 17);
            this.txta.TabIndex = 1;
            this.txta.Text = "Apellido:";
            // 
            // txtT
            // 
            this.txtT.AutoSize = true;
            this.txtT.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtT.Location = new System.Drawing.Point(51, 410);
            this.txtT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtT.Name = "txtT";
            this.txtT.Size = new System.Drawing.Size(136, 17);
            this.txtT.TabIndex = 2;
            this.txtT.Text = "Tipo de Documento:";
            // 
            // txtG
            // 
            this.txtG.AutoSize = true;
            this.txtG.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtG.Location = new System.Drawing.Point(53, 543);
            this.txtG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(60, 17);
            this.txtG.TabIndex = 4;
            this.txtG.Text = "Género:";
            // 
            // txtC
            // 
            this.txtC.AutoSize = true;
            this.txtC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtC.Location = new System.Drawing.Point(51, 257);
            this.txtC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(129, 17);
            this.txtC.TabIndex = 5;
            this.txtC.Text = "Correo Electronico:";
            // 
            // txtD
            // 
            this.txtD.AutoSize = true;
            this.txtD.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtD.Location = new System.Drawing.Point(51, 290);
            this.txtD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(64, 17);
            this.txtD.TabIndex = 6;
            this.txtD.Text = "Direción:";
            // 
            // txtN
            // 
            this.txtN.AutoSize = true;
            this.txtN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtN.Location = new System.Drawing.Point(51, 443);
            this.txtN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(158, 17);
            this.txtN.TabIndex = 7;
            this.txtN.Text = "Numero de Documento:";
            // 
            // txtEC
            // 
            this.txtEC.AutoSize = true;
            this.txtEC.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEC.Location = new System.Drawing.Point(53, 476);
            this.txtEC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtEC.Name = "txtEC";
            this.txtEC.Size = new System.Drawing.Size(85, 17);
            this.txtEC.TabIndex = 8;
            this.txtEC.Text = "Estado Civil:";
            // 
            // txtTe
            // 
            this.txtTe.AutoSize = true;
            this.txtTe.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTe.Location = new System.Drawing.Point(51, 510);
            this.txtTe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTe.Name = "txtTe";
            this.txtTe.Size = new System.Drawing.Size(68, 17);
            this.txtTe.TabIndex = 9;
            this.txtTe.Text = "Telefono:";
            // 
            // txtMu
            // 
            this.txtMu.AutoSize = true;
            this.txtMu.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMu.Location = new System.Drawing.Point(53, 576);
            this.txtMu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtMu.Name = "txtMu";
            this.txtMu.Size = new System.Drawing.Size(71, 17);
            this.txtMu.TabIndex = 11;
            this.txtMu.Text = "Municipio:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(215, 191);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(248, 22);
            this.txtNombre.TabIndex = 12;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(215, 224);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(248, 22);
            this.txtApellido.TabIndex = 13;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(215, 257);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(248, 22);
            this.txtCorreo.TabIndex = 14;
            // 
            // txtEstadoCivil
            // 
            this.txtEstadoCivil.Location = new System.Drawing.Point(215, 476);
            this.txtEstadoCivil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEstadoCivil.Name = "txtEstadoCivil";
            this.txtEstadoCivil.Size = new System.Drawing.Size(248, 22);
            this.txtEstadoCivil.TabIndex = 18;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(215, 510);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(248, 22);
            this.txtTelefono.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(504, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 143);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(669, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 68);
            this.label4.TabIndex = 45;
            this.label4.Text = "Sandchip\'s ";
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowDrop = true;
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.AllowUserToResizeColumns = false;
            this.dgvPersonas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            this.dgvPersonas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Location = new System.Drawing.Point(503, 235);
            this.dgvPersonas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPersonas.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvPersonas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonas.ShowCellErrors = false;
            this.dgvPersonas.ShowRowErrors = false;
            this.dgvPersonas.Size = new System.Drawing.Size(720, 281);
            this.dgvPersonas.TabIndex = 46;
            this.dgvPersonas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonas_CellClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(528, 543);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 28);
            this.btnGuardar.TabIndex = 47;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(716, 543);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 28);
            this.btnActualizar.TabIndex = 48;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(1076, 543);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 28);
            this.btnEliminar.TabIndex = 49;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(889, 543);
            this.btnMostrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(100, 28);
            this.btnMostrar.TabIndex = 50;
            this.btnMostrar.Text = "Consultar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(503, 188);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 51;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(644, 192);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(384, 22);
            this.txtBuscar.TabIndex = 52;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Rockwell", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(16, 41);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(254, 49);
            this.label13.TabIndex = 53;
            this.label13.Text = "Registro de";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Rockwell", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label14.Location = new System.Drawing.Point(25, 94);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(206, 49);
            this.label14.TabIndex = 54;
            this.label14.Text = "personas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(53, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 55;
            this.label2.Text = "Id Personas:";
            // 
            // txtIdPersonas
            // 
            this.txtIdPersonas.Enabled = false;
            this.txtIdPersonas.Location = new System.Drawing.Point(215, 156);
            this.txtIdPersonas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIdPersonas.Name = "txtIdPersonas";
            this.txtIdPersonas.Size = new System.Drawing.Size(248, 22);
            this.txtIdPersonas.TabIndex = 56;
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Items.AddRange(new object[] {
            "Seleccione una opción",
            "Cédula",
            "DUI",
            "Otro"});
            this.cmbTipoDoc.Location = new System.Drawing.Point(215, 409);
            this.cmbTipoDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(248, 24);
            this.cmbTipoDoc.TabIndex = 57;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Location = new System.Drawing.Point(215, 443);
            this.txtNumDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(248, 22);
            this.txtNumDoc.TabIndex = 17;
            // 
            // cmbGenero
            // 
            this.cmbGenero.FormattingEnabled = true;
            this.cmbGenero.Items.AddRange(new object[] {
            "Seleccione una opción",
            "Masculino",
            "Femenino"});
            this.cmbGenero.Location = new System.Drawing.Point(215, 543);
            this.cmbGenero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbGenero.Name = "cmbGenero";
            this.cmbGenero.Size = new System.Drawing.Size(248, 24);
            this.cmbGenero.TabIndex = 58;
            // 
            // cmbMunicipio
            // 
            this.cmbMunicipio.FormattingEnabled = true;
            this.cmbMunicipio.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbMunicipio.Location = new System.Drawing.Point(215, 576);
            this.cmbMunicipio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMunicipio.Name = "cmbMunicipio";
            this.cmbMunicipio.Size = new System.Drawing.Size(248, 24);
            this.cmbMunicipio.TabIndex = 59;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(215, 290);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(248, 110);
            this.txtDireccion.TabIndex = 15;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiar.Location = new System.Drawing.Point(1123, 185);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 60;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1268, 646);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmbMunicipio);
            this.Controls.Add(this.cmbGenero);
            this.Controls.Add(this.cmbTipoDoc);
            this.Controls.Add(this.txtIdPersonas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvPersonas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtEstadoCivil);
            this.Controls.Add(this.txtNumDoc);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtMu);
            this.Controls.Add(this.txtTe);
            this.Controls.Add(this.txtEC);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtG);
            this.Controls.Add(this.txtT);
            this.Controls.Add(this.txta);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txta;
        private System.Windows.Forms.Label txtT;
        private System.Windows.Forms.Label txtG;
        private System.Windows.Forms.Label txtC;
        private System.Windows.Forms.Label txtD;
        private System.Windows.Forms.Label txtN;
        private System.Windows.Forms.Label txtEC;
        private System.Windows.Forms.Label txtTe;
        private System.Windows.Forms.Label txtMu;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtEstadoCivil;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdPersonas;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.ComboBox cmbGenero;
        private System.Windows.Forms.ComboBox cmbMunicipio;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

