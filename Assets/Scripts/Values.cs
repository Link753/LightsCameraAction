using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour
{
    [SerializeField] GameObject[] Levels;

    public GameObject GetLevel(string levelname)
    {
        foreach(GameObject g in Levels)
        {
            if(g.name == levelname)
            {
                return g;
            }
        }
        return null;
    }
}
