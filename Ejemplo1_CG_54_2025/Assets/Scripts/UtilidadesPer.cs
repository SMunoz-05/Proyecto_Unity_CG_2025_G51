using System.IO;
using UnityEngine;
using System.Collections.Generic;
using packagePersona;

public class UtilidadesPer
{
    public static bool SaveDataStudent(List<Estudiante> listaE)
    {
        bool resultado = false;
        try
        {
            ListaEstudiantes le = new ListaEstudiantes();
            le.estudiantes = listaE;

            string jsonString = JsonUtility.ToJson(le, true);
            Debug.Log("Lista JSON: " + jsonString);

            string path = Path.Combine(Application.streamingAssetsPath, "estudiantes.json");
            File.WriteAllText(path, jsonString);

            resultado = true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al guardar JSON: " + ex.Message);
        }

        return resultado;
    }

    [System.Serializable]
    private class ListaEstudiantes
    {
        public List<Estudiante> estudiantes;
    }
}

