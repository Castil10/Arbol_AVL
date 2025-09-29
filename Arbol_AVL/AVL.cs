using System.Collections.Generic;
using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Arbol_AVL
{
    class AVL
    {
        public int valor;
        public AVL NodoIzquierdo;
        public AVL NodoDerecho;
        public AVL NodoPadre;
        public int altura;
        public Rectangle prueba;
        private DibujaAVL arbol;

        // Nueva propiedad para el factor de balanceo
        public int FactorBalanceo { get; private set; }

        public AVL() { }

        public DibujaAVL Arbol
        {
            get { return arbol; }
            set { arbol = value; }
        }

        // Constructor
        public AVL(int valorNuevo, AVL izquierdo, AVL derecho, AVL padre)
        {
            valor = valorNuevo;
            NodoIzquierdo = izquierdo;
            NodoDerecho = derecho;
            NodoPadre = padre;
            altura = 0;
            FactorBalanceo = 0;
        }

        public AVL Insertar(int valorNuevo, AVL Raiz)
        {
            //Funcion para insertar un nuevo valor dentro del arbol AVL
            if (Raiz == null)
            {
                Raiz = new AVL(valorNuevo, null, null, null);
            }
            else if (valorNuevo < Raiz.valor)
            {
                Raiz.NodoIzquierdo = Insertar(valorNuevo, Raiz.NodoIzquierdo);
            }
            else if (valorNuevo > Raiz.valor)
            {
                Raiz.NodoDerecho = Insertar(valorNuevo, Raiz.NodoDerecho);
            }
            else
            {
                MessageBox.Show("Valor Existente en el Arbol", "Error", MessageBoxButtons.OK);
                return Raiz;
            }

            // Actualizar la altura
            Raiz.altura = max(Alturas(Raiz.NodoIzquierdo), Alturas(Raiz.NodoDerecho)) + 1;

            // Calcular el factor de balanceo
            Raiz.FactorBalanceo = Alturas(Raiz.NodoIzquierdo) - Alturas(Raiz.NodoDerecho);

            string tipoRotacion = "";

            //Realiza las rotaciones simples o dobles segun el caso
            if (Raiz.FactorBalanceo == 2)
            {
                if (valorNuevo < Raiz.NodoIzquierdo.valor)
                {
                    tipoRotacion = "RSI"; // Rotación Simple a la Izquierda
                    Raiz = RotacionIzquierdaSimple(Raiz);
                }
                else
                {
                    tipoRotacion = "RDI"; // Rotación Doble a la Izquierda
                    Raiz = RotacionIzquierdaDoble(Raiz);
                }
                MessageBox.Show($"Se realizó rotación: {tipoRotacion}", "Rotación AVL");
            }

            if (Raiz.FactorBalanceo == -2)
            {
                if (valorNuevo > Raiz.NodoDerecho.valor)
                {
                    tipoRotacion = "RSD"; // Rotación Simple Derecha
                    Raiz = RotacionDerechaSimple(Raiz);
                }
                else
                {
                    tipoRotacion = "RDD"; // Rotación Doble Derecha
                    Raiz = RotacionDerechaDoble(Raiz);
                }
                MessageBox.Show($"Se realizó rotación: {tipoRotacion}", "Rotación AVL");
            }

            return Raiz;
        }

        //FUNCION DE PRUEBA PARA REALIZAR LAS ROTACIONES
        //Funcion para obtener que rama es mayor
        private static int max(int lhs, int rhs)
        {
            return lhs > rhs ? lhs : rhs;
        }

        private static int Alturas(AVL Raiz)
        {
            return Raiz == null ? -1 : Raiz.altura;
        }

        AVL nodoE, nodoP;

        public AVL Eliminar(int valorEliminar, ref AVL Raiz)
        {
            if (Raiz != null)
            {
                if (valorEliminar < Raiz.valor)
                {
                    nodoE = Raiz;
                    Eliminar(valorEliminar, ref Raiz.NodoIzquierdo);
                }
                else if (valorEliminar > Raiz.valor)
                {
                    nodoE = Raiz;
                    Eliminar(valorEliminar, ref Raiz.NodoDerecho);
                }
                else
                {
                    //Posicionado sobre el elemento a eliminar
                    AVL NodoEliminar = Raiz;
                    if (NodoEliminar.NodoDerecho == null)
                    {
                        Raiz = NodoEliminar.NodoIzquierdo;
                    }
                    else if (NodoEliminar.NodoIzquierdo == null)
                    {
                        Raiz = NodoEliminar.NodoDerecho;
                    }
                    else
                    {
                        // Nodo con dos hijos
                        AVL sucesor = EncontrarSucesor(Raiz.NodoDerecho);
                        Raiz.valor = sucesor.valor;
                        Raiz.NodoDerecho = Eliminar(sucesor.valor, ref Raiz.NodoDerecho);
                    }
                }

                if (Raiz != null)
                {
                    // Actualizar altura y factor de balanceo después de eliminar nodos
                    Raiz.altura = max(Alturas(Raiz.NodoIzquierdo), Alturas(Raiz.NodoDerecho)) + 1;
                    Raiz.FactorBalanceo = Alturas(Raiz.NodoIzquierdo) - Alturas(Raiz.NodoDerecho);

                    // Balancear después de eliminar
                    string tipoRotacion = "";
                    if (Raiz.FactorBalanceo == 2)
                    {
                        if (Alturas(Raiz.NodoIzquierdo.NodoIzquierdo) >= Alturas(Raiz.NodoIzquierdo.NodoDerecho))
                        {
                            tipoRotacion = "RSI";
                            Raiz = RotacionIzquierdaSimple(Raiz);
                        }
                        else
                        {
                            tipoRotacion = "RDI";
                            Raiz = RotacionIzquierdaDoble(Raiz);
                        }
                        if (!string.IsNullOrEmpty(tipoRotacion))
                            MessageBox.Show($"Se realizó rotación: {tipoRotacion}", "Rotación AVL");
                    }
                    else if (Raiz.FactorBalanceo == -2)
                    {
                        if (Alturas(Raiz.NodoDerecho.NodoDerecho) >= Alturas(Raiz.NodoDerecho.NodoIzquierdo))
                        {
                            tipoRotacion = "RSD";
                            Raiz = RotacionDerechaSimple(Raiz);
                        }
                        else
                        {
                            tipoRotacion = "RDD";
                            Raiz = RotacionDerechaDoble(Raiz);
                        }
                        if (!string.IsNullOrEmpty(tipoRotacion))
                            MessageBox.Show($"Se realizó rotación: {tipoRotacion}", "Rotación AVL");
                    }
                }
            }
            else
            {
                MessageBox.Show("Nodo inexistente en el arbol", "Error", MessageBoxButtons.OK);
            }
            return Raiz;
        }

        private AVL EncontrarSucesor(AVL nodo)
        {
            while (nodo.NodoIzquierdo != null)
            {
                nodo = nodo.NodoIzquierdo;
            }
            return nodo;
        }

        //Seccion de funciones de rotaciones

        //Rotacion Izquierda Simple
        private static AVL RotacionIzquierdaSimple(AVL k2)
        {
            AVL k1 = k2.NodoIzquierdo;
            k2.NodoIzquierdo = k1.NodoDerecho;
            k1.NodoDerecho = k2;

            k2.altura = max(Alturas(k2.NodoIzquierdo), Alturas(k2.NodoDerecho)) + 1;
            k1.altura = max(Alturas(k1.NodoIzquierdo), k2.altura) + 1;

            // Actualizar factores de balanceo
            k2.FactorBalanceo = Alturas(k2.NodoIzquierdo) - Alturas(k2.NodoDerecho);
            k1.FactorBalanceo = Alturas(k1.NodoIzquierdo) - Alturas(k1.NodoDerecho);

            return k1;
        }

        //Rotacion Derecha Simple
        private static AVL RotacionDerechaSimple(AVL k1)
        {
            AVL k2 = k1.NodoDerecho;
            k1.NodoDerecho = k2.NodoIzquierdo;
            k2.NodoIzquierdo = k1;

            k1.altura = max(Alturas(k1.NodoIzquierdo), Alturas(k1.NodoDerecho)) + 1;
            k2.altura = max(Alturas(k2.NodoDerecho), k1.altura) + 1;

            // Actualizar factores de balanceo
            k1.FactorBalanceo = Alturas(k1.NodoIzquierdo) - Alturas(k1.NodoDerecho);
            k2.FactorBalanceo = Alturas(k2.NodoIzquierdo) - Alturas(k2.NodoDerecho);

            return k2;
        }

        //Doble Rotacion Izquierda
        private static AVL RotacionIzquierdaDoble(AVL k3)
        {
            k3.NodoIzquierdo = RotacionDerechaSimple(k3.NodoIzquierdo);
            return RotacionIzquierdaSimple(k3);
        }

        //Doble Rotacion Derecha
        private static AVL RotacionDerechaDoble(AVL k1)
        {
            k1.NodoDerecho = RotacionIzquierdaSimple(k1.NodoDerecho);
            return RotacionDerechaSimple(k1);
        }

        //Funcion para obtener la altura del arbol
        public int getAltura(AVL nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(getAltura(nodoActual.NodoIzquierdo), getAltura(nodoActual.NodoDerecho));
            }
        }

        //Buscar un valor en el arbol
        public void buscar(int valorBuscar, AVL Raiz)
        {
            if (Raiz != null)
            {
                if (valorBuscar < Raiz.valor)
                {
                    buscar(valorBuscar, Raiz.NodoIzquierdo);
                }
                else if (valorBuscar > Raiz.valor)
                {
                    buscar(valorBuscar, Raiz.NodoDerecho);
                }
                else
                {
                    MessageBox.Show("Valor encontrado: " + valorBuscar, "Encontrado", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Valor no encontrado", "Error", MessageBoxButtons.OK);
            }
        }

        // Métodos para recorridos
        public string RecorridoEnOrden(AVL nodo)
        {
            if (nodo == null) return "";

            string resultado = "";
            resultado += RecorridoEnOrden(nodo.NodoIzquierdo);
            resultado += nodo.valor + " ";
            resultado += RecorridoEnOrden(nodo.NodoDerecho);

            return resultado;
        }

        public string RecorridoPreOrden(AVL nodo)
        {
            if (nodo == null) return "";

            string resultado = "";
            resultado += nodo.valor + " ";
            resultado += RecorridoPreOrden(nodo.NodoIzquierdo);
            resultado += RecorridoPreOrden(nodo.NodoDerecho);

            return resultado;
        }

        public string RecorridoPostOrden(AVL nodo)
        {
            if (nodo == null) return "";

            string resultado = "";
            resultado += RecorridoPostOrden(nodo.NodoIzquierdo);
            resultado += RecorridoPostOrden(nodo.NodoDerecho);
            resultado += nodo.valor + " ";

            return resultado;
        }

        //++++++FUNCIONES PARA DIBUJAR EL ARBOL +++++
        private const int Radio = 45; // Aumentado para mostrar más información
        private const int DistanciaH = 80;
        private const int DistanciaV = 100;
        private int CoordenadaX;
        private int CoordenadaY;

        //Encuentra la posición en donde debe crearse el nodo.
        public void PosicionNodo(ref int xmin, int ymin)
        {
            int aux1, aux2;
            CoordenadaY = (int)(ymin + Radio / 2);

            //obtiene la posicion del Sub-Arbol izquierdo.
            if (NodoIzquierdo != null)
            {
                NodoIzquierdo.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }

            if ((NodoIzquierdo != null) && (NodoDerecho != null))
            {
                xmin += DistanciaH;
            }

            //Si existe el nodo derecho e izquierdo deja un espacio entre ellos.
            if (NodoDerecho != null)
            {
                NodoDerecho.PosicionNodo(ref xmin, ymin + Radio + DistanciaV);
            }

            // Posicion de nodos dercho e izquierdo.
            if (NodoIzquierdo != null)
            {
                if (NodoDerecho != null)
                {
                    //centro entre los nodos.
                    CoordenadaX = (int)((NodoIzquierdo.CoordenadaX + NodoDerecho.CoordenadaX) / 2);
                }
                else
                {
                    // no hay nodo derecho. centrar al nodo izquierdo.
                    aux1 = NodoIzquierdo.CoordenadaX;
                    NodoIzquierdo.CoordenadaX = CoordenadaX - 40;
                    CoordenadaX = aux1;
                }
            }
            else if (NodoDerecho != null)
            {
                aux2 = NodoDerecho.CoordenadaX;
                //no hay nodo izquierdo.centrar al nodo derecho.
                NodoDerecho.CoordenadaX = CoordenadaX + 40;
                CoordenadaX = aux2;
            }
            else
            {
                // Nodo hoja
                CoordenadaX = (int)(xmin + Radio / 2);
                xmin += Radio;
            }
        }

        // Dibuja las ramas de los nodos izquierdo y derecho
        public void DibujarRamas(Graphics grafo, Pen Lapiz)
        {
            if (NodoIzquierdo != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, NodoIzquierdo.CoordenadaX, NodoIzquierdo.CoordenadaY);
                NodoIzquierdo.DibujarRamas(grafo, Lapiz);
            }

            if (NodoDerecho != null)
            {
                grafo.DrawLine(Lapiz, CoordenadaX, CoordenadaY, NodoDerecho.CoordenadaX, NodoDerecho.CoordenadaY);
                NodoDerecho.DibujarRamas(grafo, Lapiz);
            }
        }
        public void colorear(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz)
        {
            //Dibuja el contorno del nodo.
            Rectangle rect = new Rectangle(
                (int)(CoordenadaX - Radio / 2),
                (int)(CoordenadaY - Radio / 2),
                Radio, Radio);

            prueba = new Rectangle(
                (int)(CoordenadaX - Radio / 2),
                (int)(CoordenadaY - Radio / 2),
                Radio, Radio);

            //Dibuja el nombre.
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;

            grafo.DrawEllipse(Lapiz, rect);
            grafo.FillEllipse(Brushes.PaleVioletRed, rect);

            // Dibujar valor y factor de balanceo
            grafo.DrawString(valor.ToString(), new Font(fuente, FontStyle.Bold), Brushes.Black, CoordenadaX, CoordenadaY - 8, formato);
            grafo.DrawString($"FB: {FactorBalanceo}", new Font(fuente, FontStyle.Regular), Brushes.DarkBlue, CoordenadaX, CoordenadaY + 8, formato);
        }

        //Dibuja el nodo en la posicion especificada.
        public void DibujarNodo(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, int dato, Brush encuentro)
        {
            //Dibuja el contorno del nodo.
            Rectangle rect = new Rectangle(
                (int)(CoordenadaX - Radio / 2),
                (int)(CoordenadaY - Radio / 2),
                Radio, Radio);

            if (valor == dato)
            {
                grafo.FillEllipse(encuentro, rect);
            }
            else
            {
                grafo.FillEllipse(Relleno, rect);
            }

            grafo.DrawEllipse(Lapiz, rect);

            //Dibuja el valor del nodo y el factor de balanceo
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Center;

            // Dibujar valor del nodo
            grafo.DrawString(valor.ToString(), new Font(fuente, FontStyle.Bold), Brushes.Black, CoordenadaX, CoordenadaY - 8, formato);

            // Dibujar factor de balanceo
            grafo.DrawString($"FB: {FactorBalanceo}", new Font(fuente, FontStyle.Regular), Brushes.DarkBlue, CoordenadaX, CoordenadaY + 8, formato);

            //Dibuja los nodos hijos derecho e izquierdo.
            if (NodoIzquierdo != null)
            {
                NodoIzquierdo.DibujarNodo(grafo, fuente, Brushes.YellowGreen, RellenoFuente, Lapiz, dato, encuentro);
            }

            if (NodoDerecho != null)
            {
                NodoDerecho.DibujarNodo(grafo, fuente, Brushes.Yellow, RellenoFuente, Lapiz, dato, encuentro);
            }
        }

        
    }
}