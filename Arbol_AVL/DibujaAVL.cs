using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Arbol_AVL
{
    class DibujaAVL
    {
        public AVL Raiz;
        public AVL aux;

        // Constructor.
        public DibujaAVL()
        {
            aux = new AVL();
        }

        public DibujaAVL(AVL RaizNueva)
        {
            Raiz = RaizNueva;
        }

        // Agrega un nuevo valor al arbol.
        public void Insertar(int dato)
        {
            if (Raiz == null)
            {
                Raiz = new AVL(dato, null, null, null);
            }
            else
            {
                Raiz = Raiz.Insertar(dato, Raiz);
            }
        }

        //Eliminar un valor del arbol
        public void Eliminar(int dato)
        {
            if (Raiz == null)
            {
                MessageBox.Show("Árbol vacío", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Raiz.Eliminar(dato, ref Raiz);
            }
        }

        private const int Radio = 160;
        private const int DistanciaH = 60;
        private const int DistanciaV = 80;
        private int CoordenadaX;
        private int CoordenadaY;

        public void PosicionNodoRecorrido(ref int xmin, ref int ymin)
        {
            CoordenadaY = (int)(ymin + Radio / 2);
            CoordenadaX = (int)(xmin + Radio / 2);
            xmin += Radio;
            ymin += DistanciaV;
        }

        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, AVL Raiz, bool post, bool inor, bool preor)
        {
            Brush entorno = Brushes.Red;
            if (inor == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Brushes.Blue, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(500);
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, post, inor, preor);
                }
            }
            else if (preor == true)
            {
                if (Raiz != null)
                {
                    Raiz.colorear(grafo, fuente, Brushes.Yellow, Brushes.Blue, Lapiz);
                    Thread.Sleep(500);
                    Raiz.colorear(grafo, fuente, Brushes.White, Brushes.Black, Lapiz);
                    colorear(grafo, fuente, Brushes.Blue, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, post, inor, preor);
                }
            }
            else if (post == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(500);
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                }
            }
        }

        public void colorearB(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, AVL Raiz, int busqueda)
        {
            Brush entorno = Brushes.Red;
            if (Raiz != null)
            {
                Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);

                if (busqueda < Raiz.valor)
                {
                    Thread.Sleep(500);
                    Raiz.colorear(grafo, fuente, entorno, Brushes.Blue, Lapiz);
                    colorearB(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoIzquierdo, busqueda);
                }
                else if (busqueda > Raiz.valor)
                {
                    Thread.Sleep(500);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    colorearB(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.NodoDerecho, busqueda);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(500);
                }
                else
                {
                    // Valor encontrado
                    Raiz.colorear(grafo, fuente, Brushes.Green, RellenoFuente, Lapiz);
                }
            }
        }

        //Dibuja el árbol
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, int dato, Brush encuentro)
        {
            int x = 100;
            int y = 75;
            if (Raiz == null)
                return;

            //Posicion de todos los Nodos.
            Raiz.PosicionNodo(ref x, y);

            //Dibuja los Enlaces entre nodos
            Raiz.DibujarRamas(grafo, Lapiz);

            //Dibuja todos los Nodos.
            Raiz.DibujarNodo(grafo, fuente, Relleno, RellenoFuente, Lapiz, dato, encuentro);
        }

        public int x1 = 100;
        public int y2 = 75;

        public void restablecer_valores()
        {
            x1 = 100;
            y2 = 75;
        }

        public void buscar(int x)
        {
            if (Raiz == null)
            {
                MessageBox.Show("Arbol AVL Vacio", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Raiz.buscar(x, Raiz);
            }
        }

        // Métodos para los recorridos
        public string RecorridoEnOrden()
        {
            if (Raiz == null) return "Árbol vacío";
            return Raiz.RecorridoEnOrden(Raiz);
        }

        public string RecorridoPreOrden()
        {
            if (Raiz == null) return "Árbol vacío";
            return Raiz.RecorridoPreOrden(Raiz);
        }

        public string RecorridoPostOrden()
        {
            if (Raiz == null) return "Árbol vacío";
            return Raiz.RecorridoPostOrden(Raiz);
        }
    }
}