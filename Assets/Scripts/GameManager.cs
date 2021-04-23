using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score = 0;
    public static int turretLife = 5;

    public static bool gamePauseStatus = false;
    public static bool gameEnd = false;

    public float timeRemaining = 10;
    public string timeFormat;
    public int maxLife;


    public GameObject ScoreText;
    public GameObject LifeText;
    public GameObject TimerText;


    public GameObject PlayingUI;
    public GameObject WinningUI;
    public GameObject EndingUI;
    public GameObject PauseUI;

    public GameObject ScoreEndingText;

    // Start is called before the first frame update
    void Start()
    {
        // TODO

        // Canon laser et bombe
        gameReset();
        Debug.Log(turretLife);

        // Save Life at first load
        maxLife = turretLife;
        Debug.Log(maxLife);

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score : " + score;
        LifeText.GetComponent<Text>().text = "Vie : " + turretLife;
        TimerText.GetComponent<Text>().text = "Temps restant : " + DisplayTime(timeRemaining);

        // Pause menu
        if (gameEnd == false)
        {
            if(Input.GetKeyDown("escape"))
            {
                if(gamePauseStatus == false)
                {
                    PauseGame();
                    return;
                }

                if(gamePauseStatus == true)
                {
                    ResumeGame();
                    return;
                }
            }
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } else
        {
            gameWin();
        }

    }

    void gameReset()
    {
        Time.timeScale = 1;
        gamePauseStatus = false;
        gameEnd = false;
        score = 0;
        turretLife = maxLife;

        // Display UI
        PlayingUI.gameObject.SetActive(true);
        PauseUI.gameObject.SetActive(false);
        WinningUI.gameObject.SetActive(false);
        EndingUI.gameObject.SetActive(false);
    }

    public void gameOver()
    {
        // Game pause
        Time.timeScale = 0;

        gameEnd = true;

        // Display UI
        EndingUI.gameObject.SetActive(true);
        PlayingUI.gameObject.SetActive(false);

        // Update score
        finalScore();
    }

    void finalScore()
    {
        ScoreEndingText.GetComponent<Text>().text = "Score final : " + score;
    }

    public void gameWin()
    {
        // Game pause
        Time.timeScale = 0;

        gameEnd = true;

        // Display UI
        WinningUI.gameObject.SetActive(true);

        // Update score
        finalScore();
    }

    void PauseGame()
    {
        // Game pause
        Time.timeScale = 0;

        // Display UI
        PauseUI.gameObject.SetActive(true);

        gamePauseStatus = true;
    }

    void ResumeGame()
    {
        // Display UI
        PauseUI.gameObject.SetActive(false);

        Time.timeScale = 1;
        gamePauseStatus = false;
    }

    public string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        if(minutes < 0)
        {
            minutes = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        if (seconds < 0)
        {
            seconds = 0;
        }

        float milliSeconds = (timeToDisplay % 1) * 100;
        if (milliSeconds < 0)
        {
            milliSeconds = 0;
        }

        return timeFormat = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }


}
