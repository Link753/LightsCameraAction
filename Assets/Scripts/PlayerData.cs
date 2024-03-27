using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public int CameraBatteryLevel, takenPictures, flagsSet;
    public float[] PlayerPos, PlayerRot;
    public PlayerData(int camBatLevel, int taken, int flagNO, Transform Player)
    {
        PlayerPos = new float[3];
        PlayerRot = new float[3];
        PlayerPos[0] = Player.position.x;
        PlayerPos[1] = Player.position.y;
        PlayerPos[2] = Player.position.z;
        PlayerRot[0] = Player.rotation.x;
        PlayerRot[1] = Player.rotation.y;
        PlayerRot[2] = Player.rotation.z;
        CameraBatteryLevel = camBatLevel;
        takenPictures = taken;
        flagsSet = flagNO;
        SaveSystem.Save(this);
    }
}
