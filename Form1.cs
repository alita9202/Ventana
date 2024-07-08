using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            // Código para manejar el evento Enter de groupBox2
            MessageBox.Show("groupBox2 ha sido seleccionado.");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Código para manejar el evento Click de label2
            MessageBox.Show("label2 ha sido clickeado.");
        }

        void mantenimiento(String accion)
        {
            objent.codigo = textcodigo.Text;
            objent.nombre = textnombre.Text;
            objent.edad = Convert.ToInt32(textedad.Text);
            objent.telefono = Convert.ToInt32(texttelefono.Text);
            objent.accion = accion;
            String men = objneg.N_mantenimiento_cliente(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            textcodigo.Text = "";
            textnombre.Text = "";
            textedad.Text = "";
            texttelefono.Text = "";
            textbuscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textcodigo.Text == "")
            {
                if (MessageBox.Show("Deseas registrar a " + textnombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textcodigo.Text != "")
            {
                if (MessageBox.Show("Deseas modificar a " + textnombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textcodigo.Text != "")
            {
                if (MessageBox.Show("Deseas eliminar a " + textnombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (textbuscar.Text != "")
            {
                objent.nombre = textbuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_clientes();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            textcodigo.Text = dataGridView1[0, fila].Value.ToString();
            textnombre.Text = dataGridView1[1, fila].Value.ToString();
            textedad.Text = dataGridView1[2, fila].Value.ToString();
            texttelefono.Text = dataGridView1[3, fila].Value.ToString();
        }
    }
}
