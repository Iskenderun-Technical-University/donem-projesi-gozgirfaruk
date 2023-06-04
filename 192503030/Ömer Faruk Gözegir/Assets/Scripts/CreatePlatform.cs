using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    public GameObject platformPrefab;
    [SerializeField] int platformInt = 50;

    void Start()
    {
        createPlatform();
    }

    void createPlatform()
    {
        Vector2 platformVector = new Vector2();
        for(int i = 0; i < platformInt; i++)
        {
            GameObject tempPlatform = Instantiate(platformPrefab);
            platformVector.x = Random.Range(-2f, 2.2f);
            platformVector.y += Random.Range(2.5f, 2.6f);
            tempPlatform.transform.position = platformVector;
        }
    }
}
