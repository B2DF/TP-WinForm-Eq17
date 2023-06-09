﻿using dominio;
using negocio;
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
            cargar();
            cbSeleccionar.Items.Add("Codigo");
            cbSeleccionar.Items.Add("Nombre");
            cbSeleccionar.Items.Add("Descripcion");
            cbSeleccionar.Items.Add("Precio");
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    imagenesMismoIdArticulo = imagenes.FindAll(x => x.IdArticulo == seleccionado.Id);
                    if (imagenesMismoIdArticulo.Count == 0)
                        cargarImagen("");
                    else
                        cargarImagen(imagenesMismoIdArticulo[0].ImagenUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            currentImg = 1;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                imagenesMismoIdArticulo = imagenes.FindAll(x => x.IdArticulo == seleccionado.Id);
                if (imagenesMismoIdArticulo.Count > 1)
                {
                    if (currentImg < imagenesMismoIdArticulo.Count)
                    {
                        currentImg++;
                    }
                    cargarImagen(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
                }
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                imagenesMismoIdArticulo = imagenes.FindAll(x => x.IdArticulo == seleccionado.Id);
                if (imagenesMismoIdArticulo.Count > 1)
                {
                    if (currentImg > 1)
                    {
                        currentImg--;
                    }
                    cargarImagen(imagenesMismoIdArticulo[currentImg - 1].ImagenUrl);
                }
            }
        }

        private bool validarCampos()
        {
            if(cbSeleccionar.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }

            if (cbCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return true;
            }

            if (cbSeleccionar.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtValor.Text))
                {
                    MessageBox.Show("Debes cargar el filtro para precio...");
                    return true;
                }
                if (!(soloNumeros(txtValor.Text)))
                {
                    MessageBox.Show("Solo nros para filtrar por un campo precio...");
                    return true;
                }

            }
            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo frmdetalle = new frmAltaArticulo(seleccionado, true);
                frmdetalle.ShowDialog();
            }
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
                dgvArticulos.Columns["Id"].Visible = false;
                dgvArticulos.Columns["Descripcion"].Visible = false;
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
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo selecionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo modificar = new frmAltaArticulo(selecionado);
                modificar.ShowDialog();
                cargar();
            } 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (dgvArticulos.CurrentRow != null)
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar el articulo seleccionado?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                    {
                        Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        negocio.eliminar(seleccionado.Id);
                        cargar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarCampos()) return;

                string campo = cbSeleccionar.SelectedItem.ToString();
                string criterio = cbCriterio.SelectedItem.ToString();
                string filtro = txtValor.Text;
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void cbSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbSeleccionar.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Mayor a");
                cbCriterio.Items.Add("Menor a");
                cbCriterio.Items.Add("Igual a");
            }
            else
            {
                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Comienza con");
                cbCriterio.Items.Add("Termina con");
                cbCriterio.Items.Add("Contiene");
            }
        }
    }
}
