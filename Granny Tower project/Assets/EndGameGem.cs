using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameGem : MonoBehaviour
{
    private EndGameController eGControl;
    private CanvasControl canvasC;
    // Start is called before the first frame update
    void Start()
    {
        eGControl = FindObjectOfType<EndGameController>();
        canvasC = FindObjectOfType<CanvasControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eGControl.startCollapse = true;
            canvasC.SetGemOn();
            Destroy(gameObject);
        }
    }
}
