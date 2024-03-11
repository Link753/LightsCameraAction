using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public string ObjectName, floorLevel;
    public float[] coords = new float[3];
    RaycastHit hit;
    private void Awake()
    {
        Physics.Raycast(transform.position, -transform.up, out hit, 100);
        floorLevel = hit.collider.gameObject.name;
        ObjectName = transform.name;
    }
    private void Update()
    {
        coords[0] = transform.position.x;
        coords[1] = transform.position.y;
        coords[2] = transform.position.z;
    }
}
