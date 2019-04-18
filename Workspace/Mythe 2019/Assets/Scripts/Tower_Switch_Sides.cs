using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Switch_Sides : MonoBehaviour
{
    private Vector3 boxSize;
    //list of levels
    [SerializeField]private List<GameObject> levels = new List<GameObject>();
    [SerializeField] private List<Collider> towerPartsColliders = new List<Collider>();
     private int nextSide = 1;
     private int currentSide = 0;
     private int previousSide = 3;
     private int currentpart = 0;

    private int temp = 0;

    public Action goDown; 
    public Action goUp; 
    //refrence to player
    [SerializeField] private GameObject player;
    void Start()
    {
        boxSize = towerPartsColliders[0].bounds.size;
        //unloads all levels
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].active = false;
        }
        //loads  current level and unloads previous level
        levels[currentSide].active = true;
        levels[nextSide].active = true;
        levels[previousSide].active = false;
    }

    void FixedUpdate()
    {

        ChangePart();
        
        ChangeSide();

        //sorry dat het zo slecht geschreven is maar dit is het systeem die andere levels zal deactivaten en ik had maar 1 uur
        if (currentSide == 0)
        {
            levels[0].active = true;
            levels[1].active = false;
            levels[2].active = false;
            levels[3].active = false;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if(currentSide == 1)
        {
            levels[0].active = false;
            levels[1].active = true;
            levels[2].active = false;
            levels[3].active = false;
        }
        else if(currentSide == 2)
        {
            levels[0].active = false;
            levels[1].active = false;
            levels[2].active = true;
            levels[3].active = false;
        }
        else if(currentSide == 3)
        {
            levels[0].active = false;
            levels[1].active = false;
            levels[2].active = false;
            levels[3].active = true;
        }


    }

    public void OutsideChangeSide(int side)
    {
        currentSide = side;        
    }

    void ChangeSide()
    {
        //updates the next and preveous side

        nextSide = currentSide + 1;
        previousSide = currentSide - 1;
        //makes sides loop
        if (nextSide >= 4) nextSide = 0;
        if (previousSide < 0) { previousSide = 3; }
        if (player.transform.position.x> boxSize.x/2)
        {
            transform.localRotation = Quaternion.Euler(0, 90 * nextSide, 0);
            currentSide = nextSide;

            DestroyRocks();//Destroyes all rocks in scene

            //loads next level and unloads previous 
            levels[currentSide].active = true;
            levels[nextSide].active = true;
            levels[previousSide].active = false;
            //spawns player add the far left edge of the cube
            player.transform.position = new Vector3((-boxSize.x / 2) + 8f, player.transform.position.y, player.transform.position.z);
            goUp();
        }

        if (player.transform.position.x < -boxSize.x / 2)
        {
            transform.localRotation = Quaternion.Euler(0, 90 * previousSide, 0);
            currentSide = previousSide;

            DestroyRocks();//Destroyes all rocks in scene

            //loads prvious level and unloads next
            levels[currentSide].active = true;
            levels[nextSide].active = false;
            levels[previousSide].active = true;
            //spawns player add the far right edge of the cube
            player.transform.position = new Vector3((boxSize.x / 2), player.transform.position.y, player.transform.position.z);
            goDown();
        }
    }

    public void ChangePart()
    {
        boxSize = towerPartsColliders[currentpart].bounds.size;
        if (player.transform.position.y > towerPartsColliders[currentpart].gameObject.transform.position.y + (boxSize.y/2))
        {
            if (currentpart != towerPartsColliders.Count -1)
            {
                currentpart++;
            }
            
        }
        
    }

    private void DestroyRocks()//Destroyes all rocks in scenes
    {
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach (GameObject rock in rocks)
            Destroy(rock);
    }
}
