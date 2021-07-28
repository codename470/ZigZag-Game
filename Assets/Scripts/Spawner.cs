using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;
    float random;
    public bool gameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 10; i++)
        {
            RandomSpawner();
        }
        
    }

    public void StartSpawning()
    {
        InvokeRepeating("RandomSpawner", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("RandomSpawner");
        }
    }

    void RandomSpawner()
    {
       
        random = UnityEngine.Random.Range(1, 3);
        if (random == 1)
        {
            SpawnX();
        }
        if (random == 2)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPos = pos;

        int rand = UnityEngine.Random.Range(0, 7);
        Vector3 diamondPos = new Vector3(pos.x, pos.y + 1f, pos.z);
        if(rand == 0)
        {
            Instantiate(diamond, diamondPos, diamond.transform.rotation);
        }

    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPos = pos;

        int rand = UnityEngine.Random.Range(0, 7);
        Vector3 diamondPos = new Vector3(pos.x, pos.y + 1f, pos.z);
        if (rand == 0)
        {
            Instantiate(diamond, diamondPos, diamond.transform.rotation);
        }


    }
}
