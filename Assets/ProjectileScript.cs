using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    //speed of the projectile
    public float speed = 20f;
    //refrence to the rigidbody component attached to the projectile
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Get the rigidbody component from the projectile
        rb = gameObject.GetComponent<Rigidbody2D>();
        //the velocity of the projectile to where it is facing multiplied by the speed
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D ThingIHit)
    {
        //if the projectile hits a game object with an enemy tag, reduce the life of the enemy and destroy the enemy when its life reaches 0
        if (ThingIHit.tag == "Enemy")
        {
            ThingIHit.GetComponent<EnemyBehaviour>().LifeTotal--;
            if (ThingIHit.GetComponent<EnemyBehaviour>().LifeTotal == 0)
            {
                Destroy(ThingIHit.gameObject);
            }
        }
        // destroy the projectile after it hits the enemy
        Destroy(gameObject);
    }
}
