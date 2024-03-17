using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

    bool isPlayerData;
    float[] CamPos, CamRot;
    string RoomName;
    public int imageNo;

    public SaveData(FloorData data)
    {
        RoomName = data.RoomPrefab;
        CamPos = data.CamCoords;
        CamRot = data.CamRotation;
        imageNo = data.ImageNumber;
        isPlayerData = false;
        SaveThis();
    }

    public SaveData()
    {

    }

    public void SaveThis()
    {
        SaveSystem.Save(this, isPlayerData);
    }

}
