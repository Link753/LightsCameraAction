using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorData : MonoBehaviour
{
    public string RoomPrefab;
    public int ImageNumber;
    public float[] CamCoords, RoomCoords;
    public float CamRotation;

    public FloorData GenFloorData(int ImageNo, Transform CamInfo, Transform player)
    {
        CamCoords = new float[3];
        RoomCoords = new float[3];
        RoomPrefab = transform.parent.name;
        RoomCoords[0] = transform.parent.position.x;
        RoomCoords[1] = transform.parent.position.y - 50;
        RoomCoords[2] = transform.parent.position.z;
        ImageNumber = ImageNo;
        CamCoords[0] = CamInfo.position.x;
        CamCoords[1] = CamInfo.position.y;
        CamCoords[2] = CamInfo.position.z;
        CamRotation = player.eulerAngles.y;
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
