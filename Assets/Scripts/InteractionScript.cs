using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    RaycastHit hit = new();
    [SerializeField]GameObject InteractableTEXT;
    [SerializeField]GameObject Interactables;
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);
        Physics.Raycast(transform.position, transform.forward, out hit, 3);
        if(hit.transform.gameObject.layer == 3)
        {
            InteractableTEXT.SetActive(true);
        }
        else
        {
            InteractableTEXT.SetActive(false);
        }
    }
}
