using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightScript : MonoBehaviour
{
    // Main Camera
    public Camera mainCamera;
    // Color for day
    public Color dayColor = Color.cyan;
    // Color for night
    public Color nightColor = Color.black;
    // time until day changes to night and night changes to day
    public float cycleDuration = 10f;
    //to check that the cycle is moving between the two times alone (day(1)to night(0))
    private float time;
    //to check if it is night time
    public bool IsNight => Mathf.Sin(time * Mathf.PI) > 0.5;

    // Start is called before the first frame update
    void Start()
    {
        //if there is no refrence to the main camera, assign it
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //To make sure the time is normal throughout.
        time += Time.deltaTime / cycleDuration;
        // to make sure the time is either 1 or 0
        time %= 1;
        //smooth transition using the sine wave transition
        mainCamera.backgroundColor = Color.Lerp(dayColor, nightColor, Mathf.Sin(time * Mathf.PI));
    }
}
