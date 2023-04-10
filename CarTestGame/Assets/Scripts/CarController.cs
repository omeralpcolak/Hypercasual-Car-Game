using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarController : MonoBehaviour
{   
    
    public float forwardSpeed;
    public float slideSpeed;
    public GameObject sparkEffect;
    public float jumpPower;
    //public GameObject carObject;


    private float xLimit = .6f;
    private SlideController slideController;
    //public PowerUpController powerUpController;
    private GameManager gameManager;
    //private float totalPowerUpTime = 2f;
    //private float currentPowerUpTime;
    private Rigidbody carRbody;
    private bool isItOnGround;
    //private bool isItRightDirection;


    // Start is called before the first frame update
    void Start()
    {   
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
        carRbody = GetComponent<Rigidbody>();
        //currentPowerUpTime = totalPowerUpTime;
        slideController = GameObject.Find("GameController").GetComponent<SlideController>();
        //powerUpController = GameObject.Find("PowerUp").GetComponent<PowerUpController>();

    }

    // Update is called once per frame
    void Update()
    {   
        
        if (gameManager.isGameActive)
        {   
            
            if (carRbody.velocity.y == 0)
            {   
                sparkEffect.SetActive(true);
                isItOnGround = true;
            }

            if (!gameManager.gameOver)
            {
                ForwardMovement();
                Jump();
            }
            else
            {
                sparkEffect.SetActive(false);
            }
        
        
            ControllingXPos();

            
        }
        
        //Drifting();
        
    }


    void ForwardMovement()
    {
        transform.Translate(slideController.moveX * slideSpeed * Time.deltaTime,0,forwardSpeed * Time.deltaTime );
    }
    
    void ControllingXPos()
    {
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x,-xLimit,xLimit),transform.position.y,transform.position.z);
    }

    /*void PowerUpCarMovement()
    {   
        currentPowerUpTime -= Time.deltaTime;

        if (currentPowerUpTime>0 && powerUpController.isPowerUpCollected)
        {
            transform.Translate(slideController.moveX * slideSpeed * Time.deltaTime,0,forwardSpeed * Time.deltaTime*2 );
        }
        else if (currentPowerUpTime <= 0)
        {
            powerUpController.isPowerUpCollected = false;
            currentPowerUpTime = totalPowerUpTime;
        }

        

        
    }*/

    void Jump()
    {   
        if (isItOnGround)
        {
            if (Input.touchCount > 0)
            {
                Touch finger = Input.GetTouch(0);

                if (finger.deltaPosition.y > 25f)
                {   
                    sparkEffect.SetActive(false);
                    carRbody.velocity = Vector3.zero;
                    carRbody.velocity = Vector3.up * jumpPower;
                    isItOnGround = false;
                }
            }
        }
        
    }

    public void ResetCarPos()
    {
        transform.position = new Vector3 (0,0.51f,-14.105f);
    }


    /*private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            powerUpController.isPowerUpCollected = true;
            powerUpController.StartCoroutine(powerUpController.DestoryPowerUp());
        }
    }*/

    

    /*void Drifting()
    {
        if(carRbody.velocity.x > 0)
        {
            isItRightDirection = true;
            if (isItRightDirection)
            {
                carObject.transform.DORotate(new Vector3 (0,-45,0), 0.2f);
            }
        }
        else if (carRbody.velocity.x <0)
        {
            isItRightDirection = false;
            if (!isItRightDirection)
            {
                carObject.transform.DORotate(new Vector3(0,45,0), 0.2f);
            }
        }

        if (carRbody.velocity.x ==0)
        {
            carObject.transform.DORotate(new Vector3(0,0,0),0.2f);
        }
    }*/
}
