using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Switch_Sides : MonoBehaviour
{
    private Vector3 boxSize;
    //list of levels
    [SerializeField]private List<GameObject> levels = new List<GameObject>();
    
     private int nextSide = 1;
     private int currentSide = 0;
     private int previousSide = 3;
    public Action goDown; 
    public Action goUp; 
    //refrence to player
    [SerializeField] private GameObject player;
    void Start()
    {
        boxSize = GetComponent<Collider>().bounds.size;
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

        void Update()
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

        if(player.transform.position.x < -boxSize.x/ 2)
        {
            transform.localRotation = Quaternion.Euler(0, 90 * previousSide, 0);
            currentSide = previousSide;

            DestroyRocks();//Destroyes all rocks in scene

            //loads prvious level and unloads next
            levels[currentSide].active = true;
            levels[nextSide].active = false;
            levels[previousSide].active = true;
            //spawns player add the far right edge of the cube
            player.transform.position = new Vector3((boxSize.x/2), player.transform.position.y, player.transform.position.z);
            goDown();
        }


    }

    private void DestroyRocks()//Destroyes all rocks in scenes
    {
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");
        foreach (GameObject rock in rocks)
            Destroy(rock);
    }

 


}
