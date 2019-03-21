using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private InputHandler inputHandler;
    [SerializeField]
    private GameObject Menu;


    void Start()
    {
        // Find GameObjects
        //Menu = GameObject.FindWithTag("PauseMenu");
        inputHandler = GameObject.FindWithTag("InputHandler").GetComponent<InputHandler>();
        // Attach Pause Delegate to function
        inputHandler.Pause += CheckPause;
    }

    void CheckPause(bool value)
    {
        if (value) EnablePauseMenu();
        else DisablePauseMenu();
    }

    void EnablePauseMenu()
    {
        Menu.SetActive(true);
        Time.timeScale = 0;
    }

    void DisablePauseMenu()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    } 

    public void ExitApplication()
    {
        Application.Quit();
    }

}
