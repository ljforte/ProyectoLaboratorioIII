using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace LaboratorioIII_Proyecto
{
    public partial class frmMarcas : Form
    {
        private List<Marcas> marcas;
        public frmMarcas()
        {
            InitializeComponent();
        }

        public frmMarcas(Marcas marcas)
        {
            InitializeComponent();
        }

        private List<Marcas> ListaMarcas;
        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        private void cargarMarcas()
        {
            MarcasNegocio negocio = new MarcasNegocio();
            try
            {
                marcas = negocio.ListarMarcas();
                dgvListarMarcas.DataSource = marcas;
                dgvListarMarcas.Columns[0].HeaderText = "Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            MarcasNegocio marca = new MarcasNegocio();
            ListaMarcas = marca.ListarMarcas();
            dgvListarMarcas.DataSource = ListaMarcas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaMarca frmAltaMarca = new frmAltaMarca();
            frmAltaMarca.ShowDialog();
            cargarMarcas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Marcas seleccionado;
            seleccionado = (Marcas)dgvListarMarcas.CurrentRow.DataBoundItem;
            frmAltaMarca modificar = new frmAltaMarca(seleccionado);
            modificar.ShowDialog();
   
        }

        public void cargarMarca()
        {
            MarcasNegocio negocio = new MarcasNegocio();
            ListaMarcas = negocio.ListarMarcas();
            dgvListarMarcas.DataSource = ListaMarcas;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MarcasNegocio negocio = new MarcasNegocio();
            Marcas seleccionado;
            try
            {
                seleccionado = (Marcas)dgvListarMarcas.CurrentRow.DataBoundItem;
                negocio.Eliminar(seleccionado.Id);
                cargarMarca();
                MessageBox.Show(seleccionado.Descripcion + " eliminado correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo borrar el articulo");
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            frmAltaMarca frmAltaMarca = new frmAltaMarca();
            frmAltaMarca.ShowDialog();
            cargarMarcas();

        }
    }
}
