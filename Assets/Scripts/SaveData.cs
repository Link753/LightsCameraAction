using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

    bool isPlayerData;
    float[] CamPos, CamRot;
    GameObject Room;
    public int imageNo;

    public SaveData(FloorData data)
    {
        Room = data.RoomPrefab;
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
