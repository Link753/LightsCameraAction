using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Values : MonoBehaviour
{
    [SerializeField] GameObject[] Levels;
    [SerializeField] GameObject[] Flags;
    [SerializeField] Transform Player;
    int CameraBatteryLevel, takenPictures, flagsSet;
    PlayerData PD;

    private void Start()
    {
        string path = Application.persistentDataPath + "/Save.save";
        if (File.Exists(path))
        {
            PD = SaveSystem.LoadPlayer();
            flagsSet = PD.flagsSet;
            for (int i = 0; i < flagsSet; i++)
            {
                if (Flags[i].GetComponent<InteractionReaction>())
                {
                    Flags[i].GetComponent<InteractionReaction>().setFlag(true);
                }
                else if (Flags[i].GetComponent<PlaceHere>())
                {
                    Flags[i].GetComponent<PlaceHere>().SetFlag(true);
                }
            }
        }
    }

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

    public void increaseflagCount()
    {
        flagsSet++;
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
