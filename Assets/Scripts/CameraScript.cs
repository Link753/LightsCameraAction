using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    RaycastHit hit;
    int imageNo, MaxpictureCount, takenPhotos, CameraBatteryLevel;
    bool toggle, viewingMode, toggleflash;
    Animator animator;
    [SerializeField] Transform ViewPicture;
    [SerializeField] Values Values;
    [SerializeField] GameObject DefaultViewPort, CameraViewPort, DefaultCamera, ViewCamera, flash;
    [SerializeField] TMP_Text camDisplay, imageNodisplay;
    DirectoryInfo dir;

    private void Awake()
    {
        string path = Application.persistentDataPath + ("/Save.save");
        dir = new(Application.persistentDataPath);
        takenPhotos = dir.GetFiles().Length;
        imageNo = takenPhotos;
        if (File.Exists(path))
        {
            PlayerData PD = SaveSystem.LoadPlayer();
            CameraBatteryLevel = PD.CameraBatteryLevel;
            takenPhotos--;
            imageNo--;
        }
        else
        {
            CameraBatteryLevel = 100;
        }
        toggle = false;
        toggleflash = false;
        flash.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MaxpictureCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        camDisplay.text = "Battery: " + CameraBatteryLevel + "%";
        imageNodisplay.text = imageNo.ToString();
        if(Input.GetKeyUp(KeyCode.E))
        {
            toggle = !toggle;
        }

        if (toggle)
        {
            animator.SetBool("IsActive", true);
            if (Input.GetMouseButtonUp(1) && takenPhotos != 0)
            {
                LoadImage(imageNo);
                imageNo++;
                viewingMode = true;
            }

            if (Input.GetMouseButtonUp(0) & !viewingMode)
            {
                CaptureImage();
            }

            if (Input.GetKeyUp(KeyCode.F))
            {
                toggleflash = !toggleflash;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SaveSystem.RemovePhoto(imageNo);
                takenPhotos = dir.GetFiles().Length;
                imageNo = takenPhotos;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                DefaultViewPort.SetActive(true);
                DefaultCamera.SetActive(true);
                ViewCamera.SetActive(false);
                CameraViewPort.SetActive(false);
                viewingMode = false;
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

        if (toggleflash)
        {
            flash.SetActive(true);
        }
        else
        {
            flash.SetActive(false);
        }
    }

    void CaptureImage()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        for (int i = 0; i < MaxpictureCount; i++)
        {
            if(SaveSystem.LoadPicture(i) == null)
            {
                imageNo = i;
                SaveData SD = new(hit.collider.gameObject.GetComponent<FloorData>().GenFloorData(imageNo, transform, transform.parent));
                SaveSystem.Save(SD);
                takenPhotos++;
                CameraBatteryLevel -= 10;
                break;
            }
        }

        Physics.Raycast(transform.position + transform.forward, transform.forward * 100, out hit);
        if (hit.collider.gameObject.GetComponent<EntityScript>())
        {
            hit.collider.gameObject.GetComponent<EntityScript>().Teleport();
        }
    }

    public void Save()
    {
        Values.CameraProperties(CameraBatteryLevel, takenPhotos);
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
                imageNo = 0;
                LoadImage(imageNo);
            }
            else
            {
                imageNo++;
                LoadImage(imageNo);
            }
        }
        else
        {
            DefaultViewPort.SetActive(false);
            DefaultCamera.SetActive(false);
            ViewCamera.SetActive(true);
            CameraViewPort.SetActive(true);
            SD = SaveSystem.LoadPicture(imageNo);
            GameObject level = Instantiate(Values.GetLevel(SD.RoomName), ViewPicture);
            level.transform.position = new(SD.RoomPos[0], SD.RoomPos[1], SD.RoomPos[2]);
            ViewCamera.transform.parent = null;
            ViewCamera.transform.position = new Vector3(SD.CamPos[0], SD.CamPos[1] - 50, SD.CamPos[2]);
            ViewCamera.transform.localRotation = Quaternion.Euler(new Vector3(0, SD.CamRot, 0));
            if (SD.isUsingFlash)
            {
                ViewCamera.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                ViewCamera.transform.GetChild(0).gameObject.SetActive(false);
            }
            CameraBatteryLevel -= 5;
        }
    }

    public bool isFlashactive()
    {
        return toggleflash;
    }
}
