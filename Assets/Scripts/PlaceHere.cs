using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHere : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] LayerMask KeyMask;
    [Header("Connections")]
    [SerializeField] GameObject[] connectedObjects;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.layer == 6)
        {
            Debug.Log("Plate Active");
            ActivateAll();
        }
    }

    void ActivateAll()
    {
        foreach(GameObject g in connectedObjects)
        {
            g.GetComponents<MonoBehaviour>();
        }
    }
}
