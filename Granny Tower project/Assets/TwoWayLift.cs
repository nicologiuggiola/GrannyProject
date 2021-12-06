using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWayLift : MonoBehaviour
{
    public Transform obj1;
    public Transform obj2;
    public float speed;

    public enum Phases
    {
        MOVINGUP,
        MOVINGDOWN
    }

    public Phases phases;
    // Start is called before the first frame update
    void Start()
    {
        phases = Phases.MOVINGUP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        switch (phases)
        {
            case Phases.MOVINGUP:
                transform.position = Vector2.MoveTowards(transform.position, obj1.transform.position, speed * Time.deltaTime);
                if (transform.position == obj1.transform.position)
                {
                    phases = Phases.MOVINGDOWN;
                }
                break;
            case Phases.MOVINGDOWN:
                transform.position = Vector2.MoveTowards(transform.position, obj2.transform.position, speed * Time.deltaTime);
                if (transform.position == obj2.transform.position)
                {
                    phases = Phases.MOVINGUP;
                }
                break;
        }
    }
}
