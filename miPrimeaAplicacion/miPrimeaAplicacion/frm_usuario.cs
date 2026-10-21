using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class frm_usuario : Form
    {
        Conexion objConexion = new Conexion();
        DataTable dtUsuarios = new DataTable();
        int posicion = 0;

        public frm_usuario()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {
            habilitarCampos(true);
        }

        private void cargarDatos()
        {
            try
            {
                DataSet ds = objConexion.obtenerDatos();
                if (ds != null && ds.Tables.Contains("USTR159126"))
                {
                    dtUsuarios = ds.Tables["USTR159126"];
                    if (dtUsuarios.Rows.Count > 0)
                    {
                        if (posicion >= dtUsuarios.Rows.Count)
                        {
                            posicion = dtUsuarios.Rows.Count - 1;
                        }
                        if (posicion < 0) posicion = 0;

                        mostrarRegistro();
                    }
                    else
                    {
                        limpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarRegistro()
        {
            if (dtUsuarios.Rows.Count > 0 && posicion >= 0 && posicion < dtUsuarios.Rows.Count)
            {
                DataRow fila = dtUsuarios.Rows[posicion];
                txtIdUsuario.Text = fila["idUsuario"].ToString();
                txtUsuario.Text = fila["usuario"].ToString();
                txtClave.Text = fila["clave"].ToString();
                txtConfirmarClave.Text = fila["clave"].ToString();
                txtNombre.Text = fila["nombre"].ToString();
                txtDireccion.Text = fila["dirección"].ToString();
                txtTelefono.Text = fila["teléfono"].ToString();
            }
        }

        private void limpiarCampos()
        {
            txtIdUsuario.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtUsuario.Focus();
        }

        private void habilitarCampos(bool estado)
        {
            txtUsuario.ReadOnly = !estado;
            txtClave.ReadOnly = !estado;
            txtConfirmarClave.ReadOnly = !estado;
            txtNombre.ReadOnly = !estado;
            txtDireccion.ReadOnly = !estado;
            txtTelefono.ReadOnly = !estado;
        }

        private bool validarCampos()
        {
            if (txtUsuario.Text.Trim().Length < 6 || txtUsuario.Text.Trim().Length > 16)
            {
                MessageBox.Show("El nombre de usuario debe contener entre 6 y 16 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("La contraseña y su confirmación no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarClave.Focus();
                return false;
            }

            bool tieneLetra = txtClave.Text.Any(char.IsLetter);
            bool tieneNumero = txtClave.Text.Any(char.IsDigit);

            if (!tieneLetra || !tieneNumero)
            {
                MessageBox.Show("La contraseña debe contener letras y números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validarCampos()) return;

            string[] datos = new string[]
            {
        "0",
        txtUsuario.Text.Trim(),
        txtClave.Text.Trim(),
        txtNombre.Text.Trim(),
        txtDireccion.Text.Trim(),
        txtTelefono.Text.Trim()
            };

            string respuesta = objConexion.mantenimiento_usuarios_USTR159126(datos, "nuevo");
            MessageBox.Show("Registro guardado con éxito. Filas afectadas: " + respuesta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Actualizamos los datos en segundo plano
            cargarDatos();

            // AQUÍ ESTÁ EL CAMBIO: En lugar de mostrar el registro guardado, 
            // limpiamos todas las cajas de texto y dejamos el cursor listo en el usuario.
            limpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text))
            {
                MessageBox.Show("No hay un registro seleccionado para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!validarCampos()) return;

            string[] datos = new string[]
            {
                txtIdUsuario.Text,
                txtUsuario.Text.Trim(),
                txtClave.Text.Trim(),
                txtNombre.Text.Trim(),
                txtDireccion.Text.Trim(),
                txtTelefono.Text.Trim()
            };

            string respuesta = objConexion.mantenimiento_usuarios_USTR159126(datos, "modificar");
            MessageBox.Show("Registro modificado con éxito. Filas afectadas: " + respuesta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cargarDatos();
            mostrarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdUsuario.Text)) return;

            if (MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] datos = new string[] { txtIdUsuario.Text, "", "", "", "", "" };
                string respuesta = objConexion.mantenimiento_usuarios_USTR159126(datos, "eliminar");
                MessageBox.Show("Registro eliminado. Filas afectadas: " + respuesta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                posicion = 0;
                cargarDatos();
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (dtUsuarios.Rows.Count > 0)
            {
                posicion = 0;
                mostrarRegistro();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion--;
                mostrarRegistro();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (posicion < dtUsuarios.Rows.Count - 1)
            {
                posicion++;
                mostrarRegistro();
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (dtUsuarios.Rows.Count > 0)
            {
                posicion = dtUsuarios.Rows.Count - 1;
                mostrarRegistro();
            }
        }

        private void grbDatos_Enter(object sender, EventArgs e) { }
        private void lblCodigoAlumno_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void btnAgregarAlumno_DragDrop(object sender, DragEventArgs e) { }
    }
}