using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject applySettings;
    public Toggle Inverted;
    // Start is called before the first frame update
    void Start()
    {
        Inverted.GetComponent<Toggle>().isOn = bool.Parse(PlayerPrefs.GetString("InvertY"));
        applySettings.GetComponent<Button>().onClick.AddListener(Apply);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    }
    public void InvertY()
    {
        if (Inverted.GetComponent<Toggle>().isOn)
            PlayerPrefs.SetString("InvertY", "true");
        else
            PlayerPrefs.SetString("InvertY", "false");
    }
    public void Apply()
    {
        InvertY();
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    }
}
