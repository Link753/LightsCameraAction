using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

    public bool isUsingFlash;
    public float[] CamPos, RoomPos; 
    public float CamRot;
    public string RoomName;
    public int imageNo;

    public SaveData(FloorData data)
    {
        RoomPos = data.RoomCoords;
        RoomName = data.RoomPrefab;
        CamPos = data.CamCoords;
        CamRot = data.CamRotation;
        imageNo = data.ImageNumber;
        isUsingFlash = data.isUsingFlash;
    }

    public void SaveThis()
    {
        SaveSystem.Save(this);
    }

}
