using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{   

    //private PowerUpController powerUpController;
    private GameManager gameManager;


    public bool isItRight;
    public GameObject leftObstacle;
    public GameObject rightObstacle;

    private void Start() 
    {
        //powerUpController = FindObjectOfType<PowerUpController>();
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    private void Update() 
    {
        if (transform.position.z > 15)
        {
            Destroy(gameObject);
        }    
    }


    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Car"))
        {   
            gameManager.gameOver = true;
            gameManager.gameOverScene.SetActive(true);
            //StartCoroutine(ObstacleDestroy());
        }
    }

    /*public void ObstacleMove()
    {
        if (isItRight)
        {
            rightObstacle.transform.DORotate(new Vector3(0,90,0),.1f,RotateMode.Fast);
        }
        if (!isItRight)
        {
            leftObstacle.transform.DORotate(new Vector3(0,-90,0),.1f,RotateMode.Fast);
        }
    }*/

    
}
