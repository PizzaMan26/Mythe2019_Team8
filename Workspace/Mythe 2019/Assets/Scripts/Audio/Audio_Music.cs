using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio_Music : MonoBehaviour
{
    private AudioManager audioManager;
    private float volume = 1;
    private bool whatTheme = false;

    [SerializeField]
    private AudioSource Source1, Source2;


    [SerializeField]
    private GameObject MusicButton;
    [SerializeField]
    private Sprite sprMusicOn, sprMusicOff;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Mute_Music += Mute;
        audioManager.Change_Theme += SwitchTheme;
    }

    private void Mute(bool value)
    {
        Source1.mute = value;
        Source2.mute = value;

        if (value) MusicButton.GetComponent<Image>().sprite = sprMusicOff;
        else MusicButton.GetComponent<Image>().sprite = sprMusicOn;
    }

    void Update()
    {
        if (whatTheme == true)
        {
            Source1.volume -= 0.01f;
            if (Source2.volume < volume) Source2.volume += 0.01f;
        }
        else
        {
            if (Source1.volume < volume) Source1.volume += 0.01f;
            Source2.volume -= 0.01f;
        }
    }

    private void SwitchTheme()
    {
        whatTheme = !whatTheme;
    }

}
