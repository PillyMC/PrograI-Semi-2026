using System;
using System.Globalization;
using System.Windows.Forms;

namespace miPrimeaAplicacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        string[] etiquetas =
        {
            "Pie Cuadrado",
            "Vara Cuadrada",
            "Yarda Cuadrada",
            "Metro Cuadrado",
            "Tarea",
            "Manzana",
            "Hectárea"
        };

     
        double[] valores =
        {
            0.09290304, // Pie cuadrado
            0.698896,   // Vara cuadrada
            0.83612736, // Yarda cuadrada
            1.0,        // Metro cuadrado
            628.80,     // Tarea
            6988.96,    // Manzana
            10000.0     // Hectárea
        };

        private void Form1_Load(object sender, EventArgs e)
        {
        
            cboDe.Items.Clear();
            cboA.Items.Clear();

            cboDe.Items.AddRange(etiquetas);
            cboA.Items.AddRange(etiquetas);

         
            cboDe.SelectedIndex = 0;
            cboA.SelectedIndex = 1;

            lblRespuesta.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
      
            if (cboDe.SelectedIndex == -1 || cboA.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Por favor, seleccione las unidades a convertir.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!double.TryParse(
                    txtCantidad.Text,
                    NumberStyles.Float,
                    CultureInfo.CurrentCulture,
                    out double cantidad))
            {
                MessageBox.Show(
                    "Por favor, ingrese una cantidad numérica válida.",
                    "Error de entrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtCantidad.Focus();
                return;
            }

          
            if (cantidad < 0)
            {
                MessageBox.Show(
                    "La cantidad no puede ser negativa.",
                    "Error de entrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                txtCantidad.Focus();
                return;
            }

            int unidadOrigen = cboDe.SelectedIndex;
            int unidadDestino = cboA.SelectedIndex;

          
            double respuesta =
                cantidad * valores[unidadOrigen] / valores[unidadDestino];

            lblRespuesta.Text = respuesta.ToString(
                "N",
                CultureInfo.CurrentCulture
            );
        }

        private void cboOpciones_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
          
            cboDe.Items.Clear();
            cboA.Items.Clear();

            cboDe.Items.AddRange(etiquetas);
            cboA.Items.AddRange(etiquetas);
        }
    }
}