using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class correctCounter : MonoBehaviour
{
    public TextMeshPro timeTaken;
    
    // Start is called before the first frame update
    public static bool firstIntoSummary = true;

    public ScoreController scoreControl;

    void Start()
    {
        if (!scoreControl)
        {
            Debug.LogWarning("Does not have a score controller here, will find one");
            scoreControl = FindObjectOfType<ScoreController>();
            if (!scoreControl)
            {
                Debug.LogError("Cannot find a ScoreController in the scene!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstIntoSummary)
        {
            showlast();
            firstIntoSummary = false;
        }
       
    }

    public void setFlag()
    {
        firstIntoSummary = true;
    }
    public void showlast()
    {
        float overallTime = timerController.idealSecond + timerController.idealMinute * 60;
        float timeleft = timerController.second + timerController.minute * 60;
        float TimeUsed = overallTime - timeleft;
        Debug.Log(overallTime);
        Debug.Log(timeleft);
        Debug.Log(TimeUsed);
        float minuteUsed = TimeUsed / 60;
        float secondUsed = TimeUsed % 60;
        Debug.Log(LeadingZero(minuteUsed));
        Debug.Log(LeadingZero(secondUsed));
        string text = LeadingZero(minuteUsed) + ':' + LeadingZero(secondUsed);
        timeTaken.text = "CORRECT: " + scoreControl.correctCount.ToString();
    }

    public string LeadingZero(float n)
    {
        return ((int)n).ToString().PadLeft(2, '0');
    }
}
