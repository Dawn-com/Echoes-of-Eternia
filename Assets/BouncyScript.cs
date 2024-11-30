using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour
{
    // Force to apply when bouncing
    public float bounceForce = 2f; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Rigidbody2D of the player
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Ensure the player has a Rigidbody2D component
            if (playerRb != null)
            {
                // Zero the vertical velocity before applying the bounce (optional, for consistency)
                playerRb.velocity = new Vector2(playerRb.velocity.x, 0);

                // Apply an upward force to bounce the player
                playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}


