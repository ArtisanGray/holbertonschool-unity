using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelSelect(int level)
    {
        string level_name = string.Format("Level0{0}", level);
        SceneManager.LoadScene(level);
    }
    public void Options()
    {
        PlayerPrefs.SetString("lastScene", "MainMenu");
        SceneManager.LoadScene("Options");
    }
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
    private void clicked()
    {
        if (btn.name == "OptionsButton")
        {
            Options();
        }
        else if (btn.name == "ExitButton")
        {
            Exit();
        }
        else
        {
            LevelSelect(int.Parse(Regex.Match(transform.name, @"\d+").Value));
        }
    }
}
