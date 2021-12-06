using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayLift : MonoBehaviour
{
    private EndGameController endgame;
    public GameObject despawner;
    private float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == despawner.transform.position)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, despawner.transform.position, speed * Time.deltaTime);
    }
}
