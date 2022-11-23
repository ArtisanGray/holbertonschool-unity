using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float currentTime;
    public Text finalTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerText.color != Color.green)
            currentTime = currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        TimerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + "." + (time.Milliseconds / 10).ToString();
    }
    public void Win()
    {
        Time.timeScale = 0;
        finalTime.GetComponent<Text>().text = TimerText.text;
        TimerText.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
            Win();
    }
}