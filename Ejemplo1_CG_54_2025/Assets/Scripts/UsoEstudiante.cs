using UnityEngine;
using System;
using packagePersona;
using System.Collections.Generic;
using TMPro;
public class UsoEstudiante : MonoBehaviour
{
    List<Estudiante> ListaE = new List<Estudiante>();
    public TMP_InputField nameStudent;
    public TMP_InputField mailStudent;
    public TMP_InputField dirStudent;
    public TMP_InputField codeStudent;
    public TMP_InputField carreraStudent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //    Estudiante e1= new Estudiante("2025_03","ing Multimedia","David Castro", "dacastro@uao.edu.co","carrera 34");
        //    Estudiante e2 = new Estudiante("2025_03", "ing Ambiental", "Maria Perez", "MAPerez@uao.edu.co", "carrera 14");

        //    ListaE.Add(e1);
        //    ListaE.Add(e2);

        //    for (int i = 0;  i < ListaE.Count; i++)
        //    {
        //        Debug.Log(ListaE[i].NameP + "Carrera" + ListaE[i].NameCarreraE);
        //    }
    }

    // Update is called once per frame
    public void Update()
    {
    }

    public void AddStudentList()
    {
        string nameStudent1 = nameStudent.text;
        string mailStudent1 = mailStudent.text;
        string dirStudent1 = dirStudent.text;
        string codeStudent1 = codeStudent.text;
        string carreraStudent1 = carreraStudent.text;

        Estudiante e1 = new Estudiante(codeStudent1, carreraStudent1, nameStudent1, mailStudent1, dirStudent1);

        ListaE.Add(e1);
    }

    public void ShowStudentList()
    {
        for (int i = 0; i < ListaE.Count; i++)
        {
            Debug.Log(ListaE[i].NameP + "Carrera" + ListaE[i].NameCarreraE);
        }

        UtilidadesPer.SaveDataStudent(ListaE);
    }
}
