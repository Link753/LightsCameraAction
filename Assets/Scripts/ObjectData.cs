using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public string ObjectName, floorLevel;
    public float[] coords = new float[3];
    private void Awake()
    {
        coords[0] = transform.position.x;
        coords[1] = transform.position.y;
        coords[2] = transform.position.z;
    }
}
