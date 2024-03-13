using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorData : MonoBehaviour
{
    ObjectData[] thisFloorsData;
    // Start is called before the first frame update
    void Start()
    {
        thisFloorsData = new ObjectData[thisFloorsData.Length];
    }

    public void AddtoStack(ObjectData data)
    {
        thisFloorsData.Append(data);
    }

    public void Savethis()
    {
        SaveSystem.SaveObject(this, false);
    }
}
