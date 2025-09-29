using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Arbol_AVL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Configurar el formulario para mejor rendimiento gr�fico
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.BackColor = Color.White;
        }

        int cont = 0;
        int dato = 0;
        int datb = 0;
        int cont2 = 0;
        DibujaAVL arbolAVL = new DibujaAVL(null);
        Graphics g;
        int pintaR = 0;

        // Evento Paint para dibujar el �rbol en el �rea izquierda
        private void Form1_Paint(object sender, PaintEventArgs en)
        {
            // Limpiar solo el �rea de dibujo (lado izquierdo)
            en.Graphics.Clear(Color.White);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;

            // Dibujar el �rbol en el �rea izquierda (0-600px)
            if (arbolAVL.Raiz != null)
            {
                arbolAVL.DibujarArbol(g, new Font("Arial", 10, FontStyle.Bold),
                    Brushes.LightBlue, Brushes.Black, new Pen(Color.Black, 2),
                    datb, Brushes.Red);
            }
            else
            {
                // Mensaje cuando el �rbol est� vac�o
                en.Graphics.DrawString("�rbol Vac�o",
                    new Font("Arial", 16, FontStyle.Bold),
                    Brushes.Gray,
                    new PointF(250, 300));
            }

            datb = 0;

            if (pintaR == 1)
            {
                // L�gica de coloreado para recorridos (si la necesitas)
                // arbolAVL.colorear(g, this.Font, Brushes.Black, Brushes.Yellow, 
                //     Pens.Blue, arbolAVL.Raiz, false, false, false);
                pintaR = 0;
            }

            if (pintaR == 2)
            {
                arbolAVL.colorearB(g, this.Font, Brushes.White, Brushes.Red,
                    Pens.White, arbolAVL.Raiz, dato);
                pintaR = 0;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (string.IsNullOrEmpty(valor.Text))
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    arbolAVL.Insertar(dato);
                    valor.Clear();
                    valor.Focus();

                    if (arbolAVL.Raiz != null)
                        lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    else
                        lblaltura.Text = "0";

                    cont++;
                    this.Invalidate(new Rectangle(0, 0, 600, 600)); // Redibujar solo el �rea del �rbol
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser num�rico");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (string.IsNullOrEmpty(valor.Text))
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    datb = int.Parse(valor.Text);
                    arbolAVL.buscar(datb);
                    pintaR = 2;
                    this.Invalidate(new Rectangle(0, 0, 600, 600));
                    valor.Clear();
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser num�rico");
                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            errores.Clear();
            if (string.IsNullOrEmpty(valor.Text))
            {
                errores.SetError(valor, "Valor obligatorio");
            }
            else
            {
                try
                {
                    dato = int.Parse(valor.Text);
                    valor.Clear();
                    arbolAVL.Eliminar(dato);

                    if (arbolAVL.Raiz != null)
                        lblaltura.Text = arbolAVL.Raiz.getAltura(arbolAVL.Raiz).ToString();
                    else
                        lblaltura.Text = "0";

                    cont2++;
                    this.Invalidate(new Rectangle(0, 0, 600, 600));
                }
                catch (Exception ex)
                {
                    errores.SetError(valor, "Debe ser num�rico");
                }
            }
        }

        // NUEVOS M�TODOS PARA RECORRIDOS
        private void btnEnOrden_Click(object sender, EventArgs e)
        {
            if (arbolAVL.Raiz != null)
            {
                string recorrido = arbolAVL.RecorridoEnOrden();
                MessageBox.Show($"Recorrido En Orden:\n{recorrido}", "Recorrido En Orden",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El �rbol est� vac�o", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPreOrden_Click(object sender, EventArgs e)
        {
            if (arbolAVL.Raiz != null)
            {
                string recorrido = arbolAVL.RecorridoPreOrden();
                MessageBox.Show($"Recorrido Pre Orden:\n{recorrido}", "Recorrido Pre Orden",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El �rbol est� vac�o", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPostOrden_Click(object sender, EventArgs e)
        {
            if (arbolAVL.Raiz != null)
            {
                string recorrido = arbolAVL.RecorridoPostOrden();
                MessageBox.Show($"Recorrido Post Orden:\n{recorrido}", "Recorrido Post Orden",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El �rbol est� vac�o", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void valor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIngresar_Click(sender, e);
                e.Handled = true;
            }
        }

        private void bsalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void valor_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void labelAltura_Click(object sender, EventArgs e)
        {

        }

        private void lblaltura_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}