using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionReaction : MonoBehaviour
{
    [Header("Interactable")]
    [SerializeField] bool isMovable;
    [SerializeField] bool hasAnimation;
    [SerializeField] bool isInventoryItem;
    [SerializeField] bool isSwitch;
    [SerializeField] bool isFused;
    [SerializeField] bool CanbeToggled;
    [Header("Check Object")]
    [SerializeField] bool doesInteractwithEnvironment;
    [Header("For Switch")]
    [SerializeField] GameObject[] connectedObjects;
    [SerializeField] GameObject Fuse;
    [SerializeField] bool DoesDeactivate;
    Animator anim = new();
    Vector3 startingrotation;
    Rigidbody body;

    private void Start()
    {
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
        body = GetComponent<Rigidbody>();
        startingrotation = new(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void Update()
    {

    }

    public void Dointeraction()
    {
        if (isMovable)
        {
            if (transform.parent)
            {
                transform.SetParent(null);
                body.isKinematic = false;
                transform.rotation = Quaternion.Euler(startingrotation);
                //ifHit = Physics.Raycast(transform.position, transform.up, out hit); // meant to check if object is under the floor. doesnt work atm 07/02/2024
                //if (ifHit)
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
        else if (hasAnimation)
        {

        }
        else if (isInventoryItem)
        {

        }
        else if(isSwitch)
        {
            if (isFused)
            {
                if (Fuse.activeSelf)
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
            }
            else
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
        }
    }
}
