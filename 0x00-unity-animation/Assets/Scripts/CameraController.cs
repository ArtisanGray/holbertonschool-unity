using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity;
    private float _rotX;
    private float _rotY;
    public bool isInverted = false;
    //Vector3 lastCoord = Vector3.zero;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("InvertY"))
            isInverted = bool.Parse(PlayerPrefs.GetString("InvertY"));
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        //Vector3 mDelta = Input.mousePosition - lastCoord;

        _rotY += mouseX;
        if (isInverted)
            _rotX += mouseY;
        else
            _rotX += -mouseY;

        _rotX = Mathf.Clamp(_rotX, -60, 60);
        //if (mDelta.x < 0 || mDelta.x > 0)
        transform.localEulerAngles = new Vector3(_rotX, _rotY, 0);

        transform.position = target.position - transform.forward * 6.25f;
        //lastCoord = Input.mousePosition;
    }
}
