using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class CutsceneController : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject timer;
    public GameObject player;
    private bool animDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animDone == true)
        {
            playerCamera.SetActive(true);
            player.GetComponent<PlayerController>().enabled = true;
            timer.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void AnimatorIsPlaying() //returns whether or not the animation is finished.
    {
        animDone = true;
    }
}
