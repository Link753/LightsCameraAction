using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHere : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] bool DoesDeactivate;
    [SerializeField] bool PlayerActivated;
    [Header("Connections")]
    [SerializeField] GameObject[] connectedObjects;
    [SerializeField] GameObject[] AnimatedObjects;
    bool isActivated;
    bool flagset;
    // Start is called before the first frame update
    void Start()
    {
        isActivated = false;
        flagset = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") & !isActivated & PlayerActivated)
        {
            foreach(GameObject g in AnimatedObjects)
            {
                g.GetComponent<Animator>().SetTrigger("isActive");
            }
            foreach(GameObject g in connectedObjects)
            {
                g.SetActive(true);
            }
            isActivated = true;
            flagset = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if((collision.collider.gameObject.layer == 3 || collision.collider.gameObject.layer == 7) & !PlayerActivated)
        {
            foreach (GameObject g in connectedObjects)
            {
                if (DoesDeactivate)
                {
                    g.SetActive(false);
                }
                else
                {
                    g.SetActive(true);
                }
            }
            flagset = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (GameObject g in connectedObjects)
        {
            g.SetActive(false);
        }
    }

    public void SetFlag(bool SettoThis)
    {
        flagset = SettoThis;
        foreach (GameObject g in AnimatedObjects)
        {
            g.GetComponent<Animator>().SetTrigger("isActive");
        }
        foreach (GameObject g in connectedObjects)
        {
            g.SetActive(true);
        }
        isActivated = true;
    }

    public bool GetFlag()
    {
        return flagset;
    }

}
