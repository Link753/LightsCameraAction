using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorData
{
    GameObject RoomPrefab;
    int ImageNumber;
    float[] CamCoords, CamRotation;

    public FloorData(int ImageNo, Transform CamInfo, GameObject Room)
    {
        CamCoords = new float[3];
        CamRotation = new float[3];
        RoomPrefab = Room;
        ImageNumber = ImageNo;
        CamCoords[0] = CamInfo.position.x;
        CamCoords[1] = CamInfo.position.y;
        CamCoords[2] = CamInfo.position.z;
        CamRotation[0] = CamInfo.rotation.x;
        CamRotation[1] = CamInfo.rotation.y;
        CamRotation[2] = CamInfo.rotation.z;
        SaveSystem.SavePicture(this, ImageNumber);
    }

    public void LoadImage(int ImageNo)
    {
        FloorData FD = SaveSystem.LoadPicture(ImageNo);
        FD.CamCoords = CamCoords;
        FD.CamRotation = CamRotation;
        FD.RoomPrefab = RoomPrefab;
        FD.ImageNumber = ImageNo;
    }
}
