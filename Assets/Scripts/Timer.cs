using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// using Microsoft.MixedReality.Toolkit.UI;

public class Timer : MonoBehaviour
{
    public static TextMeshPro textClock;
    // public PressableButtonHoloLens2 pause_button;
    // public PressableButtonHoloLens2 play_button;
    float second = 0.0f;
    float minute = 0.0f;
    float hour = 0.0f;
    public bool timerOn = true;

    // Start is called before the first frame update
    void Awake()
    {
        textClock = GetComponent<TextMeshPro>();
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

    public void toggleTimer() {
        timerOn = !timerOn;
    }

    string LeadingZero(float n)
    {
        return ((int)n).ToString().PadLeft(2, '0');
    }
    // public void toggleButton(){
    //     if(!getTimerOn()){
    //         play_button.SetActive(true);
    //         pause_button.SetActive(false);
    //     }
    //     else{
    //         play_button.SetActive(false);
    //         pause_button.SetActive(true);

    //     }
//    }
}
