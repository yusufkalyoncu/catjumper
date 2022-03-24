using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [Header("BlackAndWhiteScreen")]
    public float fadeSpeed;
    public Image fadeScreen;
    public bool WhiteToBlack;
    public bool BlackToWhite;
    [Header("Texts and buttons")]
    public Text gameOver, yourScoreText, yourScore, newHighest, bestScoreText, bestScore;
    public Button playAgain, mainMenu;
    public static GameOverMenu instance;
    private bool newBest;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameOver.gameObject.SetActive(false);
        yourScoreText.gameObject.SetActive(false);
        yourScore.gameObject.SetActive(false);
        newHighest.gameObject.SetActive(false);
        bestScoreText.gameObject.SetActive(false);
        bestScore.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (WhiteToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, Time.deltaTime * fadeSpeed));
            if (fadeScreen.color.a == 1)
            {
                
                WhiteToBlack = false;
                /////
                if (PlayerPrefs.HasKey("bestScore"))
                {
                    if (PlayerController.instance.Score > PlayerPrefs.GetInt("bestScore"))
                    {
                        PlayerPrefs.SetInt("bestScore", PlayerController.instance.Score);
                        newBest = true;
                    }
                }
                else PlayerPrefs.SetInt("bestScore", PlayerController.instance.Score);
                /////
                setValues();
                if(newBest) newHighest.gameObject.SetActive(true);
                UIController.instance.rightButton.gameObject.SetActive(false);
                UIController.instance.leftButton.gameObject.SetActive(false);
                setActiveAll();

            }
        }
        else if (BlackToWhite)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, Time.deltaTime * (fadeSpeed - 0.5f)));
            if (fadeScreen.color.a == 0) BlackToWhite = false;
        }
    }

    public void BlackToWhiteFunc()
    {
        WhiteToBlack = false;
        BlackToWhite = true;
    }
    public void WhiteToBlackFunc()
    {
        BlackToWhite = false;
        WhiteToBlack = true;
        fadeScreen.gameObject.SetActive(true);
    }
    public void setActiveAll()
    {
        gameOver.gameObject.SetActive(true);
        yourScoreText.gameObject.SetActive(true);
        yourScore.gameObject.SetActive(true);
        bestScoreText.gameObject.SetActive(true);
        bestScore.gameObject.SetActive(true);
        playAgain.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(true);
    }
    public void setUnactiveAll()
    {
        gameOver.gameObject.SetActive(false);
        yourScoreText.gameObject.SetActive(false);
        yourScore.gameObject.SetActive(false);
        newHighest.gameObject.SetActive(false);
        bestScoreText.gameObject.SetActive(false);
        bestScore.gameObject.SetActive(false);
        playAgain.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(false);
    }
    public void setValues()
    {
        yourScore.text = "" + PlayerController.instance.Score;
        bestScore.text = "" + PlayerPrefs.GetInt("bestScore");
    }
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
