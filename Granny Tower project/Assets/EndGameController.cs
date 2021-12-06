using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    public GameObject[] preCollapse;
    public GameObject[] postCollapse;

    public bool startCollapse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startCollapse)
        {
            for (int i = 0; i < preCollapse.Length; i++)
            {
                Destroy(preCollapse[i]);
            }

            for (int i = 0; i < postCollapse.Length; i++)
            {
                postCollapse[i].SetActive(true);
            }

            Destroy(gameObject);
        }
    }


}
