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
    [SerializeField] GameObject DefaultViewPort ,CameraViewPort, DefaultCamera, ViewCamera;
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
        SaveData SD = new(hit.collider.gameObject.GetComponent<FloorData>().GenFloorData(imageNo, transform));
        SaveSystem.Save(SD, false);
    }

    void LoadImage(int ImageNo)
    {
        DefaultViewPort.SetActive(false);
        DefaultCamera.SetActive(false);
        ViewCamera.SetActive(true);
        CameraViewPort.SetActive(true);

        Debug.Log(imageNo);
        SaveData SD = SaveSystem.LoadPicture(ImageNo);
        for(int i = 0; i<ViewPicture.transform.childCount;i++)
        {
            Destroy(ViewPicture.transform.GetChild(i).gameObject);
        }
        Instantiate(Values.GetLevel(SD.RoomName), ViewPicture);
        ViewCamera.transform.parent = null;
        ViewCamera.transform.position = new Vector3(SD.CamPos[0], SD.CamPos[1] - 50, SD.CamPos[2]);
        ViewCamera.transform.eulerAngles = new Vector3(SD.CamRot[0], SD.CamRot[1], SD.CamRot[2]);
    }
}
