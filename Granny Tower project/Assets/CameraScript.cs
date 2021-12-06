using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerScript player = FindObjectOfType<PlayerScript>();

        if (player)
        {
            Transform playerTransform = player.transform;
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - 1);
        }

    }
}
