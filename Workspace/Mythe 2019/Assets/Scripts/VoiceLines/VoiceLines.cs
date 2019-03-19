using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Languages
{
    Afrikaans, Arabic, Cat, Chinese, DonaldDuck, Duck, Dutch, English,
    French, Georgian, German, Goofie, Hungarian, Italiaans, Japanese,
    Korean, MickeyMouse, Norwegian, Polish, Portugese, Russian, Spanish,
    Thai, Vietnamese
};

public class VoiceLines : MonoBehaviour
{
    [SerializeField]
    private List<Language> languageList = new List<Language>();
    private int enumCount;
    private AudioSource source;

    void Start()
    {
        enumCount = System.Enum.GetValues(typeof(Languages)).Length;
        source = GetComponent<AudioSource>();
    }

    // Return random enum
    Languages RandomLanguage()
    {
        return (Languages)Random.Range(0, enumCount);
    }

    public void PlayRandom()
    {
        PlayLanguage(RandomLanguage(), "Attack");
    }

    void PlayLanguage(Languages lang, string action)
    {
        int listId = -1;

        // Check where in the list the language matches
        for(int i = 0; i < enumCount; i++)
        {
            if(lang == languageList[i].GetLanguage())
            {
                listId = i;
                break;
            }
        }
        if (listId != -1)
        {
            // Play according to action
            switch (action)
            {
                case "Attack":
                    source.clip = languageList[listId].Attack;
                    break;
                case "Back":
                    source.clip = languageList[listId].Back;
                    break;
                case "Death":
                    source.clip = languageList[listId].Death;
                    break;
            }
            source.Play(0);
        }
        else Debug.Log("Could not find language");
    }

}
