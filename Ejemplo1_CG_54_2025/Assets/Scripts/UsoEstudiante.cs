using UnityEngine;
using System;
using packagePersona;
using System.Collections.Generic;
using TMPro;
using System.IO;
public class UsoEstudiante : MonoBehaviour
{
    List<Estudiante> listaE = new List<Estudiante>();
    public TMP_InputField nameStudent;
    public TMP_InputField mailStudent;
    public TMP_InputField dirStudent;
    public TMP_InputField codeStudent;
    public TMP_InputField carreraStudent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        LoadDataEstudiantes();
    }

    // Update is called once per frame
    public void Update()
    {
    }

    public void LoadDataEstudiantes()
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "Estudiantes.txt");
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
                    Estudiante e = new Estudiante(lineaEstudiante[3], lineaEstudiante[4], lineaEstudiante[0], lineaEstudiante[1], lineaEstudiante[2]);

                    Debug.Log("Persona leída " + e.NameP + " " + e.NameCarreraE);
                    listaE.Add(e);
                }

            }
            catch
            {
                Debug.LogError("Error al leer el archivo: ");
            }

        }
        else
        {
            Debug.LogError("El archivo no existe en: " + filePath);
        }

    }


    public void AddStudentList()
    {
        string nameStudent1 = nameStudent.text;
        string mailStudent1 = mailStudent.text;
        string dirStudent1 = dirStudent.text;
        string codeStudent1 = codeStudent.text;
        string carreraStudent1 = carreraStudent.text;

        Estudiante e1 = new Estudiante(codeStudent1, carreraStudent1, nameStudent1, mailStudent1, dirStudent1);

        listaE.Add(e1);
    }

    public void ShowStudentList()
    {
        for (int i = 0; i < listaE.Count; i++)
        {
            Debug.Log(listaE[i].NameP + "Carrera" + listaE[i].NameCarreraE);
        }

        UtilidadesPer.SaveDataStudent(listaE);
    }
    public void SaveDataStudent()
    {
        UtilidadesPer.SaveDataStudent(listaE);
    }
}
