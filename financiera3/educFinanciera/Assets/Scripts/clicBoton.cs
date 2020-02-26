using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicBoton : MonoBehaviour
{
   public void cambiarEscena()
    {
        Application.LoadLevel("SampleScene");
    }
    public void cambiarMenu()
    {
        Application.LoadLevel("inicio");
       
    }
}
