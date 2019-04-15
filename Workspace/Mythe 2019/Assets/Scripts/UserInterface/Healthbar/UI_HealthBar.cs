using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    [SerializeField]
    private int maximumHealth;

    private int currentHealth;

    [SerializeField]
    private Text txt_curHealth, txt_maxHealth;

    private Health playerHealth;

    private GameObject Player;

    [SerializeField]
    private GameObject Input_Pause,GameOver,Input_Handler;

    public int MaximumHealth {
        set {
            maximumHealth = value;
            txt_maxHealth.text = maximumHealth.ToString();
        }
    }

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        playerHealth.playerHit += SetHealth;
        playerHealth.playerDead += Die;
    }

    void SetHealth(int amount)
    {
        currentHealth = amount;
        if (currentHealth < 0) currentHealth = 0;
        
        txt_curHealth.text = currentHealth.ToString();
    }

    private void Die()//Disables scripts and UI element and ends the run
    {
        //Die animation
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<Dash>().enabled = false;
        //if(Animation.play(0)){
        gameObject.SetActive(false);
        Input_Pause.SetActive(false);
        Input_Handler.SetActive(false);
        GameOver.SetActive(true);
        //}

    }
}
