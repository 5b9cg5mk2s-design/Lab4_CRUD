namespace Labb4Productos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            txtBusqueda = new TextBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            dgvProductos = new DataGridView();
            btnGuardar = new Button();
            imageList1 = new ImageList(components);
            btnModificar = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            button5 = new Button();
            errorProvider1 = new ErrorProvider(components);
            txtUsuario = new TextBox();
            label6 = new Label();
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Imagen = new DataGridViewTextBoxColumn();
            usuario = new DataGridViewTextBoxColumn();
            fecha_modificacion = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(txtBusqueda);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(37, 266);
            panel1.Name = "panel1";
            panel1.Size = new Size(806, 100);
            panel1.TabIndex = 0;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(193, 32);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(379, 27);
            txtBusqueda.TabIndex = 0;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(599, 20);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(65, 49);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(96, 35);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 7;
            label1.Text = "Búsqueda";
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Precio, Cantidad, Imagen, usuario, fecha_modificacion });
            dgvProductos.Location = new Point(12, 388);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(880, 188);
            dgvProductos.TabIndex = 1;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // btnGuardar
            // 
            btnGuardar.ImageIndex = 0;
            btnGuardar.ImageList = imageList1;
            btnGuardar.Location = new Point(93, 595);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(114, 54);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "editar.png");
            // 
            // btnModificar
            // 
            btnModificar.ImageIndex = 0;
            btnModificar.ImageList = imageList1;
            btnModificar.Location = new Point(230, 595);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(136, 54);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // button3
            // 
            button3.ImageIndex = 0;
            button3.ImageList = imageList1;
            button3.Location = new Point(386, 595);
            button3.Name = "button3";
            button3.Size = new Size(126, 54);
            button3.TabIndex = 4;
            button3.Text = "Eliminar";
            button3.TextImageRelation = TextImageRelation.TextBeforeImage;
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnEliminar_Click;
            // 
            // button4
            // 
            button4.ImageIndex = 0;
            button4.ImageList = imageList1;
            button4.Location = new Point(538, 595);
            button4.Name = "button4";
            button4.Size = new Size(102, 54);
            button4.TabIndex = 5;
            button4.Text = "Limpiar";
            button4.TextImageRelation = TextImageRelation.TextBeforeImage;
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnLimpiar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(547, 96);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 8;
            label2.Text = "Imagen:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(627, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(197, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 105);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 11;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 155);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 12;
            label4.Text = "Precio";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 200);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 13;
            label5.Text = "Cantidad";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(133, 105);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(379, 27);
            txtNombre.TabIndex = 10;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(133, 152);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(379, 27);
            txtPrecio.TabIndex = 14;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(133, 200);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(379, 27);
            txtCantidad.TabIndex = 15;
            // 
            // button5
            // 
            button5.ImageIndex = 0;
            button5.ImageList = imageList1;
            button5.Location = new Point(667, 595);
            button5.Name = "button5";
            button5.Size = new Size(102, 54);
            button5.TabIndex = 16;
            button5.Text = "Salir";
            button5.TextImageRelation = TextImageRelation.TextBeforeImage;
            button5.UseVisualStyleBackColor = true;
            button5.Click += btnSalir_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(133, 54);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(379, 27);
            txtUsuario.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 54);
            label6.Name = "label6";
            label6.Size = new Size(59, 20);
            label6.TabIndex = 18;
            label6.Text = "Usuario";
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 125;
            // 
            // Imagen
            // 
            Imagen.HeaderText = "Imagen";
            Imagen.MinimumWidth = 6;
            Imagen.Name = "Imagen";
            Imagen.Width = 125;
            // 
            // usuario
            // 
            usuario.HeaderText = "usuario";
            usuario.MinimumWidth = 6;
            usuario.Name = "usuario";
            usuario.Width = 125;
            // 
            // fecha_modificacion
            // 
            fecha_modificacion.HeaderText = "fecha_modificacion";
            fecha_modificacion.MinimumWidth = 6;
            fecha_modificacion.Name = "fecha_modificacion";
            fecha_modificacion.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 690);
            Controls.Add(label6);
            Controls.Add(txtUsuario);
            Controls.Add(button5);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvProductos);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtBusqueda;
        private DataGridView dgvProductos;
        private Button btnGuardar;
        private Button btnModificar;
        private Button button3;
        private Button button4;
        private ImageList imageList1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private Button button5;
        private ErrorProvider errorProvider1;
        private Label label6;
        private TextBox txtUsuario;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Imagen;
        private DataGridViewTextBoxColumn usuario;
        private DataGridViewTextBoxColumn fecha_modificacion;
    }
}
