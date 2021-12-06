using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private Respawner respawn;
    private CanvasControl canvasC;
    private EndGameController eGControl;
    private Text lifepointsText;
    private Text heartText;
    private Text pointText;
    private Text umbrellasText;

    public int playerLifepoints = 3;
    public int playerHearts = 3;
    public int umbrellaNumber = 6;
    public int playerPoints;
    private int level = 1;

    private float victorySceneCD = 5;

    public bool playerDead = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    void Update()
    {
        lifepointsText = GameObject.FindGameObjectWithTag("LifepointsText")?.GetComponent<Text>();
        heartText = GameObject.FindGameObjectWithTag("Heart1")?.GetComponent<Text>();
        pointText = GameObject.FindGameObjectWithTag("PointsText")?.GetComponent<Text>();
        umbrellasText = GameObject.FindGameObjectWithTag("Umbrellas")?.GetComponent<Text>();

        if (lifepointsText)
        {
            lifepointsText.text = "Lifepoints: " + playerLifepoints;
        }

        if (heartText)
        {
            heartText.text = "Hearts: " + playerHearts;
        }

        if (pointText)
        {
            pointText.text = "Pt: " + playerPoints;
        }

        if (umbrellasText)
        {
            umbrellasText.text = "Ombrelli: " + umbrellaNumber;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("VictoryScene"))
        {
            victorySceneCD -= Time.deltaTime;
            if (victorySceneCD <= 0)
            {
                level++;
                victorySceneCD = 5;
                SceneManager.LoadScene(level);
            }
        }
    }

    public void ReduceLifepoints(int damage)
    {
        playerLifepoints = playerLifepoints - damage;

        if (playerLifepoints <= 0)
        {
            KillPlayer();
        }
    }

    public void ReducePoints(int transaction)
    {
        playerPoints = playerPoints - transaction;
    }

    public void AddLifepoints()
    {
        playerLifepoints = 3;
    }

    public void AddHearts()
    {
        playerHearts++;
    }

    public void AddUmbrella()
    {
        umbrellaNumber++;
    }

    public void RemoveUmbrella()
    {
        umbrellaNumber--;
    }

    public void KillPlayer()
    {
        playerHearts--;

        if (playerHearts <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
