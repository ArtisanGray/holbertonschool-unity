using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followObject;
    public Vector3 cameraOffset;
    private Vector3 rotateCamera;
    public float Sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - followObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity;
        cameraOffset = (Quaternion.AngleAxis(mouseX, Vector3.up) * cameraOffset);
        Vector3 Follow = followObject.transform.position + cameraOffset;
        transform.position = Follow;
        transform.LookAt(followObject.transform.position);
    }
}
