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
        for (int i = 0; i < 4; i++)
        {
            activeLevels.Add(allLevels[Random.Range(0, allLevels.Length)]);
        }
        //loads starting level
        int temp = 1;
        for (int i = 0; i < activeLevels.Count; i++)
        {

            switch (temp)
            {
                case 1:
                    Instantiate(activeLevels[index], new Vector3(0, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, 0), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;

                case 2:
                    Instantiate(activeLevels[index], new Vector3(activeLevels[index].transform.localScale.x * 0.5f, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, activeLevels[index].transform.localScale.x * 0.5f), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;

                case 3:
                    print(temp);
                    Instantiate(activeLevels[index], new Vector3(0, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, 21), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;

                case 4:
                    print(temp);
                    Instantiate(activeLevels[index], new Vector3(-(activeLevels[index].transform.localScale.x) * 0.5f, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, activeLevels[index].transform.localScale.x * 0.5f), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;
            }

            if (temp % 5 == 0)
                temp = 0;


            index++;

        }
    }

    void Update()
    {
        //if (Input.anyKeyDown)
        StageUp();
    }

    void StageUp()
    {
        //adds new level 
        //spawnes new level



        int temp = 1;
        for (int i = 0; i < 4; i++)
        {
            activeLevels.Add(allLevels[Random.Range(0, 3)]);
            switch (temp)
            {
                case 1:
                    Instantiate(activeLevels[index], new Vector3(0, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, 0), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;

                case 2:
                    Instantiate(activeLevels[index], new Vector3(activeLevels[index].transform.localScale.x * 0.5f, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, activeLevels[index].transform.localScale.x * 0.5f), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;

                case 3:
                    print(temp);
                    Instantiate(activeLevels[index], new Vector3(0, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, 21), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;

                case 4:
                    print(temp);
                    Instantiate(activeLevels[index], new Vector3(-(activeLevels[index].transform.localScale.x) * 0.5f, 0 + (activeLevels[index].transform.localScale.y * 0.25f) * index, activeLevels[index].transform.localScale.x * 0.5f), Quaternion.Euler(0f, -90f * index, 0f));
                    temp++;
                    break;
            }

            if (temp % 5 == 0)
                temp = 0;





            index++;
            print(index);
        }
    }
}