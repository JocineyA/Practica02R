using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rutas_Turisticas.BusinessLogic;

namespace Rutas_Turisticas
{
    public partial class RegistroVentaForm : Form
    {
        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\bdrutas.mdf;Integrated Security=True";

        public RegistroVentaForm()
        {
            InitializeComponent();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            int idCliente;
            if (!int.TryParse(txtIdCliente.Text, out idCliente))
            {
                MostrarError("El ID del cliente ingresado no es válido.");
                return;
            }

            string rutaTuristica = txtRutaTuristica.Text;

            int cantidadPersonas;
            if (!int.TryParse(txtCantidadPersonas.Text, out cantidadPersonas))
            {
                MostrarError("La cantidad de personas ingresada no es válida.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Ventas (IdCliente, RutaTuristica, CantidadPersonas, ImporteTotal) VALUES (@IdCliente, @RutaTuristica, @CantidadPersonas, @ImporteTotal)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdCliente", idCliente);
                        command.Parameters.AddWithValue("@RutaTuristica", rutaTuristica);
                        command.Parameters.AddWithValue("@CantidadPersonas", cantidadPersonas);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("La venta ha sido registrada correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MostrarError("No se pudo registrar la venta.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        private void btnMostrarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT IdCliente, SUM(ImporteTotal) AS ImportePagado FROM Ventas GROUP BY IdCliente";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvClientes.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InitializeComponent()
        {
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.lblRutaTuristica = new System.Windows.Forms.Label();
            this.txtRutaTuristica = new System.Windows.Forms.TextBox();
            this.lblCantidadPersonas = new System.Windows.Forms.Label();
            this.txtCantidadPersonas = new System.Windows.Forms.TextBox();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.btnMostrarClientes = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Location = new System.Drawing.Point(12, 20);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(72, 17);
            this.lblIdCliente.TabIndex = 0;
            this.lblIdCliente.Text = "Cliente ID:";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(118, 20);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(100, 22);
            this.txtIdCliente.TabIndex = 1;
            // 
            // lblRutaTuristica
            // 
            this.lblRutaTuristica.AutoSize = true;
            this.lblRutaTuristica.Location = new System.Drawing.Point(12, 50);
            this.lblRutaTuristica.Name = "lblRutaTuristica";
            this.lblRutaTuristica.Size = new System.Drawing.Size(100, 17);
            this.lblRutaTuristica.TabIndex = 2;
            this.lblRutaTuristica.Text = "Ruta Turística:";
            // 
            // txtRutaTuristica
            // 
            this.txtRutaTuristica.Location = new System.Drawing.Point(118, 47);
            this.txtRutaTuristica.Name = "txtRutaTuristica";
            this.txtRutaTuristica.Size = new System.Drawing.Size(100, 22);
            this.txtRutaTuristica.TabIndex = 3;
            this.txtRutaTuristica.TextChanged += new System.EventHandler(this.txtRutaTuristica_TextChanged);
            // 
            // lblCantidadPersonas
            // 
            this.lblCantidadPersonas.AutoSize = true;
            this.lblCantidadPersonas.Location = new System.Drawing.Point(12, 83);
            this.lblCantidadPersonas.Name = "lblCantidadPersonas";
            this.lblCantidadPersonas.Size = new System.Drawing.Size(132, 17);
            this.lblCantidadPersonas.TabIndex = 4;
            this.lblCantidadPersonas.Text = "Cantidad Personas:";
            // 
            // txtCantidadPersonas
            // 
            this.txtCantidadPersonas.Location = new System.Drawing.Point(150, 83);
            this.txtCantidadPersonas.Name = "txtCantidadPersonas";
            this.txtCantidadPersonas.Size = new System.Drawing.Size(70, 22);
            this.txtCantidadPersonas.TabIndex = 5;
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.Location = new System.Drawing.Point(0, 0);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(100, 23);
            this.lblImporteTotal.TabIndex = 12;
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(12, 139);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(181, 23);
            this.btnRegistrarVenta.TabIndex = 8;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // btnMostrarClientes
            // 
            this.btnMostrarClientes.Location = new System.Drawing.Point(15, 168);
            this.btnMostrarClientes.Name = "btnMostrarClientes";
            this.btnMostrarClientes.Size = new System.Drawing.Size(181, 23);
            this.btnMostrarClientes.TabIndex = 9;
            this.btnMostrarClientes.Text = "Mostrar Clientes";
            this.btnMostrarClientes.UseVisualStyleBackColor = true;
            this.btnMostrarClientes.Click += new System.EventHandler(this.btnMostrarClientes_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(15, 197);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.Size = new System.Drawing.Size(302, 150);
            this.dgvClientes.TabIndex = 10;
            // 
            // RegistroVentaForm
            // 
            this.ClientSize = new System.Drawing.Size(338, 359);
            this.Controls.Add(this.dgvClientes);
            this.Controls.Add(this.btnMostrarClientes);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.lblImporteTotal);
            this.Controls.Add(this.txtCantidadPersonas);
            this.Controls.Add(this.lblCantidadPersonas);
            this.Controls.Add(this.txtRutaTuristica);
            this.Controls.Add(this.lblRutaTuristica);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.lblIdCliente);
            this.Name = "RegistroVentaForm";
            this.Load += new System.EventHandler(this.RegistroVentaForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblIdCliente;
        private TextBox txtIdCliente;
        private Label lblRutaTuristica;
        private TextBox txtRutaTuristica;
        private Label lblCantidadPersonas;
        private TextBox txtCantidadPersonas;
        private Label lblImporteTotal;
        private Button btnRegistrarVenta;
        private Button btnMostrarClientes;
        private DataGridView dgvClientes;

        private void RegistroVentaForm_Load(object sender, EventArgs e)
        {
            // Aquí puedes inicializar el formulario
        }

        private void RegistroVentaForm_Load_1(object sender, EventArgs e)
        {

        }

        private void txtRutaTuristica_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
