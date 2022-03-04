using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
        if (int.Parse(Regex.Match(PlayerPrefs.GetString("lastScene"), @"\d+").Value) != 3)
            SceneManager.LoadScene(int.Parse(Regex.Match(PlayerPrefs.GetString("lastScene"), @"\d+").Value) + 1);
        else
            SceneManager.LoadScene("MainMenu");
    }

}
