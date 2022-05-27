using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonClick : MonoBehaviour
{
    //public GameObject button;
    //public VirtualButtonBehaviour vb;
    //public Animator startAni;
    public string Url;
    // Start is called before the first frame update
    void Start()
    {
        //vb.RegisterOnButtonPressed(OnButtonPressed);
        //vb.RegisterOnButtonReleased(OnButtonReleased);
        //startAni.GetComponent<Animator>();
        //startAni.Play("start");
    }
    public void GetURL()
    {
        Application.OpenURL(Url);
        Debug.Log(Url + " Opened");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
