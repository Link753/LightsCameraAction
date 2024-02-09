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
    [Header("Check Object")]
    [SerializeField] bool doesInteractwithEnvironment;
    [Header("For Switch")]
    [SerializeField] GameObject[] connectedObjects;
    Animator anim = new();
    Rigidbody body;

    private void Start()
    {
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
        body = GetComponent<Rigidbody>();
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
            foreach(GameObject g in connectedObjects)
            {
                g.SetActive(!g.activeSelf);
            }
        }
    }
}
