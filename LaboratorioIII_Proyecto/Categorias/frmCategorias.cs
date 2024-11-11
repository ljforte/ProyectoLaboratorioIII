using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace LaboratorioIII_Proyecto
{
    public partial class frmCategoria : Form
    {
        private List<Categorias> categorias;
        public frmCategoria()
        {
            InitializeComponent();
        }
        private void frmCategoria_Load(object sender, EventArgs e)
        {
            cargarListadoCategorias();
        }

        private void cargarListadoCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                categorias = negocio.ListarCategoria();
                dgvCategorias.DataSource = categorias;
                dgvCategorias.Columns[0].HeaderText = "Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //======= MENU - CLICK =======
        private void tsmSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmAgregar_Click(object sender, EventArgs e)
        {
            frmAltaCategoria frmAltaCategoria = new frmAltaCategoria();
            frmAltaCategoria.ShowDialog();
            cargarListadoCategorias();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categorias categoria = (Categorias)dgvCategorias.CurrentRow.DataBoundItem;
            frmAltaCategoria frm  = new frmAltaCategoria(categoria);
            frm.ShowDialog();
            cargarListadoCategorias();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaCategoria frmAltaCategoria = new frmAltaCategoria();
            frmAltaCategoria.ShowDialog();
            cargarListadoCategorias();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categorias seleccionado;
            try
            {
                seleccionado = (Categorias)dgvCategorias.CurrentRow.DataBoundItem;
                negocio.Eliminar(seleccionado.Id);
                cargarCategoria();
                MessageBox.Show(seleccionado.Descripcion + " eliminado correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cargarCategoria()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
                categorias = negocio.ListarCategoria();
                dgvCategorias.DataSource = categorias;
        }
    }
}
