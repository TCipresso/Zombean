using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOverScreen;
    public GameObject StartMenu;
    public GameObject VictoryScreen;
    public GameObject PauseMenu;
    public static bool isPaused = false;
    public AudioSource backgroundMusic;



    void Update()
    {
        Escape();
    }

    public void StartGameZarcade()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(1);


    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void Victory()
    {
        VictoryScreen.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        isPaused = false;
        Time.timeScale = 1f;
    }





    public void ExitGame()
    {

        Application.Quit();
    }

    public void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f; // This pauses the game
        isPaused = true;
        if (backgroundMusic)
        {
            backgroundMusic.Pause();
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f; // This resumes the game
        isPaused = false;
        if (backgroundMusic)
        {
            backgroundMusic.Play();
        }
    }
}



