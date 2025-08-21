using PackagePersona;
using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class UsarPersona : MonoBehaviour
{

    List<Estudiante> listaE = new List<Estudiante>();
    List<Estudiante> listaEIngenieria = new List<Estudiante>();
    public TMP_InputField nameStudent;
    public TMP_InputField mailStudent;
    public TMP_InputField dirStudent;
    public TMP_InputField CodeStudent;
    public TMP_InputField carreraStudent;
    public TMP_InputField positionInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

        loadDataEstudiantes();
        loadDataEstudiantesIng();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void loadDataEstudiantes()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Estudiantes.txt");
        string fileContent = "";

        if (File.Exists(filePath))
        {
            try
            {
                fileContent = File.ReadAllText(filePath);
                Debug.Log("Contenido del archivo: " + fileContent);
               
                StringReader reader = new StringReader(fileContent);
                
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                                      
                    string[] lineaEstudiante = line.Split(",");
                    Estudiante e = new Estudiante(lineaEstudiante[3], lineaEstudiante[4],
                        lineaEstudiante[0], lineaEstudiante[1], lineaEstudiante[2]);

                    Debug.Log("Persona leida "+e.NameP+" "+e.NameCarrera);
                    listaE.Add(e);
                    
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error al leer el archivo: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("El archivo no existe en: " + filePath);
        }
    }
    public void AddStudentAtPositionInput()
    {
        int position = -1;
        if (string.IsNullOrEmpty(positionInput.text) || !int.TryParse(positionInput.text, out position))
        {
            Debug.LogWarning("No se ingresó posición válida. Se agregará al final.");
            position = -1;
        }

        string nameStudent1 = nameStudent.text;
        string mailStudent1 = mailStudent.text;
        string dirStudent1 = dirStudent.text;
        string codeStudent1 = CodeStudent.text;
        string carreraS1 = carreraStudent.text;

        Estudiante e1 = new Estudiante(codeStudent1, carreraS1, nameStudent1, mailStudent1, dirStudent1);

        string carreraNormalized = carreraS1.Trim().ToLower();
        Debug.Log($"Carrera ingresada: '{carreraS1}' (normalizada: '{carreraNormalized}')");

        if (position < 0 || position > listaE.Count)
            listaE.Add(e1);
        else
            listaE.Insert(position, e1);

        if (carreraNormalized.Contains("ingenieria"))
        {
            if (position < 0 || position > listaEIngenieria.Count)
                listaEIngenieria.Add(e1);
            else
                listaEIngenieria.Insert(position, e1);

            Debug.Log($"Estudiante {e1.NameP} agregado a listas General y Ingeniería");
        }
        else
        {
            Debug.Log($"Estudiante {e1.NameP} agregado solo a lista General");
        }

        SaveBothLists();
    }

    public void SaveBothLists()
    {
        bool savedGeneral = Utilidades.SaveDataStudent(listaE);
        bool savedIngenieria = Utilidades.SaveDataStudentIngenieria(listaEIngenieria);

        if (savedGeneral && savedIngenieria)
            Debug.Log("Ambas listas guardadas correctamente.");
        else
            Debug.LogError("Error al guardar una o ambas listas.");
    }



    public void AddStudentList()
    {
        string nameStudent1 = nameStudent.text;
        string mailStudent1 = mailStudent.text;
        string dirStudent1 = dirStudent.text;
        string codeStudent1 = CodeStudent.text;
        string carreraS1 = carreraStudent.text;

        Estudiante e1 = new Estudiante(codeStudent1, carreraS1, nameStudent1, mailStudent1, dirStudent1);

        string carreraNormalized = carreraS1.Trim().ToLower();

        if (carreraNormalized.Contains("ingenieria"))
        {
            listaEIngenieria.Add(e1);
        }
        else
        {
            listaE.Add(e1);
        }

        SaveBothLists();
    }

    public void loadDataEstudiantesIng()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Estudiantes.txt");
        if (File.Exists(filePath))
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                Debug.Log("Contenido del archivo para SOLO Ingenieria: " + fileContent);
                StringReader reader = new StringReader(fileContent);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lineaEstudiante = line.Split(",");
                    Estudiante e = new Estudiante(lineaEstudiante[3], lineaEstudiante[4], lineaEstudiante[0], lineaEstudiante[1], lineaEstudiante[2]);
                    Debug.Log($"Estudiante leído: {e.NameP} - Carrera: '{e.NameCarrera}'");

                    if (e.NameCarrera.IndexOf("Ingenieria", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Debug.Log("Estudiante Ingenieria añadido: " + e.NameP);
                        listaEIngenieria.Add(e);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error al leer el archivo para Ingenieria: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("El archivo no existe en: " + filePath);
        }
    }


    public void ShowStudentList()
    {
        for (int i = 0; i < listaE.Count; i++)
        {
            Debug.Log(listaE[i].NameP + " " + listaE[i].NameCarrera);
        }

        Utilidades.SaveDataStudent(listaE);
    }
    public void ShowStudentListIng()
    {
        for (int i = 0; i < listaEIngenieria.Count; i++)
        {
            Debug.Log(listaEIngenieria[i].NameP + " " + listaEIngenieria[i].NameCarrera);
        }
        Utilidades.SaveDataStudentIngenieria(listaEIngenieria); 
    }
}


