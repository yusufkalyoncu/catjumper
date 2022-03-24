using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public string mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        UIController.instance.rightButton.gameObject.SetActive(false);
        UIController.instance.leftButton.gameObject.SetActive(false);
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        UIController.instance.rightButton.gameObject.SetActive(true);
        UIController.instance.leftButton.gameObject.SetActive(true);
    }
    public void MainMenu()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }
}
