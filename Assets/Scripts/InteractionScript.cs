using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    RaycastHit hit = new();

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
    }
}
