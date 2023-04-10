using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{   

    private Button button;
    private GameManager gameManager;
    private CarController carController;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LevelUp);
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        carController = FindObjectOfType<CarController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelUp()
    {
        gameManager.obstacleNumberLevel++;
        gameManager.gemNumberLevel++;
        //gameManager.powerUpLevel++;
        gameManager.StartGame();
        carController.ResetCarPos();
    }
}
