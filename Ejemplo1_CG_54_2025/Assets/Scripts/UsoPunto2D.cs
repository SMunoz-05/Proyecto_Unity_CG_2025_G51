using UnityEngine;
using System.Collections.Generic;
using PackagePunto2D; 

public class UsoPunto2D : MonoBehaviour
{
    
    List<Punto2D> listaPuntos = new List<Punto2D>();

    
    void Start()
    {
        Punto2D p1 = new Punto2D(1.5, 3.7);
        Punto2D p2 = new Punto2D(4.2, 2.1);
  
        listaPuntos.Add(p1);
        listaPuntos.Add(p2);

        for (int i = 0; i < listaPuntos.Count; i++)
        {
            Debug.Log("Punto " + i + ": X = " + listaPuntos[i].X + ", Y = " + listaPuntos[i].Y);
        }
 
        Utilidades.SerializarPuntos(listaPuntos);
    }

    void Update()
    {

    }
}
