using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f, xmove, zmove;
    [SerializeField] Transform Camera;
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

    }
}
