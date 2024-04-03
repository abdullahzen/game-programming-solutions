using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject OptionsButton;
    public GameObject ExitButton;
    public GameObject MainMenuButton;
    public GameObject ResumeButton;
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public Slider slider;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.SetActive(false);
        OptionsButton.SetActive(false);
        ExitButton.SetActive(false);
        MainMenuButton.SetActive(false);
        ResumeButton.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            ResumeButton.SetActive(true);
            MainMenuButton.SetActive(true);
        }
        if (Time.timeScale == 1)
        {
            StartButton.SetActive(true);
            OptionsButton.SetActive(true);
            ExitButton.SetActive(true);
        }
    }

    public void StartGame()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainScene");
    }

    public void Options()
    {
        audioSource.Play();
        MainMenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void Exit()
    {
        audioSource.Play();
        Application.Quit();
    }

    public void ResumeGame()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void Back()
    {
        MainMenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
    }
}
