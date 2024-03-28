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

    public void SavePlayer()
    {
        PlayerData PD = new(CameraBatteryLevel, takenPictures, flagsSet, Player);
        SaveSystem.Save(PD);
    }
}
