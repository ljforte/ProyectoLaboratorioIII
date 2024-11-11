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
    public partial class ListarImg : Form
    {
        private Articulo articulo{ get; set; }
        private ArtImg seleccionado { get; set; }
        private List<ArtImg> ListaImagenes;

        public ListarImg()
        {
            InitializeComponent();
        }

        public ListarImg(Articulo art)
        {
            articulo = art;
            InitializeComponent();
        }

        private void ListarImg_Load(object sender, EventArgs e)
        {
            cargarImagenes();
        }
        private void cargarImagen(ArtImg img)
        {
            if (img.ImagenUrl == null)
            {
                picbxImagenes.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
            else
            {
                try
                {
                    picbxImagenes.Load(img.ImagenUrl);
                }
                catch (Exception)
                {
                    picbxImagenes.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
                }
            }
        }

        private void dgvImagenes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                seleccionado = (ArtImg)dgvImagenes.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void btnAgregarImg_Click(object sender, EventArgs e)
        {
            ImagenNegocio negocio = new ImagenNegocio();
            AltaImagen altaImagen = new AltaImagen(articulo);
            altaImagen.ShowDialog();
            cargarImagenes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ArtImg artImg = (ArtImg)dgvImagenes.CurrentRow.DataBoundItem;
            AltaImagen altaImagen = new AltaImagen(artImg);
            altaImagen.ShowDialog();
            cargarImagenes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ImagenNegocio negocio = new ImagenNegocio();
                negocio.EliminarImagen(seleccionado);
                MessageBox.Show("Imagen Eliminada con exito");
            }   
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally 
            {
                cargarImagenes();
            }
         }

        public void cargarImagenes()
        {
            ImagenNegocio negocio = new ImagenNegocio();
            try
            {
                ListaImagenes = negocio.ListarImagenes(articulo);
                dgvImagenes.DataSource = ListaImagenes;
                if (ListaImagenes.Count > 0)
                {
                    seleccionado = (ArtImg)dgvImagenes.CurrentRow.DataBoundItem;
                    cargarImagen(seleccionado);
                }
                else
                {
                    negocio.Agregar("https://cdn.discordapp.com/attachments/734093444271833240/1285101890043904060/large.png?ex=66e90be6&is=66e7ba66&hm=b75a4615744f20ca15d0e0527bc9564897c752eb20aa1230344d1fdaa89dfd31&", articulo);
                    MessageBox.Show("Articulo sin Imagen, se agregara imagen generica.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
