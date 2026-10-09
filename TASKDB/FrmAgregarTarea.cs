using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskDB;

namespace TASKDB
{
    public partial class FrmAgregarTarea : Form
    {
        public FrmAgregarTarea()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string descripcion = txtDescrip.Text.Trim();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                MessageBox.Show("Debes escribir el título de la tarea.");
                txtTitulo.Focus();
                return;
            }

            if (titulo.Length > 150)
            {
                MessageBox.Show("El título debe tener como máximo 150 caracteres.");
                return;
            }

            try
            {
                string consulta = "INSERT INTO dbo.Tareas (Titulo, Descripcion) " +
                                  "VALUES (@Titulo, @Descripcion);";

                using (SqlConnection conexion = DatabaseConnection.GetConnection())
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.Add("@Titulo", SqlDbType.NVarChar, 150).Value = titulo;
                    comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, -1).Value =
                        string.IsNullOrWhiteSpace(descripcion) ? (object)DBNull.Value : descripcion;

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }

                MessageBox.Show("Tarea guardada correctamente.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la tarea.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

        
    

