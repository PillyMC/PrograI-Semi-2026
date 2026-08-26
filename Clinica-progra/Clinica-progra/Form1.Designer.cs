namespace Clinica_progra
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lblcondicion = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblEspecificacion = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();

            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEspecificacion = new System.Windows.Forms.TextBox();

            this.cmbCondicion = new System.Windows.Forms.ComboBox();
            this.nudEdad = new System.Windows.Forms.NumericUpDown();

            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAtender = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();

            this.dgvPacientes = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.nudEdad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();

            this.SuspendLayout();

            // lbltitulo
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font(
                "Segoe UI Black",
                18F,
                System.Drawing.FontStyle.Bold
            );
            this.lbltitulo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbltitulo.Location = new System.Drawing.Point(130, 15);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(570, 32);
            this.lbltitulo.TabIndex = 0;
            this.lbltitulo.Text = "Sistema de Gestión de Prioridades - Clínica";

            // lbl
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lbl.Location = new System.Drawing.Point(70, 70);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(145, 20);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Nombre del paciente";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(70, 95);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 22);
            this.txtNombre.TabIndex = 2;

            // lblEdad
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lblEdad.Location = new System.Drawing.Point(330, 70);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(45, 20);
            this.lblEdad.TabIndex = 3;
            this.lblEdad.Text = "Edad";

            // nudEdad
            this.nudEdad.Location = new System.Drawing.Point(330, 95);
            this.nudEdad.Maximum = new decimal(
                new int[] {
                    110,
                    0,
                    0,
                    0
                }
            );
            this.nudEdad.Name = "nudEdad";
            this.nudEdad.Size = new System.Drawing.Size(120, 22);
            this.nudEdad.TabIndex = 4;
            this.nudEdad.Value = new decimal(
                new int[] {
                    0,
                    0,
                    0,
                    0
                }
            );

            // lblcondicion
            this.lblcondicion.AutoSize = true;
            this.lblcondicion.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lblcondicion.Location = new System.Drawing.Point(70, 140);
            this.lblcondicion.Name = "lblcondicion";
            this.lblcondicion.Size = new System.Drawing.Size(76, 20);
            this.lblcondicion.TabIndex = 5;
            this.lblcondicion.Text = "Situación";

            this.lblcondicion.Click += new System.EventHandler(
                this.lblcondicion_Click
            );

            // cmbCondicion
            this.cmbCondicion.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbCondicion.FormattingEnabled = true;
            this.cmbCondicion.Location = new System.Drawing.Point(70, 165);
            this.cmbCondicion.Name = "cmbCondicion";
            this.cmbCondicion.Size = new System.Drawing.Size(220, 23);
            this.cmbCondicion.TabIndex = 6;

            // lblEspecificacion
            this.lblEspecificacion.AutoSize = true;
            this.lblEspecificacion.Font = new System.Drawing.Font(
                "Segoe UI",
                11F,
                System.Drawing.FontStyle.Bold
            );
            this.lblEspecificacion.Location = new System.Drawing.Point(330, 140);
            this.lblEspecificacion.Name = "lblEspecificacion";
            this.lblEspecificacion.Size = new System.Drawing.Size(108, 20);
            this.lblEspecificacion.TabIndex = 7;
            this.lblEspecificacion.Text = "Especificación";

            // txtEspecificacion
            this.txtEspecificacion.Location = new System.Drawing.Point(330, 165);
            this.txtEspecificacion.Name = "txtEspecificacion";
            this.txtEspecificacion.Size = new System.Drawing.Size(250, 22);
            this.txtEspecificacion.TabIndex = 8;

            // btnAgregar
            this.btnAgregar.Location = new System.Drawing.Point(70, 215);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(170, 40);
            this.btnAgregar.TabIndex = 9;
            this.btnAgregar.Text = "Agregar Paciente";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(
                this.btnAgregar_Click
            );

            // btnAtender
            this.btnAtender.Location = new System.Drawing.Point(260, 215);
            this.btnAtender.Name = "btnAtender";
            this.btnAtender.Size = new System.Drawing.Size(150, 40);
            this.btnAtender.TabIndex = 10;
            this.btnAtender.Text = "Atender Paciente";
            this.btnAtender.UseVisualStyleBackColor = true;
            this.btnAtender.Click += new System.EventHandler(
                this.btnAtender_Click
            );

            // btnEliminar
            this.btnEliminar.Location = new System.Drawing.Point(430, 215);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 40);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar Paciente";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(
                this.btnEliminar_Click
            );

            // dgvPacientes
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvPacientes.BackgroundColor =
                System.Drawing.SystemColors.InactiveCaption;

            this.dgvPacientes.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.dgvPacientes.Location = new System.Drawing.Point(50, 285);
            this.dgvPacientes.MultiSelect = false;
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvPacientes.Size =
                new System.Drawing.Size(820, 190);

            this.dgvPacientes.TabIndex = 12;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.lblTotal.Location = new System.Drawing.Point(70, 490);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(185, 19);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Pacientes registrados: 0";

            // lblPendientes
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font(
                "Segoe UI",
                10F,
                System.Drawing.FontStyle.Bold
            );
            this.lblPendientes.Location = new System.Drawing.Point(350, 490);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(165, 19);
            this.lblPendientes.TabIndex = 14;
            this.lblPendientes.Text = "Pacientes en espera: 0";

            // Form1
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(930, 540);

            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAtender);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtEspecificacion);
            this.Controls.Add(this.lblEspecificacion);
            this.Controls.Add(this.cmbCondicion);
            this.Controls.Add(this.lblcondicion);
            this.Controls.Add(this.nudEdad);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lbltitulo);

            this.Name = "Form1";
            this.Text = "Clínica - Sistema de Prioridades";

            ((System.ComponentModel.ISupportInitialize)(this.nudEdad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblcondicion;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblEspecificacion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPendientes;

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEspecificacion;

        private System.Windows.Forms.ComboBox cmbCondicion;
        private System.Windows.Forms.NumericUpDown nudEdad;

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAtender;
        private System.Windows.Forms.Button btnEliminar;

        private System.Windows.Forms.DataGridView dgvPacientes;
    }
}