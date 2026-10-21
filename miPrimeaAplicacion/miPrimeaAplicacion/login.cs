using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class login : Form
    {
        Conexion objConexion = new Conexion();

        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = textUsuario.Text.Trim();
                string clave = txtClave.Text.Trim();

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
                {
                    MessageBox.Show("Por favor ingrese usuario y contraseña.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "SELECT COUNT(*) FROM USTR159126 WHERE usuario = @user AND clave = @pass";

                SqlCommand cmd = new SqlCommand(query, objConexion.objConexion);
                cmd.Parameters.AddWithValue("@user", usuario);
                cmd.Parameters.AddWithValue("@pass", clave);

                int existeRegistro = Convert.ToInt32(cmd.ExecuteScalar());

                if (existeRegistro > 0)
                {
                    MessageBox.Show("Acceso concedido al sistema.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frm_usuario frm = new frm_usuario();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos. Acceso denegado.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    textUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error Técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}