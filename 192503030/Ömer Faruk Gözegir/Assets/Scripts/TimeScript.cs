using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public int scoreAmount;
    public float timer = -1f;
    public int pointIncreasedPerSecond;

    public Rigidbody2D playerRB;
    public PlayerController playerScript;

   void Start()
    {
        pointIncreasedPerSecond = 1;
        timer = -1;
    }

    void Update () 
    {
        timer += Time.deltaTime;

        if (timer >= pointIncreasedPerSecond)
        {
            scoreAmount++;
            timer = 0f;
        }
        
        if(scoreAmount == 10)
        {
            playerRB.gravityScale = 3.2f;
            playerScript.jumpForce = 16f; 
        }else if(scoreAmount == 30)
        {
            playerRB.gravityScale = 3.3f;
            playerScript.jumpForce = 16.5f;
        }else if(scoreAmount == 45)
        {
            playerRB.gravityScale = 3.4f;
            playerScript.jumpForce = 16.7f;
        }else if(scoreAmount == 65)
        {
            playerRB.gravityScale = 3.7f;
            playerScript.jumpForce = 17f;
        }else if(scoreAmount == 90)
        {
            playerRB.gravityScale = 4f;
            playerScript.jumpForce = 17.8f;
        }else if(scoreAmount == 120)
        {
            playerRB.gravityScale = 4.3f;
            playerScript.jumpForce = 18f;
        }
    }
}
