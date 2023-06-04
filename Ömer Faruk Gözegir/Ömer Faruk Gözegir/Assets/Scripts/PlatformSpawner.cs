using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objectt;
    public float spawnTime = 5f;
    public float spawnDelay = 3f; 
    Rigidbody2D rb;
    public float moveSpeed = 6;

    void Start () 
    {
        InvokeRepeating ("addObject", spawnDelay, spawnTime);
        rb = GetComponent<Rigidbody2D>();
    }

    void addObject() 
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int randomIndex = Random.Range(0, objectt.Length);
        Instantiate (objectt[randomIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.up * moveSpeed * Time.timeScale;
    }
}
