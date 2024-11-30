using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour
{
    //Enemy damage
    public int damage;
    //Enemy damage when it is night
    public int currentDamage;
    //player health with refrence to the PlayerHealthScript
    public PlayerHealthScript playerHealth;
    //calling Day and night script
    private DayAndNightScript dayAndNightScript;

    void Start()
    {
        //find day and night script
        dayAndNightScript = FindObjectOfType<DayAndNightScript>();
        UpdateDamage();
    }

    void Update()
    {
        UpdateDamage();
    }

    //if it turns night, increase its damage
    private void UpdateDamage()
    {
        if (dayAndNightScript != null && dayAndNightScript.IsNight)
        {
            currentDamage = damage * 2;
        }
        else
        {
            currentDamage = damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //if the enemy collides with the player, the player should take damage
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
