using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    //Refrencing the LogicScript
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        // to find the game onject with the tag logic and get the logicScript
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //to add up the score
        logic.addScore();
        // to destry the game object after its been collided with
        Destroy(gameObject);
    }
}
