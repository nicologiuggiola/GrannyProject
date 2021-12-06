using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrappedRespawn : MonoBehaviour
{
    public GameObject trapTrigger;
    public GameObject merchantTransformPost;
    private Respawner respawn;
    private GameObject merchant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        respawn = FindObjectOfType<Respawner>();
        merchant = GameObject.FindGameObjectWithTag("Merchant");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (trapTrigger)
            {
                Destroy(trapTrigger);
            }
            
            respawn.transform.position = transform.position;
            merchant.transform.position = merchantTransformPost.transform.position;
            gameObject.SetActive(false);
        }
    }
}
