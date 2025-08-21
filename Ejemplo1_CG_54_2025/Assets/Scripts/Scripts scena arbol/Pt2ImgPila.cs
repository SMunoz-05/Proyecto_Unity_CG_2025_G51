using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PilaImagenes : MonoBehaviour
{
    public Transform contenedorPila;  
    public GameObject prefabImagen;    
    public Image displayAccion;      
    public Sprite[] sprites;          

    private Stack<Sprite> pilaSprites = new Stack<Sprite>();

 
    public void PushRandom()
    {
        if (sprites.Length == 0) return;

        int index = Random.Range(0, sprites.Length);
        Sprite sp = sprites[index];
        pilaSprites.Push(sp);

        displayAccion.sprite = sp;

        GameObject go = Instantiate(prefabImagen, contenedorPila);
        go.GetComponent<Image>().sprite = sp;
    }


    public void PopImagen()
    {
        if (pilaSprites.Count == 0) return;

        pilaSprites.Pop();

        if (pilaSprites.Count > 0)
            displayAccion.sprite = pilaSprites.Peek();
        else
            displayAccion.sprite = null;

        if (contenedorPila.childCount > 0)
            Destroy(contenedorPila.GetChild(contenedorPila.childCount - 1).gameObject);
    }

    public void PeekImagen()
    {
        if (pilaSprites.Count > 0)
            displayAccion.sprite = pilaSprites.Peek();
    }

    public void ClearImagen()
    {
        pilaSprites.Clear();
        displayAccion.sprite = null;

        foreach (Transform hijo in contenedorPila)
        {
            Destroy(hijo.gameObject);
        }
    }
}
