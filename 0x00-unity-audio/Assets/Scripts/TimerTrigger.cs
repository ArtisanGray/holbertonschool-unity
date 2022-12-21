using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private bool started;
    void Start()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (started == false)
        {
            player.GetComponent<Timer>().enabled = true;
            started = true;
        }
    }


}
