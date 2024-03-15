using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f, xmove, zmove;
    [SerializeField] Transform Camera;
    Vector3 move = new();
    bool[] pictureslots;
    int SelectedSlot;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        xmove = 0f;
        zmove = 0f;
        pictureslots = new bool[3];
        pictureslots[0] = false;
        pictureslots[1] = false;
        pictureslots[2] = false;
    }

    // Update is called once per frame
    void Update()
    {
        xmove = Input.GetAxis("Horizontal");
        zmove = Input.GetAxis("Vertical");

        move = transform.right * xmove + transform.forward * zmove;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            TakePicture();
        }
    }

    void TakePicture()
    {
        for(int i = 0;i < pictureslots.Length;i++)
        {
            if (!pictureslots[i])
            {
                SelectedSlot = i;
                pictureslots[i] = true;
            }
        }
        if(SelectedSlot == -1)
        {
            //display Something
        }
        else
        {
            Physics.Raycast(transform.position, -transform.up, out hit);
            FloorData FD = new FloorData(SelectedSlot, Camera, hit.collider.gameObject.transform.parent.gameObject);
            SaveSystem.SavePicture(FD, SelectedSlot);
            SelectedSlot = -1;
        }
    }
}
