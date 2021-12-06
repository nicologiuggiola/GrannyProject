using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantTeleport : MonoBehaviour
{
    public GameObject merchant;
    public Transform merchantNew;
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
            merchant.transform.position = merchantNew.transform.position;
        }
    }
}
