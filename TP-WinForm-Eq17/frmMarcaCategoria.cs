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
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void frmMarcaCategoria_Load(object sender, EventArgs e)
        {
            if(tag == "Marca")
            {
                Marca marca = new Marca();
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                //listaMarca = marcaNegocio.listar();
                lblNombre.Text = "Marca:";

            }
            else if(tag == "Categoria")
            {
                Categoria categoria = new Categoria();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                //listaCategoria= categoriaNegocio.listar();
                lblNombre.Text = "Categoria";
            }
        }

      
    }
}
