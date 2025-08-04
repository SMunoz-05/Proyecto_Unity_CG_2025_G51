using UnityEngine;
using System;
using packagePersona;
using System.Collections.Generic;

public class UsoEstudiante : MonoBehaviour
{
    List<Estudiante> ListaE = new List<Estudiante>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Estudiante e1= new Estudiante("2025_03","ing Multimedia","David Castro", "dacastro@uao.edu.co","carrera 34");
        Estudiante e2 = new Estudiante("2025_03", "ing Ambiental", "Maria Perez", "MAPerez@uao.edu.co", "carrera 14");

        ListaE.Add(e1);
        ListaE.Add(e2);

        for (int i = 0;  i < ListaE.Count; i++)
        {
            Debug.Log(ListaE[i].NameP + "Carrera" + ListaE[i].NameCarreraE);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
