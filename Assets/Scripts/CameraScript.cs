using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    RaycastHit hit;
    string curFloor;
    bool IsCapturing;
    Animator animator;
    [SerializeField] GameObject[] Interactables;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsCapturing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsActive", true);
        }
        else
        {
            animator.SetBool("IsActive", false);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetAxis("Fire1") == 1 & !IsCapturing)
        {
            IsCapturing = true;
            CaptureImage();
        }
    }

    void CaptureImage()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        if(hit.collider != null)
        {
            curFloor = hit.collider.gameObject.name;
        }
        //get floor ID
        //save all interactables
        IsCapturing = false;
    }

    void LoadImage()
    {
        //get floor ID
        //load all interactables
    }
}
