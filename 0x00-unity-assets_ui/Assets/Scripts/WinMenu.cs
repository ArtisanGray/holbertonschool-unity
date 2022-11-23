using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private string levelName;
    public Camera fc;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        fc.GetComponent<CameraController>().mouseSensitivity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Next()
    {
        levelName = SceneManager.GetActiveScene().name;
        if (levelName == "Level01")
            SceneManager.LoadScene("Level02");
        else if (levelName == "Level02")
            SceneManager.LoadScene("Level03");
        else
            SceneManager.LoadScene("MainMenu");
    }
}
