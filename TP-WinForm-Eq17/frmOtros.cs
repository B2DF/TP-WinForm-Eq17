using dominio;
using negocio;
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
    public partial class frmOtros : Form
    {
        private Articulo articulo = null;
        private List<Imagenes> imagenes; //TODAS LAS IMAGENES DE LA DB
        private List<Imagenes> listaImagenesAlta = new List<Imagenes>();//Lista cuando no hay articulo
        private List<Imagenes> listaImgFiltradas = new List<Imagenes>();//Lista cuando hay articulo
        private List<Imagenes> listaModificar = new List<Imagenes>();//Lista cuando hay articulo y modificamos, para retornar.
        private List<Imagenes> listaAgregarImgArticulosExistentes = new List<Imagenes>();//Lista agregar imagenes a articulos existentes, para retornar
        private int contador = 0;
        private int currentImg = 1;
        public frmOtros()
        {
            InitializeComponent();
            Text = "Agregar";
        }
        public frmOtros(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar/Agregar";
        }

        private void frmOtros_Load(object sender, EventArgs e)
        {
            lblContTotal.Text = "";
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            try
            {
                if (articulo == null)
                {
                    gpbxArticulo.Visible = false;
                    lblContTotal.Text = "Imagenes: " + contador;
                    lblContImg.Text = "" + contador + "/" + listaImagenesAlta.Count;
                }
                else
                {
                    gpbxArticulo.Visible = true;
                    imagenes = imagenesNegocio.listar();
                    listaImgFiltradas = imagenes.FindAll(x => x.IdArticulo == articulo.Id);
                    if (listaImgFiltradas.Count == 0)
                        cargarImagen("");
                    else
                        cargarImagen(listaImgFiltradas[0].ImagenUrl);
                    contador = listaImgFiltradas.Count;
                    tbxNombre.Text = articulo.Nombre;
                    tbxId.Text = articulo.Id.ToString();
                    if (listaImgFiltradas.Count > 0)
                    {
                        tbxSource.Text = listaImgFiltradas[currentImg - 1].ImagenUrl;
                    }
                    lblContImg.Text = "" + currentImg + "/" + listaImgFiltradas.Count;
                    lblContTotal.Text = "Imagenes: " + contador;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tbxSource_Leave(object sender, EventArgs e)
        {
            cargarImagen(tbxSource.Text);
        }
        private void cargarImagen(string url)
        {
            try
            {
                pbxOtros.Load(url);
            }
            catch (Exception ex)
            {
                pbxOtros.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            }
        }
        private void cargarImagenChecked(string url)
        {
            try
            {
                pbxCheckError.Load(url);
            }
            catch (Exception ex)
            {

                pbxCheckError.Visible = false;
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Imagenes imagen = new Imagenes();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (articulo == null)
                {
                    if (tbxSource.Text == "")
                    {
                        cargarImagenChecked("https://e7.pngegg.com/pngimages/943/637/png-clipart-stop-sign-no-symbol-warning-sign-red-block-sign-s-angle-text.png");
                        return;
                    }
                    else
                    {
                        cargarImagenChecked("https://e7.pngegg.com/pngimages/944/793/png-clipart-computer-icons-check-mark-presentation-symbol-check-list-miscellaneous-angle.png");
                        datos.setearConsulta("SELECT MAX(Id) maxId FROM ARTICULOS");
                        imagen.IdArticulo = (int)datos.ejecturarScalar() + 1;
                        imagen.ImagenUrl = tbxSource.Text;
                    }
                    listaImagenesAlta.Add(imagen);
                    lblContImg.Text = "" + currentImg + "/" + listaImagenesAlta.Count;
                }
                else
                {
                    if (tbxSource.Text == "")
                    {
                        cargarImagenChecked("https://e7.pngegg.com/pngimages/943/637/png-clipart-stop-sign-no-symbol-warning-sign-red-block-sign-s-angle-text.png");
                        return;
                    }
                    else
                    {
                        cargarImagenChecked("https://e7.pngegg.com/pngimages/944/793/png-clipart-computer-icons-check-mark-presentation-symbol-check-list-miscellaneous-angle.png");
                        imagen.ImagenUrl = tbxSource.Text;
                        imagen.IdArticulo = articulo.Id;
                    }
                    listaImgFiltradas.Add(imagen);
                    listaAgregarImgArticulosExistentes.Add(imagen);
                    lblContImg.Text = "" + currentImg + "/" + listaImgFiltradas.Count;
                }
                MessageBox.Show("Agregado correcto. Puede seguir cargando imagenes.");
                contador++;
                lblContTotal.Text = "Imagenes: " + contador;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        public List<Imagenes> retornarListaImagenesAlta()
        {
            return listaImagenesAlta;
        }
        public List<Imagenes> retornarListaImgModificar()
        {
            return listaModificar;
        }
        public List<Imagenes> retornarListaAgregarImgArtExistenes()
        {
            return listaAgregarImgArticulosExistentes;
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (articulo == null)
            {
                if (listaImagenesAlta.Count > 1)
                {
                    if (currentImg > 1)
                    {
                        currentImg--;
                    }
                    cargarImagen(listaImagenesAlta[currentImg - 1].ImagenUrl);
                    lblContImg.Text = "" + currentImg + "/" + listaImagenesAlta.Count;
                    tbxSource.Text = listaImagenesAlta[currentImg - 1].ImagenUrl;
                }
            }
            else
            {
                if (listaImgFiltradas.Count > 1)
                {
                    if (currentImg > 1)
                    {
                        currentImg--;
                    }
                    cargarImagen(listaImgFiltradas[currentImg - 1].ImagenUrl);
                    lblContImg.Text = "" + currentImg + "/" + listaImgFiltradas.Count;
                    tbxSource.Text = listaImgFiltradas[currentImg - 1].ImagenUrl;
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (articulo == null)
            {
                if (listaImagenesAlta.Count > 1)
                {
                    if (currentImg < listaImagenesAlta.Count)
                    {
                        currentImg++;
                    }
                    cargarImagen(listaImagenesAlta[currentImg - 1].ImagenUrl);
                    lblContImg.Text = "" + currentImg + "/" + listaImagenesAlta.Count;
                    tbxSource.Text = listaImagenesAlta[currentImg - 1].ImagenUrl;
                }
            }
            else
            {
                if (listaImgFiltradas.Count > 1)
                {
                    if (currentImg < listaImgFiltradas.Count)
                    {
                        currentImg++;
                    }
                    cargarImagen(listaImgFiltradas[currentImg - 1].ImagenUrl);
                    lblContImg.Text = "" + currentImg + "/" + listaImgFiltradas.Count;
                    tbxSource.Text = listaImgFiltradas[currentImg - 1].ImagenUrl;
                }
            }
        }

        private void btnLimpiarCampo_Click(object sender, EventArgs e)
        {
            tbxSource.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (articulo != null && listaImgFiltradas.Count > 0)
            {
                listaImgFiltradas[currentImg - 1].ImagenUrl = tbxSource.Text;
                listaModificar.Add(listaImgFiltradas[currentImg - 1]);
            }
            else
            {
                if (listaImagenesAlta.Count == 0)
                {
                    MessageBox.Show("No existe una imagen para el articulo, Agreguelo.");
                }
                else
                    listaImagenesAlta[currentImg - 1].ImagenUrl = tbxSource.Text;
            }
        }
    }
}
