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
    public partial class frmAltaArticulo : Form
    {
        private bool isInitializing = true;
        private Articulo articulo = null;
        private ArticuloNegocio negocio;
        private ArtImg ArtImg = null;

        public frmAltaArticulo()
        {
            InitializeComponent();

        }


        public frmAltaArticulo(Articulo Articulo)
        {
            InitializeComponent();
            this.Text ="Modificar Articulo";
            this.lblTitulo.Text = "MODIFICAR ARTICULO";
            this.btnAgregar.Text ="Modificar";
            this.btnImagenModificar.Visible = true;
            this.articulo = Articulo;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.articulo == null)
                {
                    this.articulo = new Articulo();
                }

                ArtImg img = new ArtImg();
                Stock stock = new Stock();

                if (string.IsNullOrEmpty(txtbNombre.Text) || string.IsNullOrEmpty(txtbCodAr.Text) || string.IsNullOrEmpty(txtbPrecio.Text))
                {
                    MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                    return;
                }

                this.articulo.Nombre = txtbNombre.Text.Trim();
                this.articulo.Codigo = txtbCodAr.Text.Trim();
                this.articulo.Descripcion = txtbDescAr.Text.Trim();
                this.articulo.MarcasCls = (Marcas)cbxMarca.SelectedItem;
                this.articulo.CategoriasCls = (Categorias)cbxCat.SelectedItem;
                this.articulo.Precio = decimal.Parse(txtbPrecio.Text);
                this.articulo.Estado = checkBoxEstado.Checked;

                img.ImagenUrl = txtbUrlImagen.Text.Trim();

                stock.sitio = (Sitio)cbxSitio.SelectedItem;
                stock.id_producto = this.articulo.Id;
                stock.stock = int.Parse(txtStock.Text);

                // Lógica de agregar o modificar
                ArticuloNegocio negocio = new ArticuloNegocio();
                if (btnAgregar.Text == "Agregar")
                {
                    negocio.Agregar(this.articulo, img, stock);
                    MessageBox.Show("Artículo agregado correctamente.");
                }
                else if (btnAgregar.Text == "Modificar")
                {
                    negocio.Modificar(this.articulo, img, stock);
                    MessageBox.Show("Artículo modificado correctamente.");
                }

                // Cerrar formulario después de la acción
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, verifica que los datos numéricos estén en el formato correcto.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }





        private void frmArticulo_Load(object sender, EventArgs e)
        {

            isInitializing = true;
            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcasNegocio marca = new MarcasNegocio();
            SitioNegocio sitio = new SitioNegocio();
            Stock st = new Stock();
            StockNegocio stNeg = new StockNegocio();
            //btnImagenModificar.Visible = false;
            try
            {
                cbxMarca.DataSource = marca.ListarMarcas();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "nombre";
                cbxCat.DataSource = categoria.ListarCategoria();
                cbxCat.ValueMember = "Id";
                cbxCat.DisplayMember = "nombre";
                cbxSitio.DataSource = sitio.Listar();
                cbxSitio.ValueMember = "Id_sitio";
                cbxSitio.DisplayMember = "nombre";

                if (articulo != null) //Si es diferentes entonces MOD aca!, Seteamos 
                {

                    txtbNombre.Text = articulo.Nombre;
                    txtbCodAr.Text = articulo.Codigo;
                    txtbDescAr.Text = articulo.Descripcion;
                    txtbPrecio.Text = articulo.Precio.ToString();
                    cbxMarca.Text = articulo.CategoriasCls.nombre;
                    cbxCat.Text = articulo.CategoriasCls.nombre;
                    cbxSitio.Text = stNeg.ObtenerSitioConMasStock(articulo.Id).ToString();
                    cargarImagen(this.articulo.Imagen.ImagenUrl);
                    txtbUrlImagen.Text = articulo.Imagen.ImagenUrl;
                    txtStock.Text = stNeg.ObtenerStockPorProductoYSitio(articulo.Id, stNeg.ObtenerSitioConMasStock(articulo.Id)).ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            isInitializing = false;
        }

        private void txtbUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtbUrlImagen.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticuloImagen.Load(imagen);
            }
            catch (Exception)
            {
                pbxArticuloImagen.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnImagenModificar_Click(object sender, EventArgs e)
        {
            ListarImg listarImg = new ListarImg(articulo);
            listarImg.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void cbxSitio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isInitializing || articulo == null)
                return;

            StockNegocio stNeg = new StockNegocio();
            try
            {

                if (int.TryParse(cbxSitio.SelectedValue.ToString(), out int idSitioSeleccionado))
                {
                    txtStock.Text = stNeg.ObtenerStockPorProductoYSitio(articulo.Id, idSitioSeleccionado).ToString();
                }
                else
                {
                    MessageBox.Show("El valor seleccionado no es un ID válido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el stock: " + ex.Message);
            }
        }
    }
}
