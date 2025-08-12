using UnityEngine;
using System;
using System.Collections.Generic; 
using packagePersona;  

public class Utilidades : MonoBehaviour
{
    [Serializable]
    public class ListaPuntos
    {
        public List<Punto2D> puntos;
    }

    [Serializable]
    public class ListaEstudiantes
    {
        public List<Estudiante> estudiantes;
    }

    public static string SerializarPuntos(List<Punto2D> lista)
    {
        ListaPuntos lp = new ListaPuntos();
        lp.puntos = lista;

        string json = JsonUtility.ToJson(lp, true);
        Debug.Log("JSON Puntos:\n" + json);
        return json;
    }

    public static string SerializarEstudiantes(List<Estudiante> lista)
    {
        ListaEstudiantes le = new ListaEstudiantes();
        le.estudiantes = lista;

        string json = JsonUtility.ToJson(le, true);
        Debug.Log("JSON Estudiantes:\n" + json);
        return json;
    }
}

