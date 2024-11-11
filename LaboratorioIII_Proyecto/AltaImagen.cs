using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioIII_Proyecto
{
    public partial class AltaImagen : Form
    {
        Articulo art = new Articulo();
        ArtImg artImg = new ArtImg();
        public AltaImagen()
        {
            InitializeComponent();
        }

        public AltaImagen(ArtImg artImg)
        {
            this.artImg = artImg;
            InitializeComponent();
            this.btnAgregarImagen.Text = "Modificar";
            if (artImg != null)
            {
                txtUrlImagen.Text = artImg.ImagenUrl;
            }
        }

        public AltaImagen(Articulo art)
        {
            this.art = art;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (btnAgregarImagen.Text == "Agregar")
                {
                    if (string.IsNullOrWhiteSpace(txtUrlImagen.Text))
                    {
                        MessageBox.Show("Debe completar con una URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        ImagenNegocio negocio = new ImagenNegocio();
                        negocio.Agregar(txtUrlImagen.Text, art);
                        MessageBox.Show("Imagen Cargada Exitosamente");
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else if (btnAgregarImagen.Text == "Modificar")
                {
                    ImagenNegocio negocio = new ImagenNegocio();
                    artImg.ImagenUrl = txtUrlImagen.Text;
                    negocio.Modificar(artImg);
                    MessageBox.Show("Url Imagen modificada exitosamente");
                    Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
            private void pcbImagenUrl_Click(object sender, EventArgs e)
            {

            }

            private void cargarImagen(string imagen)
            {
                try
                {
                    pcbImagenUrl.Load(imagen);
                }
                catch (Exception)
                {
                    pcbImagenUrl.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
                }
            }

            private void AltaImagen_Load(object sender, EventArgs e)
            {


            }

            private void btnMostrarImagen_Click(object sender, EventArgs e)
            {
                cargarImagen(txtUrlImagen.Text);
            }

            private void btnCancelar_Click(object sender, EventArgs e)
            {
                Close();
            }

        }
    
}
