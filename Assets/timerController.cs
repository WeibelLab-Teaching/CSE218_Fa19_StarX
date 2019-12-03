using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerController : MonoBehaviour
{
    public static TextMeshPro textClock;
    public static float idealSecond = 30.0f;
    public static float idealMinute = 1.0f;
    public static float second = idealSecond;
    public static float minute = idealMinute;
    public static bool timerOn = true;
    public GameObject objectToEnableDisable;

    public menuController menuControllerObject;

    void Awake()
    {
        textClock = GetComponent<TextMeshPro>();
        DontDestroyOnLoad(this.gameObject);

        if (menuControllerObject == null)
        {
            Debug.LogWarning("menuControllerObject is null, will auto find to assign one");
            menuControllerObject = FindObjectOfType<menuController>();
            if (menuControllerObject == null)
            {
                Debug.LogError("Cannot Find a menuControllerObject in " + gameObject.name + "!");
            }
        }
    }

    void Update()
    {
        if (!getTimerOn())
            return;
        second -= Time.deltaTime;
        if (minute < 0)
        {
            timerOn = !timerOn;
            second = 0.0f;
            minute = 0.0f;
            menuControllerObject.setSummaryMenuActive();
            objectToEnableDisable.SetActive(false);


        }
        if (second < 0)
        {
            minute -= 1.0f;
            second = 59.0f;
        }
        if (textClock == null)
        {
            textClock = GetComponent<TextMeshPro>();
        }

        textClock.text = LeadingZero(minute) + ':' + LeadingZero(second);
    }

    public bool getTimerOn()
    {
        return timerOn;
    }
    public void setTimer(bool b)
    {
        // Debug.Log("settimer" + b);
        timerOn = b;
    }

    public void toggleTimer()
    {
        timerOn = !timerOn;
    }

    public string LeadingZero(float n)
    {
        return ((int)n).ToString().PadLeft(2, '0');
    }

    public void OnRestarButtonClick()
    {
        // Debug.Log("restart");
        second = idealSecond;
        minute = idealMinute;
        // Debug.Log(Timer.second);
    }
}
