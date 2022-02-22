using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    private Animator animator;
    public float fuerzaClimb;
    public float fuerzaMorder;
    private Rigidbody2D rigidbody2D;
    public float speed = 1.0f;
    public GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Rey");
    }

    void Update()
    {
        Vector2 positionToMoveTo = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, positionToMoveTo, speed * Time.deltaTime);
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {

        /*if(collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaMordiendo", false);
        }*/

        if(collision.gameObject.tag == "Rey")
        {
            animator.SetBool("estaMordiendo", true);
        }

    }
}
