using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
    public static int puntos = 0;
    public TMP_Text textoPuntos;
    
    void Start()
    {
        ActualizarMarcadorPuntos();
    }

    void ActualizarMarcadorPuntos()
    {
        textoPuntos.text = "Puntos: " + Puntos.puntos;
    }

    public bool GanarPuntos()
    {
        Puntos.puntos++;
        ActualizarMarcadorPuntos();
        if(puntos % 5 == 0)//cada vez que llego a 10 puntos, si el resto de la división es 0, que me sume una vida
        {
            return true;
        }
        return false;
    }
}
