using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakScript : MonoBehaviour
{
    //time before the platform disappearsor breaks
    public float timeBeforeDisappear = 5f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the player interacts with it disappear within the time given
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Disappear());
        } 
    }

    private IEnumerator Disappear()
    {
        //to make sure the platform waits until it disappers
        yield return new WaitForSeconds(timeBeforeDisappear);
        // if the time runs out, the game object is to disappear(be inactive)
        gameObject.SetActive(false);
    }
    
}
