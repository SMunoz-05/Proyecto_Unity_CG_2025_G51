using System;

// Definición colores para los nodos
public enum Color { Rojo, Negro }

// Nodo genérico para árbol Rojo-Negro
public class NodoRN<T> where T : IComparable<T>
{
    public T Valor;
    public Color Color;          // Color rojo o negro
    public NodoRN<T> Padre;
    public NodoRN<T> Izquierdo;
    public NodoRN<T> Derecho;

    public NodoRN(T valor)
    {
        Valor = valor;
        Color = Color.Rojo;      // Nuevo nodo siempre rojo inicialmente
        Padre = Izquierdo = Derecho = null;
    }
}

// Clase árbol Rojo-Negro balanceado
public class ArbolRojoNegro<T> where T : IComparable<T>
{
    private NodoRN<T> raiz;
    private NodoRN<T> nulo;    // Nodo nulo para hojas (sentinela)

    public ArbolRojoNegro()
    {
        nulo = new NodoRN<T>(default(T));
        nulo.Color = Color.Negro;
        raiz = nulo;
    }

    // Rotación a la izquierda para rebalanceo
    private void RotarIzquierda(NodoRN<T> x)
    {
        NodoRN<T> y = x.Derecho;
        x.Derecho = y.Izquierdo;
        if (y.Izquierdo != nulo)
            y.Izquierdo.Padre = x;
        y.Padre = x.Padre;
        if (x.Padre == null)
            raiz = y;
        else if (x == x.Padre.Izquierdo)
            x.Padre.Izquierdo = y;
        else
            x.Padre.Derecho = y;
        y.Izquierdo = x;
        x.Padre = y;
    }

    // Rotación a la derecha para rebalanceo
    private void RotarDerecha(NodoRN<T> y)
    {
        NodoRN<T> x = y.Izquierdo;
        y.Izquierdo = x.Derecho;
        if (x.Derecho != nulo)
            x.Derecho.Padre = y;
        x.Padre = y.Padre;
        if (y.Padre == null)
            raiz = x;
        else if (y == y.Padre.Derecho)
            y.Padre.Derecho = x;
        else
            y.Padre.Izquierdo = x;
        x.Derecho = y;
        y.Padre = x;
    }

    // Insertar valor en el árbol
    public void Insertar(T valor)
    {
        NodoRN<T> nuevo = new NodoRN<T>(valor);
        nuevo.Izquierdo = nuevo.Derecho = nulo;

        NodoRN<T> y = null;     // Nodo padre
        NodoRN<T> x = raiz;     // Nodo actual

        // Encontrar la posición para insertar
        while (x != nulo)
        {
            y = x;
            if (nuevo.Valor.CompareTo(x.Valor) < 0)
                x = x.Izquierdo;
            else
                x = x.Derecho;
        }

        nuevo.Padre = y;
        if (y == null)
            raiz = nuevo;       // Árbol vacío nuevo es raíz
        else if (nuevo.Valor.CompareTo(y.Valor) < 0)
            y.Izquierdo = nuevo;
        else
            y.Derecho = nuevo;

        if (nuevo.Padre == null)
        {
            nuevo.Color = Color.Negro;   // La raíz es negra
            return;
        }

        if (nuevo.Padre.Padre == null)
            return;

        InsertarFix(nuevo); // Ajustar colores y rotaciones para balancear
    }

    // Ajustar el árbol después de insertar un nodo rojo
    private void InsertarFix(NodoRN<T> k)
    {
        NodoRN<T> u;
        while (k.Padre.Color == Color.Rojo)
        {
            // Caso cuando el padre es hijo izquierdo
            if (k.Padre == k.Padre.Padre.Izquierdo)
            {
                u = k.Padre.Padre.Derecho; // Tío
                if (u.Color == Color.Rojo)
                {
                    // Caso 1: recolorear
                    u.Color = Color.Negro;
                    k.Padre.Color = Color.Negro;
                    k.Padre.Padre.Color = Color.Rojo;
                    k = k.Padre.Padre;
                }
                else
                {
                    // Caso 2 y 3: rotaciones
                    if (k == k.Padre.Derecho)
                    {
                        k = k.Padre;
                        RotarIzquierda(k);
                    }
                    k.Padre.Color = Color.Negro;
                    k.Padre.Padre.Color = Color.Rojo;
                    RotarDerecha(k.Padre.Padre);
                }
            }
            else
            {
                // Caso cuando el padre es hijo derecho (simétrico)
                u = k.Padre.Padre.Izquierdo;
                if (u.Color == Color.Rojo)
                {
                    u.Color = Color.Negro;
                    k.Padre.Color = Color.Negro;
                    k.Padre.Padre.Color = Color.Rojo;
                    k = k.Padre.Padre;
                }
                else
                {
                    if (k == k.Padre.Izquierdo)
                    {
                        k = k.Padre;
                        RotarDerecha(k);
                    }
                    k.Padre.Color = Color.Negro;
                    k.Padre.Padre.Color = Color.Rojo;
                    RotarIzquierda(k.Padre.Padre);
                }
            }
            if (k == raiz) break;
        }
        raiz.Color = Color.Negro; // La raíz siempre negra al final
    }

    // Recorrido inorden para imprimir valores con colores
    public void InOrden()
    {
        InOrdenRec(raiz);
        Console.WriteLine();
    }

    private void InOrdenRec(NodoRN<T> nodo)
    {
        if (nodo != nulo)
        {
            InOrdenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + (nodo.Color == Color.Rojo ? "(R) " : "(N) "));
            InOrdenRec(nodo.Derecho);
        }
    }
}
