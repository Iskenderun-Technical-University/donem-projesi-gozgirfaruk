using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool playerTouched;

    public AudioSource ScoreUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.relativeVelocity.y <= 0f)
            {
                if(playerTouched == false)
                {
                    collision.gameObject.GetComponent<Score>().ScorePlus();
                    ScoreUp.Play();
                }
                collision.gameObject.GetComponent<PlayerController>().Grounded();
                playerTouched = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "destroy")
        {
            Destroy(gameObject);
        }
    }
}
