using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_WinForm_Eq17
{
    public partial class frmDetalleArticulo : Form
    {
        private Articulo artDetalle;
        public frmDetalleArticulo()
        {
            InitializeComponent();
        }
        public frmDetalleArticulo(Articulo artDetalle)
        {
            InitializeComponent();
            this.artDetalle = artDetalle;
        }

        private void frmDetalleArticulo_Load(object sender, EventArgs e)
        {
            tbxCodigo.Text = artDetalle.Codigo;
            tbxNombre.Text = artDetalle.Nombre;
            tbxDescripcion.Text = artDetalle.Descripcion;
            tbxMarca.Text = artDetalle.Marca.Descripcion;
            tbxCategoria.Text = artDetalle.Categoria.Descripcion;
            tbxPrecio.Text = artDetalle.Precio.ToString();
        }
    }
}
