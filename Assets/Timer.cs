using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //Tracks the current time
    float currentTime;
    //the starting time for the timer
    public float startingTime = 30f;
    //Name of scene to load if timer runs out
    public int Respawn;

    //Refrence to the UI text component that displays the countdown
    [SerializeField] Text countdownText;

    void Start()
    {
        // the current time is equivalent to the starting time
        currentTime = startingTime;
    }
    void Update()
    {
        //Decrease the time by the time lost since the last frame
        currentTime -= Time.deltaTime;
        //to update the countdown text as a number without decimal places
        countdownText.text = currentTime.ToString("0");

        //if the time equals to zero, it is zero(so it wont go negative) and take the player back to the first scen
        if (currentTime <= 0)
        {
            currentTime = 0;
            SceneManager.LoadScene(Respawn);
        }
    }
}