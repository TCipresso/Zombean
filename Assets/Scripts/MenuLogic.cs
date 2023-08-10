using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject StartMenu;
    public GameObject VictoryScreen;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;  
    public AudioMixer audioMixer;  
    public static bool isPaused = false;
    public AudioSource backgroundMusic;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    Resolution[] resolutions;
    



    private void start()
    {
        if (PlayerPrefs.GetInt("set default volume") != 1){
            PlayerPrefs.SetInt("set default volume", 1);
            PlayerPrefs.SetFloat("master volume", .1f);
            masterSlider.value = .1f;
            PlayerPrefs.SetFloat("master volume", .1f);
            musicSlider.value = .1f;
            PlayerPrefs.SetFloat("master volume", .1f);
            sfxSlider.value = .1f;
        }
        else
        {
            masterSlider.value = PlayerPrefs.GetFloat("master volume");
            sfxSlider.value = PlayerPrefs.GetFloat("master volume");
            musicSlider.value = PlayerPrefs.GetFloat("master volume");
        }
    }

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
        Time.timeScale = 0f;
        isPaused = true;
        if (backgroundMusic)
        {
            backgroundMusic.Pause();
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        if (backgroundMusic)
        {
            backgroundMusic.Play();
        }
    }

    public void ShowOptionsMenu()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        OptionsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("master volume", masterSlider.value);
    }


    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("master volume", sfxSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("master volume", musicSlider.value);
    }
}
