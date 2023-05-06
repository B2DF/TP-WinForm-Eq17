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
    public partial class frmPrincipal : Form
    {
        private List<Articulo> listaArticulos;
        private List<Imagenes> imagenes;
        private List<Imagenes> imagenesMismoIdArticulo;
        private int currentImg = 1;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            try
            {
                listaArticulos = articuloNegocio.listar();
                imagenes = imagenesNegocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                //dgv.DataSource = imagenes;
                pbxArticulos.Load(imagenes[0].ImagenUrl);
            }
            catch (Exception ex)
            {

                //throw ex;
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            bool primeraImagen = false;
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                foreach (Imagenes imagen in imagenes)
                {
                    if (seleccionado.Id == imagen.IdArticulo && !primeraImagen)
                    {
                        pbxArticulos.Load(imagen.ImagenUrl);
                        primeraImagen = true;
                    }
                }
                //Imagenes seleccionado = (Imagenes)dgv.CurrentRow.DataBoundItem;
                //pbx.Load(seleccionado.ImagenUrl);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                pbxArticulos.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            }
            currentImg = 1;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            imagenesMismoIdArticulo = imagenes.FindAll(x => x.IdArticulo == seleccionado.Id);
            if (imagenesMismoIdArticulo.Count > 1)
            {
                if (currentImg < imagenesMismoIdArticulo.Count)
                {
                    currentImg++;
                }
                pbxArticulos.Load(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            imagenesMismoIdArticulo = imagenes.FindAll(x => x.IdArticulo == seleccionado.Id);
            if (imagenesMismoIdArticulo.Count > 1)
            {
                if (currentImg > 1)
                {
                    currentImg--;
                }
                pbxArticulos.Load(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmDetalleArticulo frmDetalle = new frmDetalleArticulo(seleccionado);
            frmDetalle.ShowDialog();
        }
    }
}
