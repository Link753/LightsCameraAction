using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 12f, xmove, zmove;
    Vector3 move = new();
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
