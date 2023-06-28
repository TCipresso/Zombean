using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * MenuLogic is used to handle to logic for the menu's as well as some of the gameplay Logic.
 * I meant for this to be a menu manager and partial gameplay manager.
 */
public class MenuLogic : MonoBehaviour
{
    public GameObject GameOverScreen;
    public int ScorePlayer;
    public Text TextScore;

    public ImageFader imageFader;


   

    // Start is called before the first frame update
    void Start()
    {
        ScorePlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()//loads scene when user presses play button.
    {
        MainToPlay();
        //SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {

        Application.Quit();
    }

    public void MainToPlay()//applied the fade in and out from class for me seemless transition.
    {

        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine()
        {
            imageFader.FadeToBlack();
            yield return new WaitForSeconds(imageFader.fadeTime);
            imageFader.FadeFromBlack();
            SceneManager.LoadScene(1);
            yield return null;
        }
    }

    public void DeathToMain() //Used from what we got in class to make a simple fade in and out.

    {
        
        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine()
        {
            imageFader.FadeToBlack();

            yield return new WaitForSeconds(imageFader.fadeTime);
            imageFader.FadeFromBlack();

            SceneManager.LoadScene(0);

            yield return null;
            
        }
    }

    public IEnumerator GameOver()//I set a small coroutine to make the game over screen not just APPEAR as soon as player dies. without this coroutine death felt very rigid.
    {
        yield return new WaitForSeconds(0.5f); 
        Debug.Log("GameOVer started");
        // then Load the Game Over screen
        
    }

    public IEnumerator MainTransition()// This coroutine handles transistioning gameover screen to main menu. Show game over for 3 seconds then go to main menu.
    {
        StartCoroutine(GameOver()); //nested with GameOver to start this coroutine after GameOver completes.
        Debug.Log("Transistion started");
        yield return new WaitForSeconds(3f); //show game over screen for 3 seconds then go to main menu.
        DeathToMain();
        GameOverScreen.SetActive(false);
       // SceneManager.LoadScene(0);

    }

    public void GameOverToMain() //This is just a nice method that handles the GameOver screen to main menu.
    {
        Debug.Log("Final started");
        
        StartCoroutine(MainTransition());
    }

    
    public void Score()// this is the method that is used to update the players score in the UI.
    {
        ScorePlayer = ScorePlayer - 100;
        TextScore.text = ScorePlayer.ToString();
    }





}
