using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity;
    private float _rotX;
    private float _rotY;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        _rotY += mouseX;
        _rotX += -mouseY;

        _rotX = Mathf.Clamp(_rotX, -60, 60);
        transform.localEulerAngles = new Vector3(_rotX, _rotY, 0);
        transform.position = target.position - transform.forward * 6.25f;
    }
}
