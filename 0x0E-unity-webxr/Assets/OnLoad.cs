using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR.Interactions;
using UnityEngine.UI;

public class OnLoad : MonoBehaviour
{
    public GameObject obstacle; //saw spiky thing
    private MeshRenderer lanePlane; //renderer data used for random spawn
    //public Animator laneAnim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            if (collision.gameObject.GetComponent<MouseDragObject>().enabled == true)
            {
                collision.gameObject.GetComponent<MouseDragObject>().enabled = false;
                collision.gameObject.GetComponent<BallInput>().enabled = true;
                loadObstacles();
                //laneAnim.SetBool("nBallEnter", true);
            }
        }   //if ball touches lane, ball's grabbable script component is disabled, but not movement.
    }
    void loadObstacles()
    {
        lanePlane = GetComponent<MeshRenderer>();

        float randoX = Random.Range((lanePlane.bounds.min.x), (lanePlane.bounds.max.x));
        float randoZ = Random.Range((lanePlane.bounds.min.z + 3), (lanePlane.bounds.max.z - 3));
        Vector3 obstaclePos = new Vector3(randoX, transform.position.y + (float)0.92, randoZ);
        Instantiate(obstacle, obstaclePos, transform.rotation);
    }
}
