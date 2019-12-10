using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class timerController : MonoBehaviour
{
    public static TextMeshPro textClock;
    public static bool gameoverFlag = false;

    public float idealSecond_low = 30.0f;
    public float idealMinute_low = 1.0f;

    public float idealSecond_medium = 00.0f;
    public float idealMinute_medium = 1.0f;

    public float idealSecond_high = 15.0f;
    public float idealMinute_high = 0.0f;

    public static float idealSecond;
    public static float idealMinute;

    public static float second;
    public static float minute;

    public static bool timerFlag = true;



    //public static float idealSecond;
    //public static float idealMinute;

    //public static float second = idealSecond;
    //public static float minute = idealMinute;

    public static float prevSecond, prevMinute;
    public static bool timerOn = true;
    public GameObject[] objectsToEnableDisable;
    public GameObject objectToEnable;
    // public GameObject objectToEnableDisable;

    public menuController menuControllerObject;
    AudioSource source { get { return GetComponent<AudioSource>(); } }

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
        if (timerFlag == true)
        {
            if (levelController.levelSelected == 3)
            {
                idealSecond = idealSecond_high;
                idealMinute = idealMinute_high;
            }
            else if (levelController.levelSelected == 2)
            {
                idealSecond = idealSecond_medium;
                idealMinute = idealMinute_medium;
            }
            else if (levelController.levelSelected == 1)
            {
                idealSecond = idealSecond_low;
                idealMinute = idealMinute_low;
            }
            else
            {
                idealSecond = 30.0f;
                idealMinute = 0.0f;
            }
            second = idealSecond;
            minute = idealMinute;
            timerFlag = false;
            Debug.Log("timer is " + idealMinute.ToString());
            Debug.Log("timer is " + idealSecond.ToString());
        }
        
        
        second -= Time.deltaTime;
        if (minute < 0)
        {
            Debug.Log("=======================fail");
            gameoverFlag = true;
            timerOn = !timerOn;
            second = 0.0f;
            minute = 0.0f;
            menuControllerObject.setSummaryMenuActive();
            foreach (GameObject gb in objectsToEnableDisable)
            {
                gb.SetActive(false);
            }
            objectToEnable.SetActive(true);
            timerFlag = true;
            ruleManager.flag = true;

            // objectToEnableDisable.SetActive(false);
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
        else
        {
            textClock.text = LeadingZero(minute) + ':' + LeadingZero(second);
        }
        // textClock.text = LeadingZero(minute) + ':' + LeadingZero(second);
        
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
        Debug.Log("restart");
        second = idealSecond;
        minute = idealMinute;
        setTimer(true);
/*        Debug.Log(second);
        Debug.Log(minute);
*/    
    }
}
