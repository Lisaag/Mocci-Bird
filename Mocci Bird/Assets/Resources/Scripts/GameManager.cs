using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted = false;

    private Touch touch;

    private static int score = 0;

    public static DeathData[] allDeaths = new DeathData[100];

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    StartGame();
                }
            }
        }
    }

    public static void StartGame()
    {
        isGameStarted = true;
        UIManager.instance.SetUIInGame();
    }

    public static void ReloadScene()
    {
        isGameStarted = false;
        Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void GameOver(int index, DeathCause deathCause, MocciColor mocciColor)
    {
        SaveDeath(index, deathCause, mocciColor);
        ReloadScene();
    }

    private static void SaveDeath(int index, DeathCause deathCause, MocciColor mocciColor)
    {
        if (allDeaths[index] == null)
        {
            allDeaths[index] = new DeathData(index, deathCause, mocciColor);
        }
        else
        {
            if (deathCause == DeathCause.Top)
            {
                allDeaths[index].topDeaths.Enqueue(mocciColor);
            }
            else if (deathCause == DeathCause.Bottom)
            {
                allDeaths[index].bottomDeaths.Enqueue(mocciColor);
            }
        }
    }
}