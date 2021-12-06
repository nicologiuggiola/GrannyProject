using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedSpikeTrapTrigger : MonoBehaviour
{
    public GameObject spikeDown;
    public GameObject spikeUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(spikeDown);
            spikeUp.SetActive(true);
        }
    }
}
