using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject Camera;
    public float speed = 8f;
    public float jumpSpeed;
    public float gravity;
    private float dY = 0;
    private Animator charAnim;
    // Start is called before the first frame update
    void Start()
    {
        charAnim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Vector3 moveto = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        if (moveto.x > 0f || moveto.z > 0f)
            Walk();
        else
            Idle();
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                dY = jumpSpeed;
            }
        }
        else
            dY -= gravity * Time.deltaTime;
        moveto.y = dY;
        moveto = transform.rotation * moveto;
        controller.Move(moveto * speed * Time.deltaTime);
        if (transform.position.y < -100)
        {
            transform.position = new Vector3(0, 100, 0);
            dY = 0;
        }
    }
    public void Idle()
    {
        charAnim.SetFloat("IdleBlend", 0);
    }
    public void Walk()
    {
        charAnim.SetFloat("IdleBlend", 1);
    }
}
