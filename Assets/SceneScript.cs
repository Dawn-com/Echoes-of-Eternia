using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    //the scene to be loaded
    public int Respawn;

    void OnTriggerEnter2D(Collider2D kill)
    {
        //if the player makes contact with a game object that has this script take them to the first scene(Respawn)
        if (kill.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn);
        }
    }
}
