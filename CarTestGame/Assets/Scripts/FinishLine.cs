using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{   
    private GameManager gameManager;
    public GameObject levelCompleteScene;
    public bool levelCompleted;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Car"))
        {
            gameManager.gameOver = true;
            levelCompleted = true;
            
        }    
    }
}
