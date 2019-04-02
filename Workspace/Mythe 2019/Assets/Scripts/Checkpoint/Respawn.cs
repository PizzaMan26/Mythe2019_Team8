using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    private GameObject CheckpointManager;
    private GameObject Player;

    private Health health;
    [SerializeField]
    private Text HealthText;

    [SerializeField]
    private GameObject Input_Pause, InputHandler, GameOver;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        health = Player.GetComponent<Health>();
        CheckpointManager = GameObject.FindGameObjectWithTag("CheckpointManager");
        
    }

    public void RespawnButton()
    {
        if (CheckpointManager.GetComponent<CheckpointManager>().GetProgress() == -1)
        {
            Player.transform.position = new Vector3(-42, -14, -1.2f);
        }
        else
        {
            Vector3 pos = new Vector3(CheckpointManager.GetComponent<CheckpointManager>().GetCheckpoint().transform.position.x,
                                  CheckpointManager.GetComponent<CheckpointManager>().GetCheckpoint().transform.position.y,
                                  Player.transform.position.z);

            Player.transform.position = pos;
        }
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<Dash>().enabled = true;
        HealthText.enabled = true;
        Input_Pause.SetActive(true);
        InputHandler.SetActive(true);
        GameOver.SetActive(false);
        Player.GetComponent<Health>().DealDamage(-10);

    }
}
