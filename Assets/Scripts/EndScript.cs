using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    [SerializeField] GameObject[] DisableAndAnimate;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ending");
        foreach(GameObject g in DisableAndAnimate)
        {
            g.GetComponent<MonoBehaviour>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
