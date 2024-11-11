using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace LaboratorioIII_Proyecto
{
    public partial class frmAltaProducto : Form
    {
        private Producto producto = null;
        private ProductoNegocio negocio;
        private ArtImg artImg = null;

        public frmAltaProducto()
        {
            InitializeComponent();
        }

        public frmAltaProducto(Producto producto)
        {
            InitializeComponent();
            this.Text = "Modificar Producto";
            this.lblTitulo.Text = "MODIFICAR Producto";
            this.btnAgregar.Text = "Modificar";
            this.btnImagenModificar.Visible = true;
            this.producto = producto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            negocio = new ProductoNegocio();
            artImg = new ArtImg();

            try
            {
                if (this.producto == null)
                {
                    this.producto = new Producto();
                }

                artImg.ImagenUrl = txtbUrlImagen.Text;
                this.producto.Nombre = txtbNombre.Text;
                this.producto.Descripcion = txtbDescAr.Text;
                this.producto.MarcasCls = (Marcas)cbxMarca.SelectedItem;
                this.producto.CategoriasCls = (Categorias)cbxCat.SelectedItem;
                this.producto.Precio = decimal.Parse(txtbPrecio.Text);

                if (btnAgregar.Text == "Agregar")
                {
                    negocio.Agregar(this.producto, artImg);
                    MessageBox.Show("Producto agregado correctamente.");
                }
                else if (btnAgregar.Text == "Modificar")
                {
                    negocio.Modificar(this.producto);
                    MessageBox.Show("Producto modificado correctamente.");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcasNegocio marcasNegocio = new MarcasNegocio();

            try
            {
                cbxMarca.DataSource = marcasNegocio.ListarMarcas();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion";

                cbxCat.DataSource = categoriaNegocio.ListarCategoria();
                cbxCat.ValueMember = "Id";
                cbxCat.DisplayMember = "Descripcion";

                if (producto != null)
                {
                    txtbNombre.Text = producto.Nombre;
                    txtbDescAr.Text = producto.Descripcion;
                    txtbPrecio.Text = producto.Precio.ToString();
                    cbxMarca.SelectedValue = producto.MarcasCls.Id;
                    cbxCat.SelectedValue = producto.CategoriasCls.Id;
                    cargarImagen(this.producto.Imagen?.ImagenUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar el formulario: " + ex.Message);
            }
        }

        private void txtbUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtbUrlImagen.Text);
        }

        private void cargarImagen(string imagenUrl)
        {
            try
            {
                pbxProductoImagen.Load(imagenUrl);
            }
            catch (Exception)
            {
                pbxProductoImagen.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnImagenModificar_Click(object sender, EventArgs e)
        {
            ListarImg listarImg = new ListarImg(producto);
            listarImg.ShowDialog();
        }
    }
}
