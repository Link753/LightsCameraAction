using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    RaycastHit hit;
    int imageNo;
    bool[] pictures;
    Animator animator;
    [SerializeField] Transform ViewPicture;
    [SerializeField] Values Values;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pictures = new bool[3];
        pictures[0] = false;
        pictures[1] = false;
        pictures[2] = false;
        imageNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            animator.SetBool("IsActive", true);
            if (Input.GetMouseButtonUp(0))
            {
                CaptureImage();
            }
            if (Input.GetMouseButtonUp(1))
            {
                LoadImage(imageNo);
                Debug.Log(imageNo);
                imageNo++;
            }
        }
        else
        {
            animator.SetBool("IsActive", false);
        }

        if(imageNo > 2)
        {
            imageNo = 0;
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
        hit.collider.gameObject.GetComponent<FloorData>().GenFloorData(imageNo, transform);
    }

    void LoadImage(int ImageNo)
    {
        Debug.Log(imageNo);
        FloorData FD = new();
        FD = SaveSystem.LoadPicture(ImageNo);
        FD.LoadData(FD);
        FD.RecreateRoom(transform, ViewPicture);
    }
}
