using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField]
    private Languages language;

    [Header("Audio files, select accordingly to the selected language.")]

    public AudioClip Attack, Back, Death;
    
    // Return language
    public Languages GetLanguage()
    {
        return language;
    }
}
