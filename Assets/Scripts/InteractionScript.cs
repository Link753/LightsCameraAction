using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    RaycastHit hit = new();
    [SerializeField]GameObject InteractableTEXT;
    [SerializeField]GameObject Interactables, Holding;
    InteractionReaction potentialInteraction;
    bool ifHit;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
        ifHit = Physics.Raycast(transform.position, transform.forward, out hit, 3);
        if (ifHit)
        {
            if (hit.transform.gameObject.layer == 3 || hit.transform.gameObject.layer == 6)
            {
                InteractableTEXT.SetActive(true);
                potentialInteraction = hit.transform.gameObject.GetComponent<InteractionReaction>();
            }
            else
            {
                InteractableTEXT.SetActive(false);
            }
        }
        else
        {
            potentialInteraction = null;
            InteractableTEXT.SetActive(false);
        }

        if(Holding.transform.childCount != 0)
        {
            potentialInteraction = Holding.transform.GetChild(0).GetComponent<InteractionReaction>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (potentialInteraction)
            {
                potentialInteraction.Dointeraction();
            }
            potentialInteraction = null;
        }
    }
}
