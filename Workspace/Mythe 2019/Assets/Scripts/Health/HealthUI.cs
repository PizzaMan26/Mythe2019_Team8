using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Health Player;
    private Text HealthText;

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

    private void Die()
    {
        Debug.Log("BE GONE BOT!");
    }
}
