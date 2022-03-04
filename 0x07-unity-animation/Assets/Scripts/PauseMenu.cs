using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause_menu;
    private Timer GameTimer;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        GameTimer = GetComponent<Timer>();
        Time.timeScale = 1;
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused == false)
                Pause();
            else
                Resume();
        }
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
        pause_menu.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void Resume()
    {
        isPaused = false;
        pause_menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
