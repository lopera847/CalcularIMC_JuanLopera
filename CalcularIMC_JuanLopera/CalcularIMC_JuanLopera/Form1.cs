using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CalcularIMC_JuanLopera
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();

        }

      
        
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos de los campos
                string nombre = txtNombre.Text;
                double estatura = double.Parse(txtEstatura.Text);
                double peso = double.Parse(txtPeso.Text);

                // Calcular IMC
                double imc = peso / (estatura * estatura);
                string clasificacion = ObtenerClasificacionIMC(imc);

                // Mostrar resultados
                lblResultadoIMC.Text = $"IMC: {imc:F2}";
                lblResultadoClasificacion.Text = $"Clasificación: {clasificacion}";

                // Guardar en archivo
                GuardarRegistro(nombre, estatura, peso, imc, clasificacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ObtenerClasificacionIMC(double imc)
        {
            if (imc < 18.5) return "Bajo peso";
            else if (imc < 25) return "Peso normal";
            else if (imc < 30) return "Sobrepeso";
            else if (imc < 35) return "Obesidad grado I";
            else if (imc < 40) return "Obesidad grado II";
            else return "Obesidad grado III";
        }

        private void GuardarRegistro(string nombre, double estatura, double peso, double imc, string clasificacion)
        {
            string registro = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Nombre: {nombre}, Estatura: {estatura}m, Peso: {peso}kg, IMC: {imc:F2}, Clasificación: {clasificacion}\n";

            try
            {
                File.AppendAllText("registro_imc.txt", registro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("registro_imc.txt"))
                {
                    string historico = File.ReadAllText("registro_imc.txt");

                    // Mostrar en una nueva ventana
                    HistoricoForm historicoForm = new HistoricoForm();
                    historicoForm.txtHistorico.Text = historico;
                    historicoForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay registros históricos disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer historico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            public partial class HistoricoForm : Form
        {
            public HistoricoForm()
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                this.txtHistorico = new System.Windows.Forms.TextBox();
                this.SuspendLayout();

                // txtHistorico
                this.txtHistorico.Multiline = true;
                this.txtHistorico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.txtHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
                this.txtHistorico.ReadOnly = true;

                // HistoricoForm
                this.ClientSize = new System.Drawing.Size(500, 400);
                this.Controls.Add(this.txtHistorico);
                this.Text = "Histórico de Cálculos";
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            public TextBox txtHistorico;
        }



    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
