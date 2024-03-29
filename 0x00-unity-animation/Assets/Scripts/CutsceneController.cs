using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject mCamera;
    public GameObject tCanvas;

    bool running;
    Animator animator;
    private int _animationState;
    void Start()
    {
        running = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running == false)
        {
            mCamera.SetActive(true);
            player.GetComponent<PlayerController>().enabled = true;
            tCanvas.SetActive(true);

            gameObject.SetActive(false);
        }
    }
    public void StopAnim()
    {
        running = false;
    }
}
