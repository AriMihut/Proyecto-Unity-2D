using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Vidas : MonoBehaviour
{
    public static int vidas = 10;
    public TMP_Text textoVidas;
    public GameManager gameManager;
    public GameObject winTextObject;

    void Start()
    {
        ActualizarMarcadorVidas();
        winTextObject.SetActive(false);
    }

    void ActualizarMarcadorVidas()
    {
        textoVidas.text = "Vidas: " + Vidas.vidas;
    }

   public void PerderVidas()
    {
         ActualizarMarcadorVidas();
         vidas --;
         if(vidas == 0)
         {
            winTextObject.SetActive(true);
            gameManager.gameOver = true;
            Time.timeScale = 0;
         }

    }

    public void ganarVidas(){
        vidas++;
        ActualizarMarcadorVidas();
    }
    
}
