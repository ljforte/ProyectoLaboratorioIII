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
            negocio = new ArticuloNegocio();

            
            ArtImg img = new ArtImg();

            //Agregar Arituclo
            try
                {
                if (this.articulo ==null)
                {
                    this.articulo = new Articulo();
                }
                img.ImagenUrl = txtbUrlImagen.Text;
                    this.articulo.Nombre = txtbNombre.Text;
                    this.articulo.Codigo = txtbCodAr.Text;
                    this.articulo.Descripcion = txtbDescAr.Text;
                    this.articulo.MarcasCls = (Marcas)cbxMarca.SelectedItem;
                    this.articulo.CategoriasCls = (Categorias)cbxCat.SelectedItem;
                    this.articulo.Precio = decimal.Parse(txtbPrecio.Text);
                    this.articulo.Descripcion = txtbDescAr.Text;
                    this.articulo.Imagen = new ArtImg();
                    img.ImagenUrl = txtbUrlImagen.Text;

                if (btnAgregar.Text == "Agregar")
                {
                    negocio.Agregar(this.articulo, img);
                    MessageBox.Show("Articulo agregado correctamente.");
                }
                else if (btnAgregar.Text == "Modificar") {
                    negocio.Modificar(this.articulo);
                }
                    


                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }



        

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcasNegocio marca = new MarcasNegocio();
            //btnImagenModificar.Visible = false;
            try
            {
                cbxMarca.DataSource = marca.ListarMarcas();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion";
                cbxCat.DataSource = categoria.ListarCategoria();
                cbxCat.ValueMember = "Id";
                cbxCat.DisplayMember = "Descripcion";

                if (articulo != null) //Si es diferentes entonces MOD aca!, Seteamos 
                {
                    //artImg.ImagenUrl = txtbUrlImagen.Text;
                    txtbNombre.Text = articulo.Nombre;
                    txtbCodAr.Text = articulo.Codigo;
                    txtbDescAr.Text = articulo.Descripcion;
                    txtbPrecio.Text = articulo.Precio.ToString();
                    cbxMarca.SelectedValue = articulo.MarcasCls.Id;
                    cbxCat.SelectedValue = articulo.CategoriasCls.Id;
                    cargarImagen(this.articulo.Imagen.ImagenUrl);
                    //artImg.ImagenUrl = txtbUrlImagen.Text;
                    // imagen se puede generar funcion para que con el id de articulo muestre imagen
                    // se puede sobre cargar cargar imagen para que lo haga con el id de articulo.
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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
    }
}
