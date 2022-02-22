using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Jugador : MonoBehaviour
{ 
    private Animator animator;
    public float fuerzaSalto;
    public float fuerzaGolpe;
    private Rigidbody2D rigidbody2D;
    public GameManager gameManager;
    public float speed = 2.0f;
    public Transform player;
    public Vidas vidas;
    public Puntos puntos;
    public AudioSource clip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0,fuerzaSalto));
            PlaySoundButton();
        }

        if(Input.GetKeyDown(KeyCode.Keypad0))
         {
            animator.SetBool("estaGolpeando", true);
            rigidbody2D.AddForce(new Vector2(fuerzaGolpe,0));
         } 

        Vector2 positionToMoveTo = player.position;
        transform.position = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime);
       
    }

    //funcion que detecta si nuestro jugador chocó con algo
    //hay que decirle que cuando chocque con el suelo, 
    //que vuelva a correr
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
        }

        /*if(collision.gameObject.tag == "Obstaculo")
        {
        gameManager.gameOver = true;
        }      */  
        
        if(collision.gameObject.tag == "Serpiente")
        {
            if(animator.GetBool("estaGolpeando"))
            {
                animator.SetBool("estaGolpeando", false);
                PlaySoundButton();
                puntos.GanarPuntos();
            }
            else{
                vidas.PerderVidas();
            }
        }

        if(collision.gameObject.tag == "Obstaculo")
        {
            vidas.PerderVidas();
        }

    }

    public void GanarPuntos() {
        if (puntos.GanarPuntos()) {
            vidas.ganarVidas();
        }
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }

}

