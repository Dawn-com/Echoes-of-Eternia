using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //Enemy's total life
    public int LifeTotal = 3;
    //life after it turns night
    public int currentLife;
    //Enemy's speed
    public int EnemySpeed = 15; 
    //The player
    private GameObject player;
    //calling Day and night script
    private DayAndNightScript dayAndNightScript;

    // Start is called before the first frame update
    void Start()
    {
        //The player is equivalent to any object with the tag 'Player'
        player = GameObject.FindGameObjectWithTag("Player");
        //find day and night script
        dayAndNightScript = FindObjectOfType<DayAndNightScript>();
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //To follow or move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, EnemySpeed * Time.deltaTime);
        UpdateHealth();
    }

    //if it turns night, increase its health
    private void UpdateHealth()
    {
        if (dayAndNightScript != null && dayAndNightScript.IsNight)
        {
            currentLife = LifeTotal * 2;
        }
        else
        {
            currentLife = LifeTotal;
        }
    }
}
