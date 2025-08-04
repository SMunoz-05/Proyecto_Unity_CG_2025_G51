using UnityEngine;
using System;

namespace packagePersona
{
    [Serializable]
    public class Persona
    {
        //Atributos
        private string nameP;
        private string mailP;
        private string dirP;


        //Constructores clickDerecho-Acciones rapidas-Generar contructor-anular todas las selecciones-aceptar
        public Persona()
        {
        }


        //Constructores clickDerecho-Acciones rapidas-Generar contructor-aceptar
        public Persona(string nameP, string mailP, string dirP)
        {
            this.nameP = nameP;
            this.mailP = mailP;
            this.dirP = dirP;
        }

        //Encapsulamiento de los atributos
        public string NameP { get => nameP; set => nameP = value; }
        public string MailP { get => mailP; set => mailP = value; }
        public string DirP { get => dirP; set => dirP = value; }
    }
}