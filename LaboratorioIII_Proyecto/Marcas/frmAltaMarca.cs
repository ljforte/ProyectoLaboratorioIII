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
    public partial class frmAltaMarca : Form
    {
        private Marcas seleccionado;
        private MarcasNegocio negocio;
        public frmAltaMarca()
        {
            InitializeComponent();
        }

        public frmAltaMarca(Marcas seleccionado)
        {
            InitializeComponent();
            this.seleccionado=seleccionado;
            this.lblTitulo.Text  = "MODIFICAR MARCA";
            btnAgregarMarca.Text = "Modificar";
            if(seleccionado != null ) 
            {
                txtbxNombre.Text = seleccionado.nombre;
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            negocio = new MarcasNegocio();

            try 
            {
                if( seleccionado == null ) 
                {
                    this.seleccionado = new Marcas();
                }

                if (string.IsNullOrWhiteSpace(txtbxNombre.Text))
                {
                    MessageBox.Show("El nombre de la marca no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (btnAgregarMarca.Text == "Agregar")
                {
                    seleccionado.nombre = txtbxNombre.Text;
                    negocio.AgregarMarca(seleccionado);
                    MessageBox.Show("Marca Agregada exitosamente");
                }
                else if (btnAgregarMarca.Text == "Modificar")
                {
                    seleccionado.nombre = txtbxNombre.Text;
                    negocio.Modificar(seleccionado);
                    MessageBox.Show("Marca Modificada exitosamente");
                }
                Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString()) ;
            }
        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
