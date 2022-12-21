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
    private GameObject _playermodel;
    private Animator _playeranim;
    private string _currentClip;
    public AudioSource runningSound;

    // Start is called before the first frame update
    void Start()
    {
        _playermodel = gameObject.transform.GetChild(0).gameObject;
        _playeranim = _playermodel.GetComponent<Animator>();
        canJump = true;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _currentClip = _playeranim.GetCurrentAnimatorClipInfo(0)[0].clip.name.ToString();

        //store float of player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (!(_currentClip == "Getting Up" || _currentClip == "Falling Flat Impact" || _currentClip == "Falling"))
        {
            Vector3 movement = Quaternion.Euler(0, followcam.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
            if ((horizontalInput != 0 || verticalInput != 0) && canJump == true && Time.timeScale == 1)
            {
                if (runningSound.isPlaying == false)
                {
                    runningSound.Play();
                }
            }
            //sets animator parameter to start running animation
            if (horizontalInput != 0 || verticalInput != 0)
                _playeranim.SetFloat("playerSpeed", speed);
            else
                _playeranim.SetFloat("playerSpeed", 0f);

            //moves player based on input and camera rotation
            transform.Translate(movement * speed * Time.deltaTime);
            _playermodel.transform.rotation = (Quaternion.Euler(0, followcam.transform.eulerAngles.y, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)//if the player is touching the ground, they can jump.
        {
            playerRb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            canJump = false;
            _playeranim.SetBool("isJumping", true);
        }
        if (transform.position.y < -20)
        {
            transform.position = new Vector3(0f, 20f, 0f);
        }
        if (transform.position.y < -5)
        {
            if (_playeranim.GetBool("Landed") == false)
            {
                _playeranim.SetBool("isFalling", true);
            }
            else
                _playeranim.SetBool("Landed", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayArea")
        {
            canJump = true;
            _playeranim.SetBool("isJumping", false);
            if (_playeranim.GetBool("isFalling") == true)
            {
                _playeranim.SetBool("isFalling", false);
                _playeranim.SetBool("Landed", true);
            }
        }
    }
}
