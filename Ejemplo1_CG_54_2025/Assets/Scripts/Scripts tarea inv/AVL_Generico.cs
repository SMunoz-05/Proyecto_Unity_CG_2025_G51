using UnityEngine;
using System;

// Nodo para árbol AVL con altura almacenada
public class NodoAVL<T> where T : IComparable<T>
{
    public T Valor;
    public NodoAVL<T> Izquierdo;
    public NodoAVL<T> Derecho;
    public int Altura;  // Altura del nodo para balanceo

    public NodoAVL(T valor)
    {
        Valor = valor;
        Altura = 1;  // Altura inicial al crear nodo es 1 (hoja)
    }
}

// Clase árbol AVL auto-balanceado genérico
public class ArbolAVL<T> where T : IComparable<T>
{
    public NodoAVL<T> Raiz;

    // Obtener altura segura del nodo (0 si es nulo)
    public int Altura(NodoAVL<T> nodo)
    {
        return nodo == null ? 0 : nodo.Altura;
    }

    // Calcular balance = altura(subárbol izquierdo) - altura(subárbol derecho)
    public int ObtenerBalance(NodoAVL<T> nodo)
    {
        return nodo == null ? 0 : Altura(nodo.Izquierdo) - Altura(nodo.Derecho);
    }

    // Rotación simple derecha para rebalancear
    public NodoAVL<T> RotacionDerecha(NodoAVL<T> y)
    {
        NodoAVL<T> x = y.Izquierdo;
        NodoAVL<T> T2 = x.Derecho;

        x.Derecho = y;
        y.Izquierdo = T2;

        // Actualizar alturas después de rotación
        y.Altura = Math.Max(Altura(y.Izquierdo), Altura(y.Derecho)) + 1;
        x.Altura = Math.Max(Altura(x.Izquierdo), Altura(x.Derecho)) + 1;

        return x; // Nueva raíz después de rotación
    }

    // Rotación simple izquierda para rebalancear
    public NodoAVL<T> RotacionIzquierda(NodoAVL<T> x)
    {
        NodoAVL<T> y = x.Derecho;
        NodoAVL<T> T2 = y.Izquierdo;

        y.Izquierdo = x;
        x.Derecho = T2;

        // Actualizar alturas después de rotación
        x.Altura = Math.Max(Altura(x.Izquierdo), Altura(x.Derecho)) + 1;
        y.Altura = Math.Max(Altura(y.Izquierdo), Altura(y.Derecho)) + 1;

        return y; // Nueva raíz después de rotación
    }

    // Insertar valor en árbol AVL y mantener balance
    public NodoAVL<T> Insertar(NodoAVL<T> nodo, T valor)
    {
        if (nodo == null)
            return new NodoAVL<T>(valor);

        int comparacion = valor.CompareTo(nodo.Valor);
        if (comparacion < 0)
            nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
        else if (comparacion > 0)
            nodo.Derecho = Insertar(nodo.Derecho, valor);
        else
            return nodo;  // sin duplicados

        // Actualizar altura del nodo actual
        nodo.Altura = 1 + Math.Max(Altura(nodo.Izquierdo), Altura(nodo.Derecho));

        int balance = ObtenerBalance(nodo);

        // Casos de desbalance y rotaciones correspondientes:

        // Caso izquierdo izquierdo
        if (balance > 1 && valor.CompareTo(nodo.Izquierdo.Valor) < 0)
            return RotacionDerecha(nodo);

        // Caso derecho derecho
        if (balance < -1 && valor.CompareTo(nodo.Derecho.Valor) > 0)
            return RotacionIzquierda(nodo);

        // Caso izquierdo derecho
        if (balance > 1 && valor.CompareTo(nodo.Izquierdo.Valor) > 0)
        {
            nodo.Izquierdo = RotacionIzquierda(nodo.Izquierdo);
            return RotacionDerecha(nodo);
        }

        // Caso derecho izquierdo
        if (balance < -1 && valor.CompareTo(nodo.Derecho.Valor) < 0)
        {
            nodo.Derecho = RotacionDerecha(nodo.Derecho);
            return RotacionIzquierda(nodo);
        }

        return nodo;  // retorno el nodo actual actualizado
    }

    // Método público para insertar desde fuera de la clase
    public void Insertar(T valor)
    {
        Raiz = Insertar(Raiz, valor);
    }

    // Recorrido Inorden para mostrar valores ordenados
    public void InOrden()
    {
        InOrdenRec(Raiz);
        Console.WriteLine();
    }

    private void InOrdenRec(NodoAVL<T> nodo)
    {
        if (nodo != null)
        {
            InOrdenRec(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InOrdenRec(nodo.Derecho);
        }
    }
}
