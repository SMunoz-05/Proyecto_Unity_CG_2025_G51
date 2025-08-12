using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Punto2D
{
    public float x;
    public float y;
}

[System.Serializable]
public class PuntosWrapper
{
    public List<Punto2D> puntos;
}

public class EjemploCarga : MonoBehaviour
{
    public string jsonString;

    void Start()
    {
        PuntosWrapper wrapper = JsonUtility.FromJson<PuntosWrapper>(jsonString);

        List<Punto2D> listaDePuntos = new List<Punto2D>();

        if (wrapper != null && wrapper.puntos != null)
        {
            foreach (Punto2D p in wrapper.puntos)
            {
                listaDePuntos.Add(p);
                Debug.Log($"Punto: x={p.x}, y={p.y}");
            }
        }
        else
        {
            Debug.LogError("No se pudo parsear el JSON o no hay puntos.");
        }
    }
}
