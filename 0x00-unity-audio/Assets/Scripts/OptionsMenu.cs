using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject applySettings;
    public Toggle Inverted;
    public AudioSource bGM;
    public AudioSource sFX;
    public Slider bgmSlider;
    public Slider sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("BGMVolume"))
            bGM.volume = 1f;
        else
            bGM.volume = PlayerPrefs.GetFloat("BGMVolume");
        if (!PlayerPrefs.HasKey("SFXVolume"))
            sFX.volume = 1f;
        else
            sFX.volume = PlayerPrefs.GetFloat("SFXVolume");
        Cursor.visible = true;
        Inverted.GetComponent<Toggle>().isOn = bool.Parse(PlayerPrefs.GetString("InvertY"));
        applySettings.GetComponent<Button>().onClick.AddListener(Apply);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Back()
    {
        Cursor.visible = false;
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
        Cursor.visible = false;
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    }
}
