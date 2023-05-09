using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TP_WinForm_Eq17
{
    public partial class frmMarcaCategoria : Form
    {
        string tag;
        private List<Categoria> listaCategoria;
        private List<Marca> listaMarca;

        public frmMarcaCategoria()
        {
            InitializeComponent();
        }
        public frmMarcaCategoria(string tag)
        {
            InitializeComponent();
            this.tag = tag;
            if (tag == "Marca")
                Text = tag;
            if(tag=="Categoria")
                Text = tag;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (tag == "Marca")
            {
                Marca marca = new Marca();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                marca.Descripcion=tbxNombre.Text;
                marcaNegocio.agregar(marca);
            }
            else if (tag == "Categoria")
            {
                Categoria categoria = new Categoria();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                categoria.Descripcion= tbxNombre.Text;
                categoriaNegocio.agregar(categoria);
            }
            MessageBox.Show("Agregado exitosamente");
        }

        private void frmMarcaCategoria_Load(object sender, EventArgs e)
        {
            if(tag == "Marca")
            {
                lblNombre.Text = "Marca:";
            }
            else if(tag == "Categoria")
            {
                lblNombre.Text = "Categoria";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
