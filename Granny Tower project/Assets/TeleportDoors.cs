using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoors : MonoBehaviour
{
    private PlayerScript player;
    private Respawner respawn;
    public Transform endDoor;

    public bool isTreasureDoor;
    // Start is called before the first frame update
    void Start()
    {
        
        respawn = FindObjectOfType<Respawner>();
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = endDoor.transform.position;
            if (!isTreasureDoor)
            {
                respawn.transform.position = endDoor.transform.position;
            }
        }
    }
}
