using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GemController : MonoBehaviour
{   

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameManager>();


        GemMovement();   
    }
    private void Update() 
    {
        if(transform.position.z > 15)
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Car"))
        {   
            gameManager.CollectingGem(1);
            transform.DOScale(0,.5f).OnComplete(delegate
            {
                Destroy(gameObject);
            });
        }
    }

    void GemMovement()
    {
        transform.DORotate(new Vector3(0,360,0),1f,RotateMode.FastBeyond360)
        .SetLoops(-1,LoopType.Restart)
        .SetRelative()
        .SetEase(Ease.Linear);

        transform.DOMoveY(0.86f,1f)
        .SetLoops(-1,LoopType.Yoyo);
    }

}
