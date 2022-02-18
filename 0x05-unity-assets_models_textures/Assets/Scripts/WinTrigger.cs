using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Timer>().enabled = false;
        timer.GetComponent<Text>().color = Color.green;
        timer.GetComponent<Text>().fontSize = 60;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
