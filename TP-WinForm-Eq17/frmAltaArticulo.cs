using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using negocio;
using dominio;
using System.Globalization;

namespace TP_WinForm_Eq17
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        private List<Imagenes> imagenes;
        private List<Imagenes> imagenesMismoIdArticulo;
        bool detalle;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }
        public frmAltaArticulo(Articulo articulo, bool detalle)
        {
            InitializeComponent();
            this.articulo= articulo;
            this.detalle= detalle;
            Text = "Detalle Articulo";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = tbxDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                //imagenes
                articulo.Precio = decimal.Parse(tbxPrecio.Text);

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

            try
            {
                tbxMarca.Visible = false;
                tbxCategoria.Visible = false;
                if (detalle)
                {
                    tbxCodigo.ReadOnly = true;
                    tbxCodigo.TabStop = false;
                    tbxNombre.ReadOnly = true;
                    tbxNombre.TabStop = false;
                    tbxDescripcion.ReadOnly = true;
                    tbxDescripcion.TabStop = false;
                    cboMarca.Visible = false;
                    tbxMarca.Visible = true;
                    cboCategoria.Visible = false;
                    tbxCategoria.Visible = true;
                    lblUrlImagen.Visible = false;
                    tbxUrlImagen.Visible = false;
                    tbxPrecio.ReadOnly = true;
                    tbxPrecio.TabStop = false;
                    lblPrecio.Location= new System.Drawing.Point(54, 245);
                    tbxPrecio.Location = new System.Drawing.Point(160, 242);
                    btnAceptar.Visible = false;
                    btnCancelar.Visible = false;
                }
                imagenes = imagenesNegocio.listar();

                if(articulo!=null)
                {
                    imagenesMismoIdArticulo = imagenes.FindAll(x => x.IdArticulo == articulo.Id);
                    if (imagenesMismoIdArticulo.Count == 0)
                        cargarImagen("");
                    else
                        cargarImagen(imagenesMismoIdArticulo[0].ImagenUrl);
                }
                //pbxAltaArticulo.Load(imagenes[0].ImagenUrl);

                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    tbxCodigo.Text = articulo.Codigo;
                    tbxNombre.Text = articulo.Nombre;
                    tbxDescripcion.Text = articulo.Descripcion;
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    tbxPrecio.Text = articulo.Precio.ToString();
                    if (detalle)
                    {
                        tbxCodigo.Text = articulo.Codigo;
                        tbxNombre.Text = articulo.Nombre;
                        tbxDescripcion.Text = articulo.Descripcion;
                        tbxMarca.Text = articulo.Marca.Descripcion;
                        tbxCategoria.Text = articulo.Categoria.Descripcion;
                        tbxPrecio.Text = articulo.Precio.ToString("C2", CultureInfo.GetCultureInfo("en-US"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
            
        }

        private void tbxUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(tbxUrlImagen.Text);
             
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAltaArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxAltaArticulo.Load("https://www.campana.gob.ar/wp-content/uploads/2022/05/placeholder-1.png");
            }
        }
    }
}
