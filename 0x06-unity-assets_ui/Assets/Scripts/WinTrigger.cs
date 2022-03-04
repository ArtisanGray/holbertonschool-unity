using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject timer;
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Timer>().enabled = false;
        timer.SetActive(false);
        winScreen.SetActive(true);
        player.GetComponent<PauseMenu>().enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameObject.Find("WinCanvas").transform.GetChild(4).GetComponent<Text>().text = timer.GetComponent<Text>().text;
        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
