using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

    string name, floorlevel;
    float[] coords = new float[3];

    public void SaveThis(ObjectData data)
    {
        name = data.name;
        floorlevel = data.floorLevel;
        coords = data.coords;
    }

}
