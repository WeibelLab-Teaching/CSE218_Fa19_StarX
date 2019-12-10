using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class objectController : MonoBehaviour
{
    public static bool hidden = false;
    public VideoPlayer earthquake;
    // public GameObject ObjToControl;

    // Start is called before the first frame update
    void Start()
    {
        // ObjToControl = GameObject.Find("/helpinfo/panel/intensity");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(name);
        //Debug.Log("hidden " + hidden);
        if (this.gameObject.name == "intensity")
        {
            if (hidden == false)
            {
                // Debug.Log(hidden);
                this.gameObject.SetActive(true);
            }
            else if (hidden == true)
            {
                // Debug.Log(hidden);
                this.gameObject.SetActive(false);
            }
            else
            {
                // Debug.Log(hidden);
                // If nothing works, load character one as a default.
                // Useful for loading the scene by itself for testing.
                this.gameObject.SetActive(true);
            }
        }
       
    }

    public void inactivate()
    {
        hidden = true;
    }

    public void activate()
    {
        hidden = false;
    }

    public void setFlagTrue()
    {
        ruleManager.flag = true;

    }

    public void setTimerFlagTrue()
    {
        timerController.timerFlag = true;

    }

    public void setGameoverFlagFalse()
    {
        timerController.gameoverFlag = false; ;

    }

    public void setTerminateFlagFalse()
    {
        terminatManager.terminateFlag = false;

    }

    public void setCounterZero()
    {
        correctCounter.firstIntoSummary = true;
        mistakesCounter.firstIntoSummary = true;
        ScoreController.correctCount = 0;
        ScoreController.mistakeCount = 0;
    }

    public void startAgain()
    {
        earthquake.Stop();
        earthquake.Play();
    }
}
