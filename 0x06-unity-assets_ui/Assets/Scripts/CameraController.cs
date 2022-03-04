using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followObject;
    public Vector3 cameraOffset;
    public float Sensitivity;
    public float MaxDeg;
    public bool isInverted;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraOffset = transform.position - followObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity;

        if (isInverted == true)
            mouseY *= -1;

        followObject.transform.Rotate(new Vector3(0, mouseX, 0));
        Quaternion mouseRotation = Quaternion.Euler(0, mouseX, 0);
        cameraOffset = mouseRotation * cameraOffset;
        Vector3 Follow = followObject.transform.position + cameraOffset;
        transform.position = Follow;
        transform.LookAt(followObject.transform.position);
    }
}
