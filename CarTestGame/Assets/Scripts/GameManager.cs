using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private FinishLine finishLine;
    //private PowerUpController powerUpController;
    private int gemNumber;
    private float gemXPoslimit = .28f;
    private float gemZPosminLimit = -10f;
    private float gemZPosMaxLimit = 15f;
    private float obstacleZPosMinLimit = -10;
    private float obstaceZPosMaxLimit = 10;
    //private float powerUpMinLimit = 0;
    //private float powerUpMaxLimit = 4;
    
    
    public int obstacleNumberLevel;
    public int gemNumberLevel;
    //public int powerUpLevel = 1;
    public bool gameOver;
    public bool isGameActive;
    public Text gemText;
    public GameObject gem;
    public GameObject obstacle;
    public GameObject gameOverScene;
    public GameObject levelCompletedMenu;
    public GameObject titleScreen;
    //public GameObject powerUp;
    // Start is called before the first frame update

    private void Awake() 
    {   
        
        //PowerUpSpawner(0);
        obstacleNumberLevel = 1;
        gemNumberLevel = 1;
        

    }
    void Start()
    {   
        
        finishLine = GameObject.Find("FinishPoint").GetComponent<FinishLine>();
        //powerUpController = FindObjectOfType<PowerUpController>();

        if (isGameActive == false)
        {
            titleScreen.SetActive(true);
        }
    
        
        
        
        
    }

    public void StartGame()
    {   
        if(isGameActive == true)
        {
            gameOver = false;
            //PowerUpSpawner(1);
            
            finishLine.levelCompleted = false;
            CollectingGem(0);
            ObstacleSpawner(obstacleNumberLevel);
            GemSpawner(gemNumberLevel);
            finishLine.levelCompleteScene.SetActive(false);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            GameOverMenu();
        }

        if (gameOver && finishLine.levelCompleted)
        {
            LevelCompletedMenu();
            gameOverScene.SetActive(false);
        }
    }

    public void CollectingGem(int addGem)
    {
        gemNumber += addGem;
        gemText.text = "Gem: " + gemNumber;
    }

    void GemSpawner(int instantiateNumber)
    {   
        float zPos = Random.Range(gemZPosminLimit,gemZPosMaxLimit);
        for (int i =0; i < instantiateNumber; i++)
        {
            float xPos = Random.Range(-gemXPoslimit,gemXPoslimit);
            

            Vector3 gemSpawnPos = new Vector3(xPos,gem.transform.position.y,zPos);
            Instantiate(gem.gameObject,gemSpawnPos,gem.transform.rotation);
            zPos += 3; 
        }
        
    }


    void ObstacleSpawner(int obstacleNumber)
    {   
        float obstacleZPos = Random.Range(obstacleZPosMinLimit,obstaceZPosMaxLimit);
        for (int i = 0; i < obstacleNumber; i++)
        {
            Vector3 obstacleSpawnPos = new Vector3(0,obstacle.transform.position.y,obstacleZPos);
            Instantiate(obstacle.gameObject,obstacleSpawnPos,obstacle.transform.rotation);
            obstacleZPos += 4;
        }
    }

    /*void PowerUpSpawner(int powerUpNumber)
    {
        for (int i = 0; i< powerUpNumber; i++)
        {
            float powerUpZPos = Random.Range(powerUpMinLimit,powerUpMaxLimit);

            Vector3 powerUpSpawnPos = new Vector3 (powerUp.transform.position.x,powerUp.transform.position.y,powerUpZPos);

            Instantiate(powerUp.gameObject, powerUpSpawnPos,powerUp.transform.rotation);
        }
    }*/

    void GameOverMenu()
    {
        gameOverScene.SetActive(true);
    }
    
    void LevelCompletedMenu()
    {
        levelCompletedMenu.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameStarted()
    {
        
        
        titleScreen.SetActive(false);
        isGameActive = true;
        StartGame();
        
    }


    

}
