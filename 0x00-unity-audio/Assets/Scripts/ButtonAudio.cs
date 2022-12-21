using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource ButtonOutput;
    public AudioClip onButtonClick;
    public AudioClip onButtonHover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonHover()
    {
        ButtonOutput.PlayOneShot(onButtonHover);
    }
    public void buttonClick()
    {
        ButtonOutput.PlayOneShot(onButtonClick);
    }
}
