using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColaManager : MonoBehaviour
{
    [Header("Entradas de texto")]
    public TMP_InputField inputNombre;
    public TMP_InputField inputEmail;
    public TMP_InputField inputDireccion;

    [Header("Textos de salida")]
    public TMP_Text textCola;
    public TMP_Text textMensajes;

    private Queue<Persona> cola = new Queue<Persona>();

    private class Persona
    {
        public string Nombre { get; }
        public string Email { get; }
        public string Direccion { get; }

        public Persona(string nombre, string email, string direccion)
        {
            Nombre = nombre;
            Email = email;
            Direccion = direccion;
        }

        public override string ToString()
        {
            return $"{Nombre} - {Email} - {Direccion}";
        }
    }


    private Persona CrearPersona()
    {
        if (string.IsNullOrWhiteSpace(inputNombre.text) ||
            string.IsNullOrWhiteSpace(inputEmail.text) ||
            string.IsNullOrWhiteSpace(inputDireccion.text))
        {
            return null;
        }

        return new Persona(
            inputNombre.text.Trim(),
            inputEmail.text.Trim(),
            inputDireccion.text.Trim()
        );
    }

    private void ActualizarTextoCola()
    {
        if (cola.Count == 0)
        {
            textCola.text = "Cola vacía.";
            return;
        }

        textCola.text = "Cola:\n" + string.Join("\n", cola);
    }

    private void MostrarMensaje(string mensaje)
    {
        textMensajes.text = mensaje;
    }


    public void Enqueue()
    {
        Persona p = CrearPersona();
        if (p == null)
        {
            MostrarMensaje("Complete todos los campos.");
            return;
        }

        cola.Enqueue(p);
        MostrarMensaje($"{p.Nombre} agregado a la cola.");
        ActualizarTextoCola();
    }

    public void Dequeue()
    {
        if (cola.Count == 0)
        {
            MostrarMensaje("La cola está vacía.");
            return;
        }

        Persona p = cola.Dequeue();
        MostrarMensaje($"{p.Nombre} salió de la cola.");
        ActualizarTextoCola();
    }

    public void Peek()
    {
        if (cola.Count == 0)
        {
            MostrarMensaje("La cola está vacía.");
            return;
        }

        Persona p = cola.Peek();
        MostrarMensaje($"Primero en la cola: {p.Nombre}.");
    }

    public void Clear()
    {
        cola.Clear();
        MostrarMensaje(" Cola vaciada.");
        ActualizarTextoCola();
    }
}
