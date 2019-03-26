using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_Levels : MonoBehaviour
{
    [SerializeField]private List<Tower_Switch_Sides> _towerParts = new List<Tower_Switch_Sides>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _towerParts.Count; i++)
        {
            _towerParts[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
