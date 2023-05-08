using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        public frmPrincipal(Articulo articulo)
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            //ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            //try
            //{
            //    listaArticulos = articuloNegocio.listar();
            //    imagenes = imagenesNegocio.listar();
            //    dgvArticulos.DataSource = listaArticulos;
            //    dgv.DataSource = imagenes;
            //    pbxArticulos.Load(imagenes[0].ImagenUrl);
            //}
            //catch (Exception ex)
            //{

            //    //throw ex;
            //    MessageBox.Show(ex.ToString());
            //}
            cargar();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            //bool primeraImagen = false;
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                imagenesMismoIdArticulo = imagenes.FindAll(x => x.IdArticulo == seleccionado.Id);
                if (imagenesMismoIdArticulo.Count == 0)
                    cargarImagen("");
                else
                    cargarImagen(imagenesMismoIdArticulo[0].ImagenUrl);
                //foreach (Imagenes imagen in imagenes)
                //{
                //    if (seleccionado.Id == imagen.IdArticulo && !primeraImagen)
                //    {
                //        pbxArticulos.Load(imagen.ImagenUrl);
                //        primeraImagen = true;
                //    }
                //}
                //Imagenes seleccionado = (Imagenes)dgv.CurrentRow.DataBoundItem;
                //pbx.Load(seleccionado.ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //pbxArticulos.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
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
                //pbxArticulos.Load(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
                cargarImagen(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
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
                //pbxArticulos.Load(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
                cargarImagen(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulo frmdetalle = new frmAltaArticulo(seleccionado, true);
            frmdetalle.ShowDialog();
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            try
            {
                listaArticulos = negocio.listar();
                imagenes = imagenesNegocio.listar();
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvArticulos.Columns["Precio"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void cargarImagen(string url)
        {
            try
            {
                pbxArticulos.Load(url);
            }
            catch (Exception ex)
            {
                pbxArticulos.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo selecionado;
            selecionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar = new frmAltaArticulo(selecionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar el articulo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                negocio.eliminar(seleccionado.Id);
                cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
