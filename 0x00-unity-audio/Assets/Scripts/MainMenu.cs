using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LevelSelect(int level)
    {
        Cursor.visible = false;
        if (level == 1)
        {
            SceneManager.LoadScene("Level01");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Level02");
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("Level03");
        }
    }
    public void Options()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Options");
    }
    public void GameExit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}

