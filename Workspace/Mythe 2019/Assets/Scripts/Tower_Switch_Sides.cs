using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Switch_Sides : MonoBehaviour
{
    private bool goRight = false;
    private bool goLeft = false;
    private float currentRotation = 0;

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
        temp++;
        if (temp % 180 == 0)
        {
            ChangePart();
        }
        ChangeSide();
        if (goRight)
        {
            currentRotation += 1f;
            transform.localRotation = Quaternion.Euler(0, currentRotation * nextSide, 0);
            print(currentRotation);
            if (currentRotation == 90)
            {
                print("should stop go right");
                currentRotation = 0;
                goRight = false;
                currentSide = nextSide;
            }
        }
        if (goLeft)
        {
            currentRotation += 1f;
            transform.localRotation = Quaternion.Euler(0, currentRotation * previousSide, 0);
            if (currentRotation == 90)
            {
                print("should stop go right");
                currentRotation = 0;
                goLeft = false;
                currentSide = previousSide;
            }
        }

    }

    void ChangeSide()
    {
        //updates the next and preveous side

        nextSide = currentSide + 1;
        previousSide = currentSide - 1;
        //makes sides loop
        if (nextSide >= 4) nextSide = 0;
        if (previousSide < 0) { previousSide = 3; }


        if (player.transform.position.x > boxSize.x / 2)
        {
            goRight = true;

            //loads next level and unloads previous 
            levels[currentSide].active = true;
            levels[nextSide].active = true;
            levels[previousSide].active = false;
            //spawns player add the far left edge of the cube
            //player.transform.position = new Vector3((-boxSize.x / 2) + 8f, player.transform.position.y, player.transform.position.z);
            goUp();
        }

        if (player.transform.position.x < -boxSize.x / 2)
        {
            goLeft = true;


            //loads prvious level and unloads next
            levels[currentSide].active = true;
            levels[nextSide].active = false;
            levels[previousSide].active = true;
            //spawns player add the far right edge of the cube
            //player.transform.position = new Vector3((boxSize.x / 2), player.transform.position.y, player.transform.position.z);
            goDown();
        }
    }

    public void ChangePart()
    {

        boxSize = towerPartsColliders[currentpart].bounds.size;
        if (player.transform.position.y > boxSize.y/2)
        {
            print("higher");
            currentpart++;
        }
        
    }
}
