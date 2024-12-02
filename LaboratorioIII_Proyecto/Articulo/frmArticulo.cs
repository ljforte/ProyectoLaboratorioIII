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
using Dominio;
using Negocio;

namespace LaboratorioIII_Proyecto
{
    public partial class frmArticulo : Form
    {
        private List<Articulo> ListaArticulos;
        private ArticuloNegocio negocio;
        private string proveedores;
        public frmArticulo()
        {
            InitializeComponent();
        }

        
        private void frmArticulo_Load(object sender, EventArgs e)
        {

            cargarArticulo();
            cargarCbxCampo();
            dgvPrimeraFila();




        }

        private void cargarCbxCampo()
        {
            cbxCampo.Items.Clear();
            cbxCampo.Items.Add("Codigo");
            cbxCampo.Items.Add("Nombre");
            cbxCampo.Items.Add("Marca");
            cbxCampo.Items.Add("Categoria");
            cbxCampo.Items.Add("Precio");
            cbxCriterio.Items.Clear();
        }

        private void cargarArticulo()
        {

            negocio = new ArticuloNegocio();
            try
            {
                ListaArticulos = negocio.ListarArticulos();
                dgvListarArticulos.DataSource = ListaArticulos;
                //picbxArticulo.Load(ListaArticulos[0].Imagen.ImagenUrl);
                cargarImagen(ListaArticulos[0].Imagen.ImagenUrl);
                //dgvListarArticulos.Columns["ImagenUrl"].Visible = false;
                if (dgvListarArticulos.Columns["ProveedorNombre"] != null)
                {
                    dgvListarArticulos.Columns["ProveedorNombre"].Visible = false;
                }
                dgvListarArticulos.Columns["Id"].Visible = false;
                dgvListarArticulos.Columns["idProveedor"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void dgvListarArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo Seleccionado = (Articulo)dgvListarArticulos.CurrentRow.DataBoundItem;
                picbxArticulo.Load(Seleccionado.Imagen.ImagenUrl);
            }
            catch (Exception)
            {
                picbxArticulo.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder.png");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmAltaArticulo))
                {
                    return;
                }
            }
            frmAltaArticulo CrearArticulo = new frmAltaArticulo();
            //CrearArticulo.MdiParent = this;
            CrearArticulo.ShowDialog();
            cargarArticulo();
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                picbxArticulo.Load(imagen);
            }
            catch (Exception)
            {
                picbxArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (dgvListarArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvListarArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
                modificar.ShowDialog();
                cargarArticulo();

                dgvPrimeraFila();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un artículo para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvPrimeraFila()
        {
            if (dgvListarArticulos.Rows.Count > 0 && dgvListarArticulos.Rows[0].Visible)
            {
                
                if (dgvListarArticulos.Rows[0].Cells[0].Visible)
                {
                    dgvListarArticulos.CurrentCell = dgvListarArticulos.Rows[0].Cells[0];
                    dgvListarArticulos.Rows[0].Selected = true;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListarArticulos.CurrentRow != null)
                {
                    negocio = new ArticuloNegocio();
                    Articulo seleccionado;
                    seleccionado = (Articulo)dgvListarArticulos.CurrentRow.DataBoundItem;
                    negocio.Eliminar(seleccionado.Id);
                    cargarArticulo();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un artículo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmAltaMarca AltaMarca = new frmAltaMarca();

            AltaMarca.ShowDialog();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmAltaCategoria frmAltaCategoria = new frmAltaCategoria();
            frmAltaCategoria.ShowDialog();
        }

        private void tsmMarca_Click(object sender, EventArgs e)
        {
            frmMarcas Marca = new frmMarcas();
            Marca.ShowDialog();
        }

        private void tsmCategoria_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.ShowDialog();

        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxCampo.SelectedItem.ToString();
            cbxCriterio.Items.Clear();
            if (opcion == "Precio")
            {
                cbxCriterio.Items.Add("Mayor a");
                cbxCriterio.Items.Add("Menor a");
                cbxCriterio.Items.Add("Igual a");
            }
            else
            {
                
                cbxCriterio.Items.Add("Comienza con");
                cbxCriterio.Items.Add("Termina con");
                cbxCriterio.Items.Add("Contiene");
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            cbxCriterio.Items.Clear();
            cargarCbxCampo();
            cbxCampo.Text="";
            cbxCriterio.Text="";
            //cbxCriterio.Items.Clear();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            negocio = new ArticuloNegocio();    
            ListaArticulos = negocio.ListarArticulos();
            if (txtBuscar.TextLength>0)
                ListaArticulos = ListaArticulos.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
            dgvListarArticulos.DataSource = ListaArticulos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string campo = cbxCampo.SelectedItem.ToString();
                string criterio = cbxCriterio.SelectedItem.ToString();
                string filtro = txtBuscar.Text;
                dgvListarArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dgvListarArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                seleccionado = (Articulo)dgvListarArticulos.CurrentRow.DataBoundItem;
                negocio.bajaLogica(seleccionado.Id);
                MessageBox.Show(seleccionado.Nombre + " deshabilitado correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo deshabilitar el producto.");
            }

        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            ProveedorNegocio prov = new ProveedorNegocio();
            List<Proveedor> proveedor = new List<Proveedor>();
            
            try
            {
                proveedor = prov.ObtenerProveedorConMasArticulos();

                if (proveedor.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún proveedor.");
                    return;
                }

                if (proveedor.Count > 1)
                {
                    proveedores += "Se encontraron " + proveedor.Count() + " proveedores: \n";
                    
                    for (int x = 0; x < proveedor.Count(); x++)
                    {
                        proveedores += "Proveedor: " + proveedor[x].nombre + "con " + proveedor[x].CantidadArticulos + " items.\n";
                    }
                }
                else
                {
                    proveedores +="Proovedor " + proveedor[0].nombre + "con " + proveedor[0].CantidadArticulos + " items. ";
                }
                MessageBox.Show(proveedores);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al mostrar proveedor");
            }
        }
    }
}
