using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float timePassed = 0;
    private int Minutes = 0;
    public GameObject winCase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= 60)
        {
            Minutes += 1;
            timePassed = 0;
        }
        string replacement = string.Format("{0}:{1}", Minutes.ToString("F0"), timePassed.ToString("F2"));
        TimerText.text = replacement; 
    }
    public void Win()
    {
    }
}
