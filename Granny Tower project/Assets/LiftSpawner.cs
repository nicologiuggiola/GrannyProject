using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftSpawner : MonoBehaviour
{
    public GameObject despawner;
    public GameObject lift;

    private bool canSpawn = true;

    private float spawnCD = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD <= 0)
        {
            canSpawn = true;
            spawnCD = 5;
        }

        if (canSpawn)
        {
            SpawnLift();
            canSpawn = false;
        }
    }

    public void SpawnLift()
    {
        GameObject lift1 = Instantiate(lift, transform.position, Quaternion.identity);
        lift1.GetComponent<OneWayLift>().despawner = despawner;
    }
}
