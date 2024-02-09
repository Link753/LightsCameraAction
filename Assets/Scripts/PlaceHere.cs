using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHere : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] LayerMask KeyMask;
    [Header("Connections")]
    [SerializeField] GameObject[] connectedObjects;
    [SerializeField] GameObject[] AnimatedObjects;
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
        if(collision.collider.gameObject.layer == 6 || collision.collider.gameObject.layer == 7)
        {
            foreach (GameObject g in connectedObjects)
            {
                g.SetActive(true);
            }

            foreach(GameObject g in AnimatedObjects)
            {
                g.GetComponent<Animator>();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (GameObject g in connectedObjects)
        {
            g.SetActive(false);
        }
    }

}
