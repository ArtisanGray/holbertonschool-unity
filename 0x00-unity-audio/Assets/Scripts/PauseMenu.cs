using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public Camera fc;
    public GameObject pCanvas;
    private float mousesens;
    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale < 1)
            Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0f)
            {
                Cursor.visible = true;
                Pause();
            }
            else
            {
                Cursor.visible = false;
                Resume();
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pCanvas.SetActive(true);
        lowPass();
        mousesens = fc.GetComponent<CameraController>().mouseSensitivity;
        fc.GetComponent<CameraController>().mouseSensitivity = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pCanvas.SetActive(false);
        lowPass();
        fc.GetComponent<CameraController>().mouseSensitivity = mousesens;
    }
    public void Options()
    {
        unpaused.TransitionTo(.01f);
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
    public void Restart()
    {
        unpaused.TransitionTo(.01f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        unpaused.TransitionTo(.01f);
        SceneManager.LoadScene("MainMenu");
    }
    public void lowPass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }
        else if (Time.timeScale == 1)
            unpaused.TransitionTo(.01f);
    }
}
