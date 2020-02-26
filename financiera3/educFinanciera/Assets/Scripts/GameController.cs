using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite imagenBG;
    public Sprite[] cartas;
    public List<Sprite> cartasJuego = new List<Sprite>();
    public List<Button> botones = new List<Button>();
    private bool primeraCarta, segundaCarta;
    private int contadorCartas;
    private int contadorCartasCorrectas;
    private int contadorCartasJuego;
    private int primeraCartaIndex, segundaCartaIndex;
    private string primeraCartaNombre, segundaCartaNombre;
    //  private void Awake()
    //  {
    //     cartas = Resources.LoadAll<Sprite> ("Sprites/Candy");
    //  }
    void Start()
    {
        obtenerBotones();
        AddListeners();
        contadorCartas = cartasJuego.Count / 2;
        mezclarCartas(cartasJuego);
    }

    void obtenerBotones()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tarjetas");
        for (int i = 0; i < objects.Length; i++)
        {
            botones.Add(objects[i].GetComponent<Button>());
        }
    }

    void AddListeners()
    {
        foreach (Button boton in botones)
        {
            boton.onClick.AddListener(() => cliquearTarjeta());
        }
    }

    public void cliquearTarjeta()
    {
        if (!primeraCarta)
        {
            primeraCarta = true;
            primeraCartaIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            primeraCartaNombre = cartasJuego[primeraCartaIndex].name;
            botones[primeraCartaIndex].image.sprite = cartasJuego[primeraCartaIndex];
        }
        else if (!segundaCarta)
        {
            segundaCarta = true;
            segundaCartaIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            segundaCartaNombre = cartasJuego[segundaCartaIndex].name;
            botones[segundaCartaIndex].image.sprite = cartasJuego[segundaCartaIndex];
            contadorCartasJuego++;
            StartCoroutine(verificarParejas());
        }

        IEnumerator verificarParejas()
        {

            yield return new WaitForSeconds(1f);
        if (primeraCartaNombre == segundaCartaNombre)
            {
                yield return new WaitForSeconds(.5f);
                botones[primeraCartaIndex].interactable = false;
                botones[segundaCartaIndex].interactable = false;
                botones[primeraCartaIndex].image.color = new Color(0, 0, 0, 0);
                botones[segundaCartaIndex].image.color = new Color(0, 0, 0, 0);
                verificarTerminado();
            }
            else {
                botones[primeraCartaIndex].image.sprite = imagenBG;
                botones[segundaCartaIndex].image.sprite = imagenBG;
            }
            yield return new WaitForSeconds(.5f);
            primeraCarta = segundaCarta = false;
        }
        void verificarTerminado()
        {
            contadorCartasCorrectas++;
            Debug.Log("Parejas logradas: "+contadorCartasCorrectas);
            Debug.Log("Parejas requeridas: " + contadorCartas);
            if (contadorCartasCorrectas == contadorCartas)
            {

                mostrarFinal();
            }
     
        }
    }
    void mezclarCartas(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int numeroAleatorio = Random.Range(i, list.Count);
            list[i] = list[numeroAleatorio];
            list[numeroAleatorio] = temp;
        }
    }

    void mostrarFinal()
    {
        Debug.Log("Juego Terminado");
        Debug.Log("Usaste " + contadorCartasJuego + " intentos parar ganar el juego");
        txtIntentos.text = "Intentos usados = " + contadorCartasJuego.ToString();
    }
}
