using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

    public bool isPlayerData;
    public float[] CamPos, CamRot;
    public string RoomName;
    public int imageNo;

    public SaveData(FloorData data)
    {
        RoomName = data.RoomPrefab;
        CamPos = data.CamCoords;
        CamRot = data.CamRotation;
        Debug.Log(CamRot);
        imageNo = data.ImageNumber;
        isPlayerData = false;
    }

    public SaveData()
    {

    }

    public void SaveThis()
    {
        SaveSystem.Save(this, isPlayerData);
    }

}
