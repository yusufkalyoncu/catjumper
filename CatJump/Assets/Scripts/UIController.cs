using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Text scoreText;
    public bool tapToStart;
    public GameObject tapScreen;
    public Button rightButton, leftButton;
    [Header("BlackAndWhiteScreen")]
    public float fadeSpeed;
    public Image fadeScreen;
    public bool WhiteToBlack;
    public bool BlackToWhite;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !tapToStart)
        {
            tapToStart = true;
            Time.timeScale = 1f;
            tapScreen.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(true);
        }
        if (WhiteToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, Time.deltaTime * fadeSpeed));
            if (fadeScreen.color.a == 1) WhiteToBlack = false;
        }
        else if (BlackToWhite)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, Time.deltaTime * (fadeSpeed - 0.5f)));
            if (fadeScreen.color.a == 0) BlackToWhite = false;
        }
        scoreText.text = "Score : " + PlayerController.instance.Score;
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
    }

}
