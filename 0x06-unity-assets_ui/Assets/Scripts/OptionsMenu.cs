using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("IsInverted") == "No Name")
            PlayerPrefs.SetString("IsInverted", "False");
        else
        {
            GameObject YSet = GameObject.Find("InvertYToggle");
            YSet.GetComponent<Toggle>().isOn = bool.Parse(PlayerPrefs.GetString("IsInverted"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }
    public void Apply()
    {
        GameObject YChange = GameObject.Find("InvertYToggle");
        //if values exist, whether true or false
        //if values do not exist or are edited...
        if (YChange.GetComponent<Toggle>().isOn)
            PlayerPrefs.SetString("IsInverted", "True");
        else
            PlayerPrefs.SetString("IsInverted", "False");
    }
}
