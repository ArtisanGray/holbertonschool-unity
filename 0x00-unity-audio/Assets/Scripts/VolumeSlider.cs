using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource targetAudio;
    private float _volume;
    void Start()
    {
        if (targetAudio.outputAudioMixerGroup.name == "BGM")
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("BGMVolume");
        else
            GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -144.0f;
        return dB;
    }
    public void setVolume()
    {
        Debug.Log(targetAudio.outputAudioMixerGroup.name);
        _volume = GetComponent<Slider>().value;
        if (targetAudio.outputAudioMixerGroup.name == "BGM")
        {
            Debug.Log(PlayerPrefs.GetFloat("BGMVolume").ToString());
            PlayerPrefs.SetFloat("BGMVolume", _volume);
        }
        else
            PlayerPrefs.SetFloat("SFXVolume", _volume);
    }
}
