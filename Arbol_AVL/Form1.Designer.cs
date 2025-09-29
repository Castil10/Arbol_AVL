namespace Arbol_AVL
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Controles necesarios para tu código
        public TextBox valor;
        public ErrorProvider errores;
        public Label lblaltura;
        public Button btnIngresar;
        public Button btnBuscar;
        public Button btneliminar;
        public Button bsalir;
        public Label labelAltura;
        public Label labelRecorridos;

        // NUEVOS BOTONES PARA RECORRIDOS
        public Button btnEnOrden;
        public Button btnPreOrden;
        public Button btnPostOrden;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            valor = new TextBox();
            errores = new ErrorProvider(components);
            lblaltura = new Label();
            btnIngresar = new Button();
            btnBuscar = new Button();
            btneliminar = new Button();
            bsalir = new Button();
            labelAltura = new Label();
            labelRecorridos = new Label();
            btnEnOrden = new Button();
            btnPreOrden = new Button();
            btnPostOrden = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)errores).BeginInit();
            SuspendLayout();
            // 
            // valor
            // 
            valor.BackColor = Color.FromArgb(192, 192, 255);
            valor.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valor.Location = new Point(743, 76);
            valor.Margin = new Padding(3, 4, 3, 4);
            valor.Name = "valor";
            valor.Size = new Size(226, 30);
            valor.TabIndex = 1;
            valor.TextChanged += valor_TextChanged;
            valor.KeyPress += valor_KeyPress;
            // 
            // errores
            // 
            errores.ContainerControl = this;
            // 
            // lblaltura
            // 
            lblaltura.AutoSize = true;
            lblaltura.BackColor = Color.FromArgb(192, 192, 255);
            lblaltura.BorderStyle = BorderStyle.FixedSingle;
            lblaltura.Location = new Point(938, 116);
            lblaltura.Name = "lblaltura";
            lblaltura.Padding = new Padding(6, 7, 6, 7);
            lblaltura.Size = new Size(31, 36);
            lblaltura.TabIndex = 3;
            lblaltura.Text = "0";
            lblaltura.Click += lblaltura_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(192, 192, 255);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Arial", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIngresar.Location = new Point(786, 171);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(171, 47);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(192, 192, 255);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Arial", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(786, 226);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(171, 47);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btneliminar
            // 
            btneliminar.BackColor = Color.Red;
            btneliminar.FlatAppearance.BorderColor = Color.Black;
            btneliminar.FlatStyle = FlatStyle.Flat;
            btneliminar.Font = new Font("Arial", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btneliminar.ForeColor = Color.Black;
            btneliminar.Location = new Point(786, 281);
            btneliminar.Margin = new Padding(3, 4, 3, 4);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(171, 47);
            btneliminar.TabIndex = 6;
            btneliminar.Text = "Eliminar";
            btneliminar.UseVisualStyleBackColor = false;
            btneliminar.Click += btneliminar_Click;
            // 
            // bsalir
            // 
            bsalir.BackColor = Color.Red;
            bsalir.FlatStyle = FlatStyle.Flat;
            bsalir.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bsalir.ForeColor = Color.Black;
            bsalir.Location = new Point(817, 519);
            bsalir.Margin = new Padding(3, 4, 3, 4);
            bsalir.Name = "bsalir";
            bsalir.Size = new Size(152, 43);
            bsalir.TabIndex = 11;
            bsalir.Text = "Salir";
            bsalir.UseVisualStyleBackColor = false;
            bsalir.Click += bsalir_Click_1;
            // 
            // labelAltura
            // 
            labelAltura.AutoSize = true;
            labelAltura.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAltura.Location = new Point(754, 128);
            labelAltura.Name = "labelAltura";
            labelAltura.Size = new Size(164, 24);
            labelAltura.TabIndex = 2;
            labelAltura.Text = "Altura del Árbol:";
            labelAltura.Click += labelAltura_Click;
            // 
            // labelRecorridos
            // 
            labelRecorridos.AutoSize = true;
            labelRecorridos.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelRecorridos.Location = new Point(749, 347);
            labelRecorridos.Name = "labelRecorridos";
            labelRecorridos.Size = new Size(210, 24);
            labelRecorridos.TabIndex = 7;
            labelRecorridos.Text = "Recorridos del árbol:";
            // 
            // btnEnOrden
            // 
            btnEnOrden.BackColor = Color.FromArgb(0, 0, 192);
            btnEnOrden.FlatAppearance.BorderColor = Color.Black;
            btnEnOrden.FlatStyle = FlatStyle.Flat;
            btnEnOrden.Font = new Font("Arial", 10.8F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnEnOrden.ForeColor = SystemColors.ButtonFace;
            btnEnOrden.Location = new Point(743, 375);
            btnEnOrden.Margin = new Padding(3, 4, 3, 4);
            btnEnOrden.Name = "btnEnOrden";
            btnEnOrden.Size = new Size(226, 40);
            btnEnOrden.TabIndex = 8;
            btnEnOrden.Text = "Recorrido En Orden";
            btnEnOrden.UseVisualStyleBackColor = false;
            btnEnOrden.Click += btnEnOrden_Click;
            // 
            // btnPreOrden
            // 
            btnPreOrden.BackColor = Color.FromArgb(0, 0, 192);
            btnPreOrden.FlatAppearance.BorderColor = Color.Black;
            btnPreOrden.FlatStyle = FlatStyle.Flat;
            btnPreOrden.Font = new Font("Arial", 10.8F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnPreOrden.ForeColor = Color.White;
            btnPreOrden.Location = new Point(743, 423);
            btnPreOrden.Margin = new Padding(3, 4, 3, 4);
            btnPreOrden.Name = "btnPreOrden";
            btnPreOrden.Size = new Size(226, 40);
            btnPreOrden.TabIndex = 9;
            btnPreOrden.Text = "Recorrido Pre Orden";
            btnPreOrden.UseVisualStyleBackColor = false;
            btnPreOrden.Click += btnPreOrden_Click;
            // 
            // btnPostOrden
            // 
            btnPostOrden.BackColor = Color.FromArgb(0, 0, 192);
            btnPostOrden.FlatAppearance.BorderColor = Color.Black;
            btnPostOrden.FlatStyle = FlatStyle.Flat;
            btnPostOrden.Font = new Font("Arial", 10.8F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnPostOrden.ForeColor = Color.White;
            btnPostOrden.Location = new Point(743, 471);
            btnPostOrden.Margin = new Padding(3, 4, 3, 4);
            btnPostOrden.Name = "btnPostOrden";
            btnPostOrden.Size = new Size(226, 40);
            btnPostOrden.TabIndex = 10;
            btnPostOrden.Text = "Recorrido Post Orden";
            btnPostOrden.UseVisualStyleBackColor = false;
            btnPostOrden.Click += btnPostOrden_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(743, 53);
            label1.Name = "label1";
            label1.Size = new Size(216, 19);
            label1.TabIndex = 12;
            label1.Text = "Ingrese un dato numerico:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(665, 566);
            label2.Name = "label2";
            label2.Size = new Size(361, 19);
            label2.TabIndex = 13;
            label2.Text = "Rene Gerardo Castillo Monterrosa CM210922";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1029, 1055);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bsalir);
            Controls.Add(btnPostOrden);
            Controls.Add(btnPreOrden);
            Controls.Add(btnEnOrden);
            Controls.Add(labelRecorridos);
            Controls.Add(btneliminar);
            Controls.Add(btnBuscar);
            Controls.Add(btnIngresar);
            Controls.Add(labelAltura);
            Controls.Add(lblaltura);
            Controls.Add(valor);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Árbol AVL - Visualizador con Recorridos";
            Load += Form1_Load;
            Paint += Form1_Paint;
            ((System.ComponentModel.ISupportInitialize)errores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        public Label label1;
        public Label label2;
    }
}