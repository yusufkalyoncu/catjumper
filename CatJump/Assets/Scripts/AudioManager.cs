using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;
    public AudioSource jumpMusic;
    public AudioSource dieMusic;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerPrefs.SetInt("bestScore", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void JumpSound()
    {
        if (PlayerPrefs.GetInt("stopMusic") == 0)
        {
            jumpMusic.Stop();
            //jumpMusic.pitch = Random.Range(.9f, 1.2f);
            if (HealthController.instance.health > 0 && HealthController.instance.health <= 50) jumpMusic.pitch = 1.5f;
            if (HealthController.instance.health > 50 && HealthController.instance.health < 100) jumpMusic.pitch = 1.4f;
            if (HealthController.instance.health >= 100 && HealthController.instance.health <= 200) jumpMusic.pitch = Random.Range(1f, 1.3f);
            if (HealthController.instance.health > 200 && HealthController.instance.health <= 250) jumpMusic.pitch = Random.Range(.8f, 1f);
            if (HealthController.instance.health > 250 && HealthController.instance.health <= 400) jumpMusic.pitch = Random.Range(.8f, .65f);
            if (HealthController.instance.health > 400) jumpMusic.pitch = Random.Range(.6f, .5f);
            jumpMusic.Play();
        }

    }
    public void DieSound()
    {
        if(PlayerPrefs.GetInt("stopMusic") == 0)
        dieMusic.Play();
    }

}
