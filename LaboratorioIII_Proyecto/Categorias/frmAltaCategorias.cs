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
    public partial class frmAltaCategoria : Form
    {
        private Categorias categoria;
        private CategoriaNegocio negocio;

        public frmAltaCategoria()
        {
            InitializeComponent();
        }

        public frmAltaCategoria(Categorias categoria)
        {
            InitializeComponent();            
            this.categoria=categoria;
            this.lblCrearCategoria.Text = "Modificar Categoria";
            this.btnAgregar.Text = "Modificar";
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            negocio = new CategoriaNegocio(); 
            try
            {
                if(categoria==null) this.categoria = new Categorias();
                categoria.Descripcion = txtbxNombre.Text;
               
                if (btnAgregar.Text=="Agregar")
                {
                    negocio.agregar(categoria);
                    MessageBox.Show("Categoria Agregada exitosamente");
                }
                else if (btnAgregar.Text=="Modificar") {
                    negocio.modificar(this.categoria);
                    MessageBox.Show("Categoria Modificada exitosamente");
                }
                
                Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally { }
        }

        private void txtbxCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAltaCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
