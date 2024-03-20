using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorData : MonoBehaviour
{
    public string RoomPrefab;
    public int ImageNumber;
    public float[] CamCoords, CamRotation;

    public FloorData GenFloorData(int ImageNo, Transform CamInfo)
    {
        CamCoords = new float[3];
        CamRotation = new float[3];
        RoomPrefab = transform.parent.name;
        ImageNumber = ImageNo;
        CamCoords[0] = CamInfo.position.x;
        CamCoords[1] = CamInfo.position.y;
        CamCoords[2] = CamInfo.position.z;
        CamRotation[0] = CamInfo.rotation.x;
        CamRotation[1] = CamInfo.rotation.y;
        CamRotation[2] = CamInfo.rotation.z;
        return this;
    }

    public void LoadData(SaveData SD)
    {
        RoomPrefab = SD.RoomName;
        CamCoords = SD.CamPos;
        CamRotation = SD.CamRot;
        ImageNumber = 0;
    }

    public void RecreateRoom(Transform Camera, Transform parent)
    {
        Instantiate(GameObject.Find("ListOfLevels").GetComponent<Values>().GetLevel(RoomPrefab), parent);
    }
}
