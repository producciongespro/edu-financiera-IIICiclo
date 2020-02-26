using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agregarBotones : MonoBehaviour
{
    [SerializeField]
    private Transform areaJuego;
    [SerializeField]
    private GameObject boton;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject button = Instantiate(boton);
            button.name = "" + i;
            button.transform.SetParent(areaJuego, false);
        }
    }
}
