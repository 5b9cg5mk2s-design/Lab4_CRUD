using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Labb4Productos
{
    public partial class Form1 : Form
    {
        // Aplicamos inyección mediante el uso de la interfaz POO
        private readonly IProductoRepository _repository;
        private List<Producto> listaProductos;
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();
        private int idProductoSeleccionado = -1;

        public Form1()
        {
            InitializeComponent();
            _repository = new Conexion(); // Instanciamos la clase que implementa la interfaz
            listaProductos = new List<Producto>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cargarProductos(string filtro = "")
        {
            dgvProductos.Rows.Clear();
            dgvProductos.Refresh();

            // Consumimos el método a través de la interfaz abstracta
            listaProductos = _repository.ObtenerTodos(filtro);

            foreach (var prod in listaProductos)
            {
                // Criterio 4: Uso de método estático para transformar bytes a Bitmap de forma transparente
                Image img = ImagenHelper.ByteArrayToImage(prod.Imagen);

                // Pintamos las nuevas columnas de auditoría en la cuadrícula
                dgvProductos.Rows.Add(prod.Id, prod.Nombre, prod.Precio, prod.Cantidad, img, prod.Usuario, prod.FechaModificacion);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarProductos(txtBusqueda.Text.Trim());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen del producto";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        // OPERACIÓN: CREAR (Guardar)
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposEfectivo()) return;

            CargarDatosProductos();
            if (_repository.Insertar(myProducto))
            {
                MessageBox.Show("Se ha guardado satisfactoriamente el registro.");
                cargarProductos();
                LimpiarFormulario();
            }
        }

        // OPERACIÓN: ACTUALIZAR (Modificar con persistencia visual en el PictureBox)
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un producto haciendo clic sobre una fila de la tabla.");
                return;
            }

            if (!ValidarCamposEfectivo()) return;

            // Construcción del objeto mapeado bajo los requerimientos POO
            Producto prodModificado = new Producto
            {
                Id = idProductoSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Precio = decimal.Parse(txtPrecio.Text.Trim()),
                Cantidad = int.Parse(txtCantidad.Text.Trim()),
                Usuario = txtUsuario.Text.Trim(),
                // Criterio 4: Uso del método estático para convertir el gráfico a bytes
                Imagen = ImagenHelper.ImageToByteArray(pictureBox1.Image)
            };

            if (_repository.Actualizar(prodModificado))
            {
                MessageBox.Show("Registro modificado correctamente.");
                cargarProductos();
                LimpiarFormulario();
            }
        }

        // OPERACIÓN: ELIMINAR (Ejecuta Borrado Lógico cambiando el estado a 1)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == -1)
            {
                MessageBox.Show("Por favor, seleccione un producto haciendo clic sobre una fila de la tabla.");
                return;
            }

            DialogResult result = MessageBox.Show("¿Está seguro de enviar este producto al estado Anulado (Borrado Lógico)?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_repository.Anular(idProductoSeleccionado))
                {
                    MessageBox.Show("Producto anulado lógicamente de la base de datos.");
                    cargarProductos();
                    LimpiarFormulario();
                }
            }
        }

        // Sincroniza las celdas con los controles de texto al pulsar el DataGridView (Permite ver la imagen al modificar)
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                idProductoSeleccionado = Convert.ToInt32(row.Cells[0].Value);
                txtNombre.Text = row.Cells[1].Value.ToString();
                txtPrecio.Text = row.Cells[2].Value.ToString();
                txtCantidad.Text = row.Cells[3].Value.ToString();

                // Mapeamos de vuelta la imagen al PictureBox para que sea visible durante los cambios
                if (row.Cells[4].Value is Image img)
                {
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pictureBox1.Image = null;
                }

                txtUsuario.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CargarDatosProductos()
        {
            myProducto["nombre"] = txtNombre.Text.Trim();
            myProducto["precio"] = decimal.Parse(txtPrecio.Text.Trim());
            myProducto["cantidad"] = int.Parse(txtCantidad.Text.Trim());
            myProducto["usuario"] = txtUsuario.Text.Trim(); // Inserción del nuevo campo string
            myProducto["imagen"] = ImagenHelper.ImageToByteArray(pictureBox1.Image);
            myProducto["anulado"] = 0; // Por defecto ingresa como un registro activo
        }

        // Criterio 3: Control de errores de formato e interfaz mediante ErrorProvider no invasivo
        private bool ValidarCamposEfectivo()
        {
            // Limpiamos alertas previas
            errorProvider1.Clear();
            bool estadoValidacion = true;

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                errorProvider1.SetError(txtNombre, "El nombre del producto es obligatorio.");
                estadoValidacion = false;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
            {
                errorProvider1.SetError(txtUsuario, "Debe especificar el usuario operador.");
                estadoValidacion = false;
            }
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out _))
            {
                errorProvider1.SetError(txtPrecio, "Ingrese un formato de precio decimal válido.");
                estadoValidacion = false;
            }
            if (!int.TryParse(txtCantidad.Text.Trim(), out _))
            {
                errorProvider1.SetError(txtCantidad, "La cantidad debe ser un número entero válido.");
                estadoValidacion = false;
            }

            return estadoValidacion;
        }

        private void LimpiarFormulario()
        {
            idProductoSeleccionado = -1;
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtUsuario.Text = "";
            pictureBox1.Image = null;
            txtBusqueda.Text = "";
            myProducto.Clear();
            errorProvider1.Clear();
        }
    }
}

