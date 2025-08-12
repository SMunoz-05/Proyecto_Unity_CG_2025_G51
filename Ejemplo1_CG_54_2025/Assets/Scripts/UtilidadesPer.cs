using System;
using UnityEngine;
using System.Collections.Generic;
using packagePersona;
using System.IO;

public class UtilidadesPer
{
    public static bool SaveDataStudent(List<Estudiante> listaE)
    {
        //bool resultado = false;
        try
        {

            string jsonString = JsonUtility.ToJson(listaE, true);
            Debug.Log("Lista JSON: " + jsonString);
            string directoryPath = Application.streamingAssetsPath;

            string filePath = Path.Combine(directoryPath, "dataSaveStudent.json");
            File.WriteAllText(filePath, jsonString);
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error al guardar JSON: " + ex.Message);
            return false;
        }

        //return resultado;
    }

    [Serializable]
    public class ListaEstudiantes
    {
        public List<Estudiante> estudiantes;
    }
}
   
