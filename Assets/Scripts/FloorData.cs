using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorData : MonoBehaviour
{
    GameObject RoomPrefab;
    int ImageNumber;
    float[] CamCoords, CamRotation;
    // Start is called before the first frame update
    void Start()
    {
        CamCoords = new float[3];
        CamRotation = new float[3];
    }

    public void SetData(GameObject RoomPrefab, int ImageNo, float[] CamCoords, float[] CamRotation)
    {

    }

    public void Savethis()
    {

    }
}
