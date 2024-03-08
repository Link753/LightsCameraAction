using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Animator animator;
    GameObject rawImage;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rawImage = transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsActive", true);
            rawImage.SetActive(true);
        }
        else
        {
            animator.SetBool("IsActive", false);
            rawImage.SetActive(false);
        }
    }
}
