using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource musicSource;
    public AudioSource soundSource;

    public AudioClip mainMenu, ingame;

    private string soundKey = "sound";
    private int sound;
    public int Sound
    {
        get
        {
            if (!PlayerPrefs.HasKey(soundKey))
            {
                PlayerPrefs.SetInt(soundKey, 1);
            }

            sound = PlayerPrefs.GetInt(soundKey);

            return sound;
        }
        set
        {
            sound = value;
            PlayerPrefs.SetInt(soundKey, sound);

            SetSound();
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSound();

        musicSource.clip = mainMenu;
        musicSource.Play();
    }

    void SetSound()
    {
        if (Sound == 0)
        {
            UIController.instance.soundOn.SetActive(false);
            UIController.instance.soundOff.SetActive(true);

            soundSource.volume = 0;
            musicSource.volume = 0;
        }
        else
        {
            UIController.instance.soundOn.SetActive(true);
            UIController.instance.soundOff.SetActive(false);

            soundSource.volume = 1;
            musicSource.volume = 1;
        }
    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "mainMenu":
                musicSource.clip = mainMenu;
                musicSource.Play();
                break;
            case "ingame":
                musicSource.clip = ingame;
                musicSource.Play();
                break;
        }
    }
}