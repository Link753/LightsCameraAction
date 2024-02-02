using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float mouseX,mouseY,XRot = 0.0f;
    [SerializeField] float MouseSensitivity;
    [SerializeField] Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        mouseX = 0.0f;
        mouseY = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRot -= mouseY;
        XRot = Mathf.Clamp(XRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(XRot, 0f, 0f);
        Player.Rotate(Vector3.up * mouseX);
    }
}
