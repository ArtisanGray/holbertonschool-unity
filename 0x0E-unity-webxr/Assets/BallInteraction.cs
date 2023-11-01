using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BallInteraction : MonoBehaviour
{
    private Rigidbody rb;
    public Canvas score;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pad") //hits a speed boost pad, gives a speed boost
        {
            Vector3 force = transform.forward * 5.0f;
            rb.AddForce(force, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "pins") // hits a pin, pin go bye bye
        {
            Destroy(collision.gameObject);
            int scoreInt = Int32.Parse(score.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);

            score.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (scoreInt + 1).ToString();
        }
        if (collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject);
        }
    }
}
