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
        private List<Imagenes> listaImagenesAlta = new List<Imagenes>();//Lista cuando no hay articulo
        private List<Imagenes> listaModificar = new List<Imagenes>();//Lista cuando hay articulo y modificamos, para retornar.
        private List<Imagenes> listaAgregarImgArticulosExistentes = new List<Imagenes>();//Lista agregar imagenes a articulos existentes, para retornar
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = tbxDescripcion.Text;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Precio = decimal.Parse(tbxPrecio.Text);
                if (listaImagenesAlta != null && listaImagenesAlta.Count > 0)
                {
                    foreach (Imagenes imagen in listaImagenesAlta)
                    {
                        imagenesNegocio.agregar(imagen);
                    }
                }
                if (listaAgregarImgArticulosExistentes != null && listaAgregarImgArticulosExistentes.Count > 0)
                {
                    foreach (Imagenes imagen in listaAgregarImgArticulosExistentes)
                    {
                        imagenesNegocio.agregar(imagen);
                    }
                }
                if (listaModificar != null && listaModificar.Count > 0)
                {
                    foreach (Imagenes imagen in listaModificar)
                    {
                        imagenesNegocio.modificar(imagen);
                    }
                }
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
                    btnAgregarMarca.Visible = false;
                    cboCategoria.Visible = false;
                    tbxCategoria.Visible = true;
                    btnAgregarCategoria.Visible = false;
                    lblUrlImagen.Visible = false;
                    btnAgregarImagen.Visible = false;
                    tbxPrecio.ReadOnly = true;
                    tbxPrecio.TabStop = false;
                    lblPrecio.Location= new System.Drawing.Point(54, 245);
                    tbxPrecio.Location = new System.Drawing.Point(160, 242);
                    btnAceptar.Visible = false;
                    btnCancelar.Visible = false;
                }
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            frmOtros frmImagen;
            if (articulo == null)
                frmImagen = new frmOtros(); 
            else
                frmImagen = new frmOtros(articulo);
            frmImagen.ShowDialog();
            listaImagenesAlta = frmImagen.retornarListaImagenesAlta();
            listaAgregarImgArticulosExistentes = frmImagen.retornarListaAgregarImgArtExistenes();
            listaModificar = frmImagen.retornarListaImgModificar();
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria frmMarca = new frmMarcaCategoria("Marca");
            frmMarca.ShowDialog();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            frmMarcaCategoria frmCategoria = new frmMarcaCategoria("Categoria");
            frmCategoria.ShowDialog();
        }
    }
}
