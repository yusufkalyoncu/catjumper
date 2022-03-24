using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public Text scoreText;
    public Sprite soundOn, soundOff;
    public Button soundButton;
    void Start()
    {
        scoreText.text = ""+PlayerPrefs.GetInt("bestScore");
        if (PlayerPrefs.GetInt("stopMusic") == 0) soundButton.GetComponent<Image>().sprite = soundOn;
        if (PlayerPrefs.GetInt("stopMusic") == 1) soundButton.GetComponent<Image>().sprite = soundOff;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SoundOnOff()
    {
        if (PlayerPrefs.GetInt("stopMusic") == 1)
        {
            PlayerPrefs.SetInt("stopMusic", 0);
            soundButton.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            PlayerPrefs.SetInt("stopMusic", 1);
            soundButton.GetComponent<Image>().sprite = soundOff;
        }
    }
}
