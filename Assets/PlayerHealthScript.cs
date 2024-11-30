using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    //Max health of the player, it is stagnant
    public int maxHealth = 10;
    //Health of the player, it changes as the player takes damage
    public int health;
    //name of the scene to load when player dies
    public int Respawn;

    // Start is called before the first frame update
    void Start()
    {
        //health equals to max health at the start of the game
        health = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        //reducing the players health by damage taken
        health -= damage;
        //if the players health reaches zero, respawn at the first scene(Respawn)
        if (health <= 0)
        {
            SceneManager.LoadScene(Respawn);
        }
    }
}
