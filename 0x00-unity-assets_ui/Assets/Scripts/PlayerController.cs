using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public Rigidbody playerRb;
    private bool canJump;
    public Camera followcam;
    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //store float of player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = Quaternion.Euler(0, followcam.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);
        //translates the player's rotation to the adjusted rotation of the camera, plus the movement from wasd and arrow keys.

        if (Input.GetKeyDown(KeyCode.Space) && canJump)//if the player is touching the ground, they can jump.
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            canJump = false;
        }
        if (transform.position.y < -20)
        {
            transform.position = new Vector3(0, 20, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayArea")
        {
            canJump = true;
        }
    }
}
