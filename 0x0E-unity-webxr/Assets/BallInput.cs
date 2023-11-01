using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInput : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-4 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(4 * Time.deltaTime, 0, 0);
        }
    }
}
