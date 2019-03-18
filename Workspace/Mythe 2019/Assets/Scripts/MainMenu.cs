using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load Game scene
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    // Exit application
    public void Exit()
    {
        Application.Quit();
    }

}
