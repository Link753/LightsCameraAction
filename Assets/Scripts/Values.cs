using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour
{
    [SerializeField] GameObject[] Levels;
    [SerializeField] Transform Player;
    int CameraBatteryLevel, takenPictures, flagsSet;

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

    public void CameraProperties(int batlevel, int picturecount)
    {
        CameraBatteryLevel = batlevel;
        takenPictures = picturecount;
    }

    public void updateflagCount(int flags)
    {
        flagsSet = flags;
    }

    public int[] GetValues()
    {
        int[] Return = new int[3];
        Return[0] = CameraBatteryLevel;
        Return[1] = takenPictures;
        Return[2] = flagsSet;
        return Return;
    }

    public Transform GetPlayer()
    {
        return Player;
    }
}
