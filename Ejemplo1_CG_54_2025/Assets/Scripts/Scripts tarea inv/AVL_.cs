using System;

// Definición de nodo genérico para el árbol
public class Nodo<T> where T : IComparable<T>
{
    public T Valor;           // Valor almacenado en el nodo
    public Nodo<T> Izquierdo; // Referencia al hijo izquierdo
    public Nodo<T> Derecho;   // Referencia al hijo derecho

    public Nodo(T valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

// Clase árbol binario con datos genéricos
public class ArbolBinario<T> where T : IComparable<T>
{
    public Nodo<T> Raiz; // Nodo raíz del árbol

    public ArbolBinario()
    {
        Raiz = null; // Inicialmente árbol vacío
    }

    // Método público para insertar un valor en el árbol
    public void Insertar(T valor)
    {
        Raiz = InsertarRec(Raiz, valor);
    }

    // Método recursivo privado para insertar valor en subárbol
    private Nodo<T> InsertarRec(Nodo<T> nodo, T valor)
    {
        if (nodo == null)
        {
            // Si el nodo actual es nulo, crea y retorna nuevo nodo
            return new Nodo<T>(valor);
        }
        int comparacion = valor.CompareTo(nodo.Valor);
        if (comparacion < 0)
        {
            // Si valor es menor, inserta en subárbol izquierdo
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        }
        else if (comparacion > 0)
        {
            // Si valor es mayor, inserta en subárbol derecho
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);
        }
        // Si valor es igual, no inserta para evitar duplicados
        return nodo;
    }

    // Método público para recorrer el árbol en orden (izquierda-raíz-derecha)
    public void InOrden()
    {
        InOrdenRec(Raiz);
        Console.WriteLine();
    }

    // Método recursivo para recorrido inorden del árbol
    private void InOrdenRec(Nodo<T> nodo)
    {
        if (nodo != null)
        {
            InOrdenRec(nodo.Izquierdo);         // Recorrer subárbol izquierdo
            Console.Write(nodo.Valor + " ");     // Procesar nodo actual (mostrar valor)
            InOrdenRec(nodo.Derecho);            // Recorrer subárbol derecho
        }
    }
}
