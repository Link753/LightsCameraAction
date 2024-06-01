using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionReaction : MonoBehaviour
{
    [Header("Interactable")]
    [SerializeField] bool isMovable;
    [SerializeField] bool isSwitch;
    [SerializeField] bool isFused;
    [SerializeField] bool isPressureplate;
    [SerializeField] bool CanbeToggled;
    [SerializeField] bool PlayerActivated;
    [SerializeField] bool UsesCollision;
    [Header("Check Object")]
    [SerializeField] bool doesInteractwithEnvironment;
    [Header("For Switch")]
    [SerializeField] GameObject[] connectedObjects;
    [SerializeField] GameObject Fuse;
    [SerializeField] bool DoesDeactivate;
    [SerializeField] bool DoesSetFlag;
    [Header("For Objectives")]
    [SerializeField] string Objective;
    Animator anim = new();
    bool flagset, isActivated = false;
    Rigidbody body;

    private void Start()
    {
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
        
        flagset = false;
        body = GetComponent<Rigidbody>();
    }

    public void Dointeraction()
    {
        if (isMovable)
        {
            if (transform.parent)
            {
                transform.SetParent(null);
                body.isKinematic = false;
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
                //ifHit = Physics.Raycast(transform.position, transform.up, out hit); // meant to check if object is under the floor. doesnt work atm 07/02/2024
                //if (ifHit) most likely will never get resolved before submission deadline 08/04/2024
                //{
                //    if (hit.collider.name == "Floor")
                //    {
                //        transform.position = new Vector3(transform.position.x, hit.collider.transform.position.y + transform.localScale.y / 2, transform.position.z);
                //    }
                //}
            }
            else
            {
                transform.SetParent(GameObject.Find("Main Camera").transform);
                body.isKinematic = true;
            }
        }
        else if(isSwitch || isPressureplate & !flagset)
        {
            if (isFused & Fuse.activeSelf)
            {
                Activate();
            }
            else
            {
                foreach (GameObject g in connectedObjects)
                {
                    Activate();

                    if(g.name == "Door")
                    {
                        g.GetComponent<Animator>().SetBool("isopen", true);
                    }
                }
            }
            if (DoesSetFlag)
            {
                flagset = true;
            }
        }
    }

    void Activate()
    {
        foreach (GameObject g in connectedObjects)
        {
            if (g.activeSelf & CanbeToggled)
            {
                g.SetActive(!g.activeSelf);
            }
            else
            {
                g.SetActive(true);
            }
        }
    }

    public void setFlag(bool SetToThis)
    {
        flagset = SetToThis;
        Dointeraction();
    }

    public bool GetFlag()
    {
        return flagset;
    }

    public string GetObjective()
    {
        return Objective;
    }
    private void OnTriggerStay(Collider other)
    {
        if (UsesCollision)
        {
            if (other.CompareTag("Player") & !flagset & PlayerActivated)
            {
                Dointeraction();
                isActivated = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (UsesCollision)
        {
            if ((collision.collider.gameObject.layer == 3 || collision.collider.gameObject.layer == 7) & !PlayerActivated)
            {
                Activate();
                flagset = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Activate();
    }
}
