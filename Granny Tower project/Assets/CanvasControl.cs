using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject merchantPanel;
    public Text merchantTalk;
    public Image gemoff;
    public Image gemon;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMerchantPanel()
    {
        if (!isOpen)
        {
            merchantPanel.SetActive(true);
            isOpen = true;
        }
    }

    public void CloseMerchantPanel()
    {
        if (isOpen)
        {
            merchantPanel.SetActive(false);
            isOpen = false;
        }
    }

    public void AddLifepoints()
    {
        if (gameManager.playerLifepoints<3 && gameManager.playerPoints >= 100)
        {
            gameManager.AddLifepoints();
            gameManager.ReducePoints(100);
        }
        else if (gameManager.playerLifepoints == 3)
        {
            merchantTalk.text = "You don't need to be healed.";
        }
        else if (gameManager.playerPoints < 100)
        {
            merchantTalk.text = "Not enough points, cheapskate...";
        }
    }

    public void AddHearts()
    {
        if (gameManager.playerHearts < 3 && gameManager.playerPoints >= 500)
        {
            gameManager.AddHearts();
            gameManager.ReducePoints(500);
        }
        else if (gameManager.playerHearts == 3)
        {
            merchantTalk.text = "You don't need to be healed.";
        }
        else if (gameManager.playerPoints < 500)
        {
            merchantTalk.text = "Not enough points, cheapskate...";
        }
    }

    public void AddUmbrella()
    {
        if (gameManager.umbrellaNumber < 15 && gameManager.playerPoints >= 500)
        {
            gameManager.AddUmbrella();
            gameManager.ReducePoints(500);
        }
        else if (gameManager.umbrellaNumber == 15)
        {
            merchantTalk.text = "You can't hold more umbrellas.";
        }
        else if (gameManager.playerPoints < 500)
        {
            merchantTalk.text = "Not enough points, cheapskate...";
        }
    }

    public void SetGemOn()
    {
        gemoff.gameObject.SetActive(false);
        gemon.gameObject.SetActive(true);
    }
}
