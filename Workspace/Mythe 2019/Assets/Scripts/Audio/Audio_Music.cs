using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Music : MonoBehaviour
{
    private AudioManager audioManager;
    private float volume;

    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<AudioSource>().volume;
        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.Mute_Music += Mute;
        //audioManager.Change_Theme += ;
    }

    private void Mute(bool value)
    {
        if(value) GetComponent<AudioSource>().volume = 0;
        else GetComponent<AudioSource>().volume = volume;
    }



}
