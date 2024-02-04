using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionReaction : MonoBehaviour
{
    [SerializeField] bool isMovable;
    [SerializeField] bool hasAnimation;
    [SerializeField] bool isInventoryItem;
    Animator anim = new();

    private void Start()
    {
        if (GetComponent<Animator>())
        {
            anim = GetComponent<Animator>();
        }
    }

    public void Dointeraction()
    {
        if (isMovable)
        {
            if (transform.parent)
            {
                transform.SetParent(null);
            }
            else
            {
                transform.SetParent(GameObject.Find("Main Camera").transform);
            }
        }
        else if (hasAnimation)
        {

        }
        else if (isInventoryItem)
        {

        }
    }
}
