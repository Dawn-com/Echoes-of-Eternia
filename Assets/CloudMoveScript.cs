using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    //calling the cloud objects
    public GameObject Cloud1;
    public GameObject Cloud2;
    public GameObject Cloud3;
    //the rate at which the clouds spawn
    public float spawnRate = 10;
    //timer to track how long before the next cloud spawns
    private float timer = 0;
    //the vertical range of the clouds
    public float heightOffset = 15;
    //how fast the clouds can move
    public float moveSpeed = 20; 
    //what distance they should get to before deleting themselves
    public float deadzone = -20;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn the clouds at the start of the game
        SpawnCloud(Cloud1);
        SpawnCloud(Cloud2);
        SpawnCloud(Cloud3);
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the time based on the time passed since the last frame
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // once the timer exceeds the spawn rate spawn more clouds
            SpawnCloud(Cloud1);
            SpawnCloud(Cloud2);
            SpawnCloud(Cloud3);

            // reset the timer for the  next spawn cycle
            timer = 0;
        }
    }

    //method for the height range of the clouds
    void SpawnCloud(GameObject cloudPrefab)
    {
        //To define the spawn limits of the clouds
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // to spawn the cloud at a random position within the range
        GameObject newCloud = Instantiate(cloudPrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);

        // Attach a script to make the cloud move and destroy itself
        newCloud.AddComponent<CloudMover>().Initialize(moveSpeed, deadzone);
    }

    //cloud Controls
    public class CloudMover : MonoBehaviour
    {
        //speed at which the cloud can move
        private float moveSpeed;
        //the zone in which the clouds should destroy themselves
        private float deadzone;

        // to initialize the clouds with a speed and a deazone
        public void Initialize(float speed, float zone)
        {
            moveSpeed = speed;
            deadzone = zone;
        }

        void Update()
        {
            //Move the clouds left based on the movespeed
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            //if the clouds pass the deadzone, destroy themselves
            if (transform.position.x < deadzone)
            {
                Destroy(gameObject);
            }
        }
    }
}
