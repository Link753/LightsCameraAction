using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    RaycastHit hit;
    int imageNo, MaxpictureCount, takenPhotos, timesLookedatEntity, CameraBatteryLevel;
    Animator animator;
    [SerializeField] Transform ViewPicture;
    [SerializeField] Values Values;
    [SerializeField] GameObject DefaultViewPort ,CameraViewPort, DefaultCamera, ViewCamera;
    Transform TeleportPoints;

    private void Awake()
    {
        string path = Application.persistentDataPath + ("/Save.save");
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        takenPhotos = dir.GetFiles().Length;
        if (File.Exists(path))
        {
            PlayerData PD = SaveSystem.LoadPlayer();
            CameraBatteryLevel = PD.CameraBatteryLevel;
            takenPhotos++;
        }
        Debug.Log(takenPhotos);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        MaxpictureCount = 10;
        imageNo = 0;
        timesLookedatEntity = 0;
        takenPhotos = 1;
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
            if (Input.GetMouseButtonUp(1) && takenPhotos != 0)
            {
                LoadImage(imageNo);
                Debug.Log(imageNo);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (SaveSystem.RemovePhoto(imageNo) == 1)
                {
                    takenPhotos--;
                }
            }
            if (Input.GetKey(KeyCode.Q))
            {
                DefaultViewPort.SetActive(true);
                DefaultCamera.SetActive(true);
                ViewCamera.SetActive(false);
                CameraViewPort.SetActive(false);
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
        TeleportPoints = hit.collider.gameObject.transform.parent.GetChild(0);
        for (int i = 0; i < MaxpictureCount; i++)
        {
            if(SaveSystem.LoadPicture(i) == null)
            {
                imageNo = i;
                SaveData SD = new(hit.collider.gameObject.GetComponent<FloorData>().GenFloorData(imageNo, transform, transform.parent));
                SaveSystem.Save(SD);
                takenPhotos++;
                break;
            }
        }

        Physics.Raycast(transform.position + transform.forward, transform.forward * 100, out hit);
        if (hit.collider.gameObject.GetComponent<EntityScript>())
        {
            timesLookedatEntity++;
            hit.collider.gameObject.GetComponent<EntityScript>().Teleport(TeleportPoints);
            if (timesLookedatEntity > 2)
            {
                hit.collider.gameObject.GetComponent<EntityScript>().ChangeStage(1);
            }
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
            Debug.Log(SD.CamRot);
            GameObject level = Instantiate(Values.GetLevel(SD.RoomName), ViewPicture);
            level.transform.position = new(SD.RoomPos[0], SD.RoomPos[1], SD.RoomPos[2]);
            ViewCamera.transform.parent = null;
            ViewCamera.transform.position = new Vector3(SD.CamPos[0], SD.CamPos[1] - 50, SD.CamPos[2]);
            ViewCamera.transform.localRotation = Quaternion.Euler(new Vector3(0, SD.CamRot, 0));
            imageNo++;
        }
    }
}
