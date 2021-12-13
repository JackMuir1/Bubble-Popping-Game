using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    //Variable Declaration
    public GameObject bubble;

    //Initialization values
    public float speedcount = 1; //speed of the bubbles
    public float spawnPeriod = 2f;//time between spawning
    public int waves = 0; //number of waves counted
    
    //timer
    float time = 0.0f;
   
    //to check for gameover processes
    bool gameStart = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //increase time and spawn in time period
        time += Time.deltaTime;
        if(time >= spawnPeriod && gameStart)
        {
            time = 0.0f;
            Spawn();
        }
    }

    //to create a bubble
    void Spawn()
    {
        //increase waves
        waves++;

        //change speed to change with time
        bubble.GetComponent<BubbleController>().speed = speedcount;

        //craete bubble object in game
        Instantiate(bubble, new Vector3(Random.Range(-6f, 6f), -8, 0), Quaternion.identity, gameObject.transform);

        //increase speed with waves
        if(waves > 3 && speedcount <= 7)
            speedcount += 0.25f;

        //change values to increase difficulty over timw
        if(waves > 25)
        {
            Instantiate(bubble, new Vector3(Random.Range(-6f, 6f), -10, 0), Quaternion.identity, gameObject.transform);
        }

        if(waves > 8 && spawnPeriod >= 1)
        {
            spawnPeriod -= 0.0625f;
        }

        if(waves > 100)
        {
            spawnPeriod = 0.75f;
            speedcount = 8;
        }
        
    }

    //to end game
    public void StopSpawning()
    {
        gameStart = false;
    }

    //to begin game
    public void StartSpawning()
    {
        gameStart = true;
    }
}
