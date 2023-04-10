using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpController : MonoBehaviour
{   
    public ParticleSystem plasmaEffect;
    public bool isPowerUpCollected;
    // Start is called before the first frame update

    

    void Start()
    {
        PowerUpMovement();
        isPowerUpCollected = false;
    }


   //Update is called once per frame
    void Update()
    {
        
    }

    void PowerUpMovement()
    {
        transform.DORotate(new Vector3(360f,360f,0),5f,RotateMode.FastBeyond360)
        .SetLoops(-1, LoopType.Restart)
        .SetRelative()
        .SetEase(Ease.Linear);

        transform.DOMoveY(0.86f,1f)
        .SetLoops(-1,LoopType.Yoyo);

        transform.DOMoveX(0.6f,2f)
        .SetLoops(-1, LoopType.Yoyo)
        .SetEase(Ease.InOutSine);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Car")&& !isPowerUpCollected)
        {   

            isPowerUpCollected = true;
            StartCoroutine(DestoryPowerUp());
            
        }    
    }

    public IEnumerator DestoryPowerUp()
    {
        plasmaEffect.Play();
        yield return new WaitForSeconds(.1f);
        transform.DOScale(0,.3f).OnComplete(delegate
        {
            Destroy(gameObject);
            
        });
        
    }
}
