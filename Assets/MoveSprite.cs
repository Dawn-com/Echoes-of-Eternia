using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSprite : MonoBehaviour
{
    //to move left and right 
    float dirx = 0f;
    // how fast its moving
    public float movespeed = 10f;
    //to call the rigidbody component
    public Rigidbody2D myRigid;
    //jump force of the character
    public float jump;
    //for calling the animation component
    public Animator animator;
    //to check if the character is touching the floor
    bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        // to call, or get the rigidbody component
        myRigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // to move left and right with arrow keys
        dirx = Input.GetAxisRaw("Horizontal") * movespeed;
        //move the character left and right based on the input andm speed
        transform.position = new Vector2(transform.position.x + dirx * movespeed * Time.deltaTime, transform.position.y);

        //to flip the character
        // if moving right, face left
        if (dirx > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
        }
        //if moving left, face right
        if (dirx < 0)
        {
            transform.localScale = new Vector3(-3, 3, 3);
        }

        //to handle the jump mechanic when the space bar is pressed and when the character is grounded
            if (Input.GetKeyDown(KeyCode.Space) == true && grounded == true)
            {
                // upward veleocity for jumping
                myRigid.velocity = Vector2.up * jump;
                //to play the jump animation
                animator.SetBool("IsJumping", true);
            }
            else
            {
                //to not play the jumpanimation
                animator.SetBool("IsJumping", false);
            }

        //to control the speed in animation based on movement
        animator.SetFloat("Speed", Mathf.Abs(dirx));
    }

    //to check if the character is on the ground or not
    void OnCollisionEnter2D(Collision2D collision)
    {
        // if the character interacts with a game object with the tag floor, it is grounded
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // if the character is not interacting with a gameobject with tag floor it is not grounded
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
}
