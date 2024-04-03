using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f, xmove, zmove;
    [SerializeField] Transform Camera;
    [SerializeField] GameObject PauseMenu;
    Vector3 move = new();

    private void Awake()
    {
        string path = Application.persistentDataPath + "/Save.save";
        if (File.Exists(path))
        {
            PlayerData PD = SaveSystem.LoadPlayer();
            transform.position = new(PD.PlayerPos[0], PD.PlayerPos[1], PD.PlayerPos[2]);
            transform.localRotation = Quaternion.Euler(PD.PlayerRot[0], PD.PlayerRot[1], PD.PlayerRot[2]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        xmove = 0f;
        zmove = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        xmove = Input.GetAxis("Horizontal");
        zmove = Input.GetAxis("Vertical");

        move = transform.right * xmove + transform.forward * zmove;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);
            if (PauseMenu.activeSelf)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colliding");
        if(collision.collider.gameObject.layer == 8)
        {
            if (collision.collider.gameObject.GetComponent<EntityScript>().isAgro())
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                collision.collider.gameObject.GetComponent<EntityScript>().Teleport();
            }
        }
    }
}
