using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    //the players score
    public int playerScore;
    //refrence to the UI text that will display the player score
    public Text scoreText;

    public void addScore() 
    {
        //if the player interacts with a game object with this script add the score
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
    }
}
