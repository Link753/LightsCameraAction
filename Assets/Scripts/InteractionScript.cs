using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    RaycastHit hit = new();
    [SerializeField]GameObject InteractableTEXT;
    [SerializeField]GameObject Interactables;
    InteractionReaction potentialInteraction;
    bool ifHit;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
        ifHit = Physics.Raycast(transform.position, transform.forward, out hit, 3);
        if (ifHit)
        {
            if (hit.transform.gameObject.layer == 3)
            {
                InteractableTEXT.SetActive(true);
                potentialInteraction = hit.transform.gameObject.GetComponent<InteractionReaction>();
            }
            else
            {
                InteractableTEXT.SetActive(false);
                potentialInteraction = null;
            }
        }
        else
        {
            potentialInteraction = null;
            InteractableTEXT.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            potentialInteraction.Dointeraction();
        }
    }
}
