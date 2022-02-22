using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject column;
    public Renderer fondo;
    public float velocidad = 2;
    public GameObject piedra1;
     public GameObject piedra2;
    public GameObject serpiente1;
    public GameObject pickUp;
    public bool start = false;
    public bool gameOver = false;
    public GameObject vida;
    public GameObject punto;
    private Vidas vidas;

    public List<GameObject> obstaculos;
    public List<GameObject> serpientes;
    public List<GameObject> columns;
    public List<GameObject> pickUps;

    private void Start()
    {
        //crear mapa, vamos a crear 20 columnas

        for(int i = 0; i < 21; i++)
        {
           columns.Add(Instantiate(column, new Vector2(-10 + i, -3), Quaternion.identity));
           //Quaternion.identity - esta es la rotación inicial del objeto, en este caso, no va a rotar nada
        }

        //crear piedras:
        for(int i = 0; i < 3; i++)
        {
            obstaculos.Add(Instantiate(piedra1, new Vector2(-10 + i, -2), Quaternion.identity));
            obstaculos.Add(Instantiate(piedra2, new Vector2(-10 + i, -2), Quaternion.identity));
        }

        //crear serpientes:
        for(int i = 0; i < 5; i++)
        {
             serpientes.Add(Instantiate(serpiente1, new Vector2(-6 + i, -2), Quaternion.identity));
        }

        //crear pickUps:
        for(int i = 0; i < 10; i++)
        {
             pickUps.Add(Instantiate(pickUp, new Vector2(-6+ i, -2), Quaternion.identity));
        }

    }

    void Update()
    {

            if(start == false)
        {
    if(Input.GetKeyDown(KeyCode.X))
    {
        start = true;
    }
        }

        if(start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if(Input.GetKeyDown(KeyCode.X))
            {
                start = false;
                gameOver = false;
                Time.timeScale = 1;
                Vidas.vidas = 10;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
       
         if(start == true && gameOver == false)
         {
            menuPrincipal.SetActive(false);
            vida.SetActive(true);
            punto.SetActive(true);
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f, 0) * Time.deltaTime;
       
       //mover mapa:
        for(int i = 0; i < columns.Count; i++)
        {
            if(columns[i].transform.position.x <= -10)
            {
                columns[i].transform.position = new Vector3(10, -3, 0);
            }

           columns[i].transform.position = columns[i].transform.position + new Vector3(-1, 0, 0) * velocidad * Time.deltaTime;
        }

        //mover piedras/obstaculos:
        for(int i = 0; i < obstaculos.Count; i++)
        {
            if(obstaculos[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(-8, 18);
                obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
            }

            obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }   

        //mover serpientes
         for(int i = 0; i < serpientes.Count; i++)
        {
            if(serpientes[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(-8, 20);
                serpientes[i].transform.position = new Vector3(randomObs, -2, 0);
            }

            serpientes[i].transform.position = serpientes[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }    

            //mover pickUps:
        for(int i = 0; i < pickUps.Count; i++)
        {
            if(pickUps[i].transform.position.x <= -10)
            {
                float randomObs = Random.Range(-8, 18);
                pickUps[i].transform.position = new Vector3(randomObs, -2, 0);
            }

            pickUps[i].transform.position = pickUps[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        }   
         } 

    }

}    
