using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8f;
    public float jumpSpeed;
    public float gravity;
    private float dY;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*private void OnCollisionStay(Collision collision)
    {
        GameObject parentname = collision.gameObject;
        if (parentname.transform.parent.name == "Platforms")
            isGrounded = true;
        Debug.Log("touching something");

    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }*/
    // Update is called once per frame
    void Update()
    {
        Vector3 moveto = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dY = jumpSpeed;
            }
        }
        dY -= gravity * Time.deltaTime;
        moveto.y = dY;
        controller.Move(moveto * speed * Time.deltaTime);
    }
}
