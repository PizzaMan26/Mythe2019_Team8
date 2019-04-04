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

    public int MaximumHealth {
        set {
            maximumHealth = value;
            txt_maxHealth.text = maximumHealth.ToString();
        }
    }

    void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        playerHealth.playerHit += SetHealth;
    }

    void SetHealth(int amount)
    {
        currentHealth = amount;
        if (currentHealth < 0) currentHealth = 0;
        
        txt_curHealth.text = currentHealth.ToString();
    }
}
