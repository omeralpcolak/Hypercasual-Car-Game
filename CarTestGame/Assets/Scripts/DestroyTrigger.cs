using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestroyTrigger : MonoBehaviour
{   
    public GameObject obstacle;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Car"))
        {
            StartCoroutine(DestroyObstacle());
        }    
    }

    IEnumerator DestroyObstacle()
    {
        obstacle.transform.DOScale(0,0.4f);
        yield return new WaitForSeconds(.4f);
        Destroy(obstacle.gameObject);
    }
}
