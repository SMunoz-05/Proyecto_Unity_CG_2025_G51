using System;

// Definici�n de nodo gen�rico para el �rbol
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

// Clase �rbol binario con datos gen�ricos
public class ArbolBinario<T> where T : IComparable<T>
{
    public Nodo<T> Raiz; // Nodo ra�z del �rbol

    public ArbolBinario()
    {
        Raiz = null; // Inicialmente �rbol vac�o
    }

    // M�todo p�blico para insertar un valor en el �rbol
    public void Insertar(T valor)
    {
        Raiz = InsertarRec(Raiz, valor);
    }

    // M�todo recursivo privado para insertar valor en sub�rbol
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
            // Si valor es menor, inserta en sub�rbol izquierdo
            nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        }
        else if (comparacion > 0)
        {
            // Si valor es mayor, inserta en sub�rbol derecho
            nodo.Derecho = InsertarRec(nodo.Derecho, valor);
        }
        // Si valor es igual, no inserta para evitar duplicados
        return nodo;
    }

    // M�todo p�blico para recorrer el �rbol en orden (izquierda-ra�z-derecha)
    public void InOrden()
    {
        InOrdenRec(Raiz);
        Console.WriteLine();
    }

    // M�todo recursivo para recorrido inorden del �rbol
    private void InOrdenRec(Nodo<T> nodo)
    {
        if (nodo != null)
        {
            InOrdenRec(nodo.Izquierdo);         // Recorrer sub�rbol izquierdo
            Console.Write(nodo.Valor + " ");     // Procesar nodo actual (mostrar valor)
            InOrdenRec(nodo.Derecho);            // Recorrer sub�rbol derecho
        }
    }
}
