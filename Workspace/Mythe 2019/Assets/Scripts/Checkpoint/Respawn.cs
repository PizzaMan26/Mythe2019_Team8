using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    private GameObject CheckpointManager, Player, Tower;

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
        Tower = GameObject.FindGameObjectWithTag("Tower");

    }

    public void RespawnButton()
    {
        if (CheckpointManager.GetComponent<CheckpointManager>().GetProgress() == -1)
        {
            Player.transform.position = new Vector3(-42, -14, -1.2f);
        }
        else
        {
            ResetGame();
        } 
    }

    private void ResetGame()
    {
        
        switch (CheckpointManager.GetComponent<CheckpointManager>().GetCheckpointSide())
        {
            case 0:
                Debug.Log("OOF!");
                break;
            case 1:
                Tower.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log("WEEEEE!1");
                break;
            case 2:
                Tower.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log("WEEEEE!2");
                break;
            case 3:
                Tower.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log("WEEEEE!3");
                break;
            case 4:
                Tower.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                Debug.Log("WEEEEE!4");
                break;
        }


        Vector3 pos = new Vector3(CheckpointManager.GetComponent<CheckpointManager>().GetPosition().x,
                                  CheckpointManager.GetComponent<CheckpointManager>().GetPosition().y, 
                                  Player.transform.position.z);
        Player.transform.position = pos;

        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<Dash>().enabled = true;
        HealthText.enabled = true;
        Input_Pause.SetActive(true);
        InputHandler.SetActive(true);
        GameOver.SetActive(false);
        Player.GetComponent<Health>().DealDamage(-10);

        
    }
}
