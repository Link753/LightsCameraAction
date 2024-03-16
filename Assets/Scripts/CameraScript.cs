using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    RaycastHit hit;
    int imageNo;
    bool IsCapturing;
    bool[] pictures;
    Animator animator;
    [SerializeField] GameObject[] Interactables;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsCapturing = false;
        pictures = new bool[3];
        pictures[0] = false;
        pictures[1] = false;
        pictures[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsActive", true);
            if (Input.GetMouseButton(0))
            {
                IsCapturing = true;
                CaptureImage();
            }
        }
        else
        {
            animator.SetBool("IsActive", false);
        }
    }

    void CaptureImage()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        for(int i = 0; i < pictures.Length; i++)
        {
            if (!pictures[i])
            {
                imageNo = i;
                pictures[i] = true;
                break;
            }
        }
        hit.collider.gameObject.GetComponent<FloorData>().GenFloorData(imageNo, transform, hit.collider.gameObject.transform.parent.gameObject);
        IsCapturing = false;
    }

    void LoadImage()
    {
        //get floor ID
        //load all interactables
    }
}
