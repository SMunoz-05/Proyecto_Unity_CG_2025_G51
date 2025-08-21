using UnityEngine;
using TMPro; 
using System.Collections.Generic;

public class PilaTextos : MonoBehaviour
{
    Stack<string> PilaNombres = new Stack<string>();

    public TMP_InputField inputNombre;  
    public TMP_Text textoAccion;        
    public TMP_Text textoContenido;

    public void pushString()
    {
        if (string.IsNullOrWhiteSpace(inputNombre.text))
        {
            if (PilaNombres.Count > 0)
            {
                textoAccion.text = "No agregaste nada, el tope sigue siendo: " + PilaNombres.Peek();
            }
            else
            {
                textoAccion.text = "No agregaste nada y la pila está vacía.";
            }
        }
        else
        {
            PilaNombres.Push(inputNombre.text);
            textoAccion.text = "Push: agregado " + inputNombre.text;
            inputNombre.text = "";
        }

        ActualizarContenido();
    }


    public void PeekString()
    {
        if (PilaNombres.Count > 0)
            textoAccion.text = "Peek: " + PilaNombres.Peek();
        else
            textoAccion.text = "Peek: pila vacia";
        ActualizarContenido();
    }

    public void PopString()
    {
        if (PilaNombres.Count > 0)
            textoAccion.text = "Pop: " + PilaNombres.Pop();
        else
            textoAccion.text = "Pop: pila vacia";
        ActualizarContenido();
    }

    public void ClearString()
    {
        PilaNombres.Clear();
        textoAccion.text = "Clear: pila vacia";
        ActualizarContenido();
    }

    void ActualizarContenido()
    {
        textoContenido.text = "Contenido:\n" + string.Join("\n", PilaNombres.ToArray());
    }

}
