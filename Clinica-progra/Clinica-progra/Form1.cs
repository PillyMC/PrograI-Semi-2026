using System;
using System.Windows.Forms;

namespace Clinica_progra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cmbCondicion.Items.Clear();

            cmbCondicion.Items.Add("Gripe");
            cmbCondicion.Items.Add("Resfriado");
            cmbCondicion.Items.Add("Dolor leve");
            cmbCondicion.Items.Add("Fiebre");
            cmbCondicion.Items.Add("Lesión");
            cmbCondicion.Items.Add("Infección");
            cmbCondicion.Items.Add("Dolor intenso");
            cmbCondicion.Items.Add("Embarazo avanzado");
            cmbCondicion.Items.Add("Dificultad respiratoria");
            cmbCondicion.Items.Add("Estado crítico");
            cmbCondicion.Items.Add("Otro");

            if (cmbCondicion.Items.Count > 0)
            {
                cmbCondicion.SelectedIndex = 0;
            }

            nudEdad.Minimum = 0;
            nudEdad.Maximum = 110;
            nudEdad.Value = 0;

            txtEspecificacion.Enabled = true;

            dgvPacientes.Columns.Clear();

            dgvPacientes.Columns.Add("Prioridad", "Prioridad");
            dgvPacientes.Columns.Add("Nombre", "Nombre");
            dgvPacientes.Columns.Add("Edad", "Edad");
            dgvPacientes.Columns.Add("Condicion", "Situación");
            dgvPacientes.Columns.Add("Especificacion", "Especificación");
            dgvPacientes.Columns.Add("FechaHora", "Fecha y hora de llegada");

            dgvPacientes.Columns["FechaHora"].ReadOnly = true;

            txtNombre.KeyPress += txtNombre_KeyPress;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int ObtenerPrioridad(string condicion)
        {
            switch (condicion)
            {
                case "Gripe":
                case "Resfriado":
                case "Dolor leve":
                    return 1;

                case "Fiebre":
                case "Lesión":
                case "Infección":
                    return 2;

                case "Dolor intenso":
                    return 3;

                case "Embarazo avanzado":
                case "Dificultad respiratoria":
                case "Estado crítico":
                    return 4;

                default:
                    return 1;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del paciente.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNombre.Focus();
                return;
            }

            if (cmbCondicion.SelectedItem == null)
            {
                MessageBox.Show(
                    "Seleccione la situación del paciente.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string nombre = txtNombre.Text.Trim();
            int edad = (int)nudEdad.Value;
            string condicion = cmbCondicion.SelectedItem.ToString();
            string especificacion = txtEspecificacion.Text.Trim();

            int prioridad = ObtenerPrioridad(condicion);

            DateTime fechaHoraLlegada = DateTime.Now;

            dgvPacientes.Rows.Add(
                prioridad,
                nombre,
                edad,
                condicion,
                especificacion,
                fechaHoraLlegada.ToString("dd/MM/yyyy HH:mm:ss")
            );

            OrdenarPacientes();
            ActualizarContadores();

            txtNombre.Clear();
            nudEdad.Value = 0;
            cmbCondicion.SelectedIndex = 0;
            txtEspecificacion.Clear();

            txtNombre.Focus();
        }

        private void OrdenarPacientes()
        {
            for (int i = 0; i < dgvPacientes.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgvPacientes.Rows.Count - 1 - i; j++)
                {
                    int prioridadActual =
                        Convert.ToInt32(
                            dgvPacientes.Rows[j]
                            .Cells["Prioridad"]
                            .Value
                        );

                    int prioridadSiguiente =
                        Convert.ToInt32(
                            dgvPacientes.Rows[j + 1]
                            .Cells["Prioridad"]
                            .Value
                        );

                    DateTime horaActual =
                        DateTime.Parse(
                            dgvPacientes.Rows[j]
                            .Cells["FechaHora"]
                            .Value
                            .ToString()
                        );

                    DateTime horaSiguiente =
                        DateTime.Parse(
                            dgvPacientes.Rows[j + 1]
                            .Cells["FechaHora"]
                            .Value
                            .ToString()
                        );

                    bool debeCambiar =
                        prioridadActual < prioridadSiguiente ||
                        (
                            prioridadActual == prioridadSiguiente &&
                            horaActual > horaSiguiente
                        );

                    if (debeCambiar)
                    {
                        DataGridViewRow fila =
                            dgvPacientes.Rows[j];

                        dgvPacientes.Rows.RemoveAt(j);

                        dgvPacientes.Rows.Insert(j + 1, fila);
                    }
                }
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay pacientes pendientes.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DataGridViewRow paciente = dgvPacientes.Rows[0];

            string nombre =
                paciente.Cells["Nombre"].Value.ToString();

            string condicion =
                paciente.Cells["Condicion"].Value.ToString();

            string especificacion =
                paciente.Cells["Especificacion"].Value.ToString();

            int edad =
                Convert.ToInt32(
                    paciente.Cells["Edad"].Value
                );

            int prioridad =
                Convert.ToInt32(
                    paciente.Cells["Prioridad"].Value
                );

            string fechaHora =
                paciente.Cells["FechaHora"].Value.ToString();

            DialogResult respuesta = MessageBox.Show(
                "Paciente: " + nombre +
                "\nEdad: " + edad +
                "\nSituación: " + condicion +
                "\nEspecificación: " + especificacion +
                "\nPrioridad: " + prioridad +
                "\nLlegada: " + fechaHora +
                "\n\n¿Desea atender a este paciente?",
                "Atender paciente",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                dgvPacientes.Rows.RemoveAt(0);

                ActualizarContadores();

                MessageBox.Show(
                    "El paciente " + nombre +
                    " ha sido atendido correctamente.",
                    "Paciente atendido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un paciente de la lista.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DataGridViewRow paciente =
                dgvPacientes.SelectedRows[0];

            string nombre =
                paciente.Cells["Nombre"]
                .Value
                .ToString();

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de eliminar al paciente " +
                nombre + "?",
                "Eliminar paciente",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.Yes)
            {
                dgvPacientes.Rows.RemoveAt(
                    paciente.Index
                );

                ActualizarContadores();

                MessageBox.Show(
                    "El paciente " + nombre +
                    " ha sido eliminado.",
                    "Paciente eliminado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void ActualizarContadores()
        {
            int total = dgvPacientes.Rows.Count;

            lblTotal.Text =
                "Pacientes registrados: " + total;

            lblPendientes.Text =
                "Pacientes en espera: " + total;
        }

        private void lblcondicion_Click(object sender, EventArgs e)
        {
        }
    }
}