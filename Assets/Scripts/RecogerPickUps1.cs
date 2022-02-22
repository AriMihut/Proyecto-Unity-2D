using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RecogerPickUps1 : MonoBehaviour
{
    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rey")) 
        {
            
            Jugador jugador = other.gameObject.GetComponent<Jugador>();
            jugador.GanarPuntos();

            clip.Play();
            Invoke("Desactivar", 0.2f);
        }
    }

    private void Desactivar() {
        gameObject.SetActive(false);
    }
}
