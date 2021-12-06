using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonStorm : MonoBehaviour
{
    private float stormLifeTime = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stormLifeTime -= Time.deltaTime;

        if (stormLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
