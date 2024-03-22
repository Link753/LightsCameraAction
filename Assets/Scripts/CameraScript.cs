using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    RaycastHit hit;
    int imageNo, MaxpictureCount;
    Animator animator;
    [SerializeField] Transform ViewPicture;
    [SerializeField] Values Values;
    [SerializeField] GameObject DefaultViewPort ,CameraViewPort, DefaultCamera, ViewCamera;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MaxpictureCount = 10;
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

        if(imageNo > MaxpictureCount)
        {
            imageNo = 0;
        }
    }

    void CaptureImage()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        for(int i = 0; i < MaxpictureCount; i++)
        {
            if(SaveSystem.LoadPicture(i) == null)
            {
                imageNo = i;
                SaveData SD = new(hit.collider.gameObject.GetComponent<FloorData>().GenFloorData(imageNo, transform, transform.parent));
                SaveSystem.Save(SD, false);
                break;
            }
        }
    }

    void LoadImage(int ImageNo)
    {
        for (int i = 0; i < ViewPicture.transform.childCount; i++)
        {
            Destroy(ViewPicture.transform.GetChild(i).gameObject);
        }

        SaveData SD;
        Debug.Log(imageNo);
        if(SaveSystem.LoadPicture(ImageNo) == null)
        {
            if(imageNo > MaxpictureCount)
            {
                LoadImage(imageNo++);
            }
            else
            {
                LoadImage(0);
            }
        }
        else
        {
            DefaultViewPort.SetActive(false);
            DefaultCamera.SetActive(false);
            ViewCamera.SetActive(true);
            CameraViewPort.SetActive(true);
            SD = SaveSystem.LoadPicture(imageNo);
            Debug.Log(SD.CamRot[1]);
            Instantiate(Values.GetLevel(SD.RoomName), ViewPicture);
            ViewCamera.transform.parent = null;
            ViewCamera.transform.position = new Vector3(SD.CamPos[0], SD.CamPos[1] - 50, SD.CamPos[2]);
            ViewCamera.transform.rotation = Quaternion.Euler(new Vector3(SD.CamRot[0], SD.CamRot[1], SD.CamRot[2]));
        }
    }
}
