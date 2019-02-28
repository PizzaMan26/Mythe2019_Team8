using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    //array width all prefabs
    public GameObject[] allLevels;
    //list of loaded prefabs
    private List<GameObject> activeLevels = new List<GameObject>();
    //keeps track of index
    int index = 0;

    private void Start()
    {
        //picks 3 starting levels
        for (int i = 0; i < 3; i++)
        {
            activeLevels.Add(allLevels[Random.Range(0, allLevels.Length)]);
        }
        //loads 3 starting levels
        for (int i = 0; i < activeLevels.Count; i++)
        {
            Instantiate(activeLevels[i], new Vector3(0, 0 + 25 * i, 0), Quaternion.identity);
            index++;
        }
    }
    
    /*void Update()
    {
        if (Input.anyKeyDown)
            StageUp();
    }*/

    void StageUp()
    {
        //adds new level 
        activeLevels.Add(allLevels[Random.Range(0, 3)]);
        
        //spawnes new level
        Instantiate(activeLevels[index], new Vector3(0, 0 + 25 * index, 0), Quaternion.identity);
        index++;
        print(index);

    }
}
