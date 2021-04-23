using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int life = 5;

    public static bool gamePauseStatus = false;
    public static bool gameEnd = false;

    public float timeRemaining = 10;
    public string timeFormat;

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

        // Menu du jeu qui permet de jouer et quitter
        // Menu pause qui permet de quitter le jeu, retourenr et menu et reprendre la partie
        // Menu 
        //

        Time.timeScale = 1;

        // Display UI
        PlayingUI.gameObject.SetActive(true);
        PauseUI.gameObject.SetActive(false);
        WinningUI.gameObject.SetActive(false);
        EndingUI.gameObject.SetActive(false);

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score : " + score;
        LifeText.GetComponent<Text>().text = "Vie : " + life;
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

    public void gameOver()
    {
        // Game pause
        Time.timeScale = 0;

        gameEnd = true;

        // Display UI
        EndingUI.gameObject.SetActive(true);
        PlayingUI.gameObject.SetActive(false);

        ScoreEndingText.GetComponent<Text>().text = "Score final : " + score;
    }

    public void gameWin()
    {
        // Game pause
        Time.timeScale = 0;

        gameEnd = true;

        // Display UI
        WinningUI.gameObject.SetActive(true);
        ScoreEndingText.GetComponent<Text>().text = "Score final : " + score;


    }

    void PauseGame()
    {
        // Display UI
        PauseUI.gameObject.SetActive(true);

        Time.timeScale = 0;
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
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        return timeFormat = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
