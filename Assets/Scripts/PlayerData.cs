using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int CameraBatteryLevel, takenPictures, flagsSet;
    public PlayerData(int camBatLevel, int taken, int flagNO)
    {
        CameraBatteryLevel = camBatLevel;
        takenPictures = taken;
        flagsSet = flagNO;
        SaveSystem.Save(this);
    }
}
