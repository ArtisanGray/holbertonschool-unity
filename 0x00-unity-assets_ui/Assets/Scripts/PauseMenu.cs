using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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
                Pause();
            else
                Resume();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        pCanvas.SetActive(true);
        mousesens = fc.GetComponent<CameraController>().mouseSensitivity;
        fc.GetComponent<CameraController>().mouseSensitivity = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pCanvas.SetActive(false);
        fc.GetComponent<CameraController>().mouseSensitivity = mousesens;
    }
    public void Options()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
