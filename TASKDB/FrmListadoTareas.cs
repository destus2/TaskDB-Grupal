using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using TaskDB;

namespace TASKDB
{
    public partial class FrmListadoTareas : Form
    {
        public FrmListadoTareas()
        {
            InitializeComponent();
        }

        private void FrmListadoTareas_Load(object sender, EventArgs e)
        {
            CargarTareas();
        }

        public void CargarTareas()
        {
            // Requerimiento RNF3.2: Uso de bloque try-catch para control de excepciones
            try
            {
                // Requerimiento RF1.2 / RF3.2: Uso de DatabaseConnection y SqlDataAdapter
                using (SqlConnection conexion = DatabaseConnection.GetConnection())
                {
                    conexion.Open();
                    string query = "SELECT Id, Titulo, Descripcion, Estado, FechaCreacion FROM Tareas";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Enlazar datos al DataGridView
                    dgvTareas.DataSource = dt;

                    // Requerimiento RNF3.1: Configurar columnas y encabezados limpios
                    ConfigurarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las tareas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            dgvTareas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTareas.ReadOnly = true;
            dgvTareas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTareas.AllowUserToAddRows = false;

            // Encabezados limpios
            if (dgvTareas.Columns["Id"] != null) dgvTareas.Columns["Id"].HeaderText = "ID";
            if (dgvTareas.Columns["Titulo"] != null) dgvTareas.Columns["Titulo"].HeaderText = "Título";
            if (dgvTareas.Columns["Descripcion"] != null) dgvTareas.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvTareas.Columns["Estado"] != null) dgvTareas.Columns["Estado"].HeaderText = "Estado";
            if (dgvTareas.Columns["FechaCreacion"] != null) dgvTareas.Columns["FechaCreacion"].HeaderText = "Fecha Creación";
        }
    }
}