using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Health Player;
    private Text HealthText;

    [SerializeField]
    private GameObject Input_Pause, InputHandler, GameOver;

    void Awake()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Health>();
        Player.playerHit += UpdateHealth;
        Player.playerDead += Die;
        HealthText = GetComponent<Text>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void UpdateHealth(int health)
    {
        HealthText.text = "Health: " + health;
    }

    private void Die()//Disables scripts and UI element and ends the run
    {
        //Die animation
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<Dash>().enabled = false;
        //if(Animation.play(0)){
        HealthText.enabled = false;
        Input_Pause.SetActive(false);
        InputHandler.SetActive(false);
        GameOver.SetActive(true);
        //}

    }
}
