using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Delegates
    public event Action<bool> Mute_Music, Mute_FX;
    public event Action Change_Theme;

    private bool Muted_Music_Status, Muted_FX_Status;
    

    void Start()
    {
        if (PlayerPrefs.HasKey("Audio_Muted_Music")) Boolean.TryParse(PlayerPrefs.GetString("Audio_Muted_Music"), out Muted_Music_Status);
        else
        {
            PlayerPrefs.SetString("Audio_Muted_Music", "False");
            Muted_Music_Status = false;
        }

        if (PlayerPrefs.HasKey("Audio_Muted_FX"))
        {
            if (PlayerPrefs.GetString("Audio_Muted_FX") == "True") Boolean.TryParse(PlayerPrefs.GetString("Audio_Muted_FX"), out Muted_FX_Status);
        }
        else
        {
            PlayerPrefs.SetString("Audio_Muted_FX", "False");
            Muted_FX_Status = false;
        }

        Mute_Music(Muted_Music_Status);
        Mute_FX(Muted_FX_Status);
    }

    public void MuteMusic()
    {
        // Change boolean to true if false, false if true
        Muted_Music_Status = !Muted_Music_Status;
        // Safe player settings
        PlayerPrefs.SetString("Muted_Music_Status", Muted_Music_Status.ToString());
        // Send delegate
        Mute_Music(Muted_Music_Status);
    }

    public void MuteFX()
    {
        // Change boolean to true if false, false if true
        Muted_FX_Status = !Muted_FX_Status;
        // Safe player settings
        PlayerPrefs.SetString("Audio_Muted_FX", Muted_FX_Status.ToString());
        // Send delegate
        Mute_FX(Muted_FX_Status);
    }

    public void ChangeTheme()
    {
        Change_Theme();
    }
}
