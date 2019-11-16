using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Text textClock;
    float second = 0.0f;
    float minute = 0.0f;
    float hour = 0.0f;
    public bool timerOn = true;

    // Start is called before the first frame update
    void Awake()
    {
        textClock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!getTimerOn())
            return;
        second += Time.deltaTime;
        if (second>=60)
        {
            minute += 1;
            second = 0.0f;
        }
        if (minute>=60)
        {
            hour += 1;
            minute = 0;
        }

        textClock.text = LeadingZero(hour) + ":" + LeadingZero(minute) + ':' + LeadingZero(second);
    }

    public bool getTimerOn()
    {
        return timerOn;
    }
    public void setTimer(bool b) {
        timerOn = b;
    }

    string LeadingZero(float n)
    {
        return ((int)n).ToString().PadLeft(2, '0');
    }

}
