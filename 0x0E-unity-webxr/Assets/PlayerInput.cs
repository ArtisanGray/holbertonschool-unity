using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float velocity = 4.0f;
    public float playerSensitivity = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * playerSensitivity;
        transform.Rotate(Vector3.up * mouseX);

        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveForward = transform.parent.forward * verticalInput;
        transform.parent.Translate(moveForward * velocity * Time.deltaTime, Space.World);
    }
}
