using UnityEngine;
using TMPro;

public class summaryText : MonoBehaviour
{
    public TextMeshPro timeTaken;
    public TextMeshPro timeIdeal;
    // Start is called before the first frame update
    public static bool firstIntoSummary = true;

    public AudioClip warningClip;
    AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Update is called once per frame
    void Update()
    {
        if (firstIntoSummary)
        {
            showlast();
            showIdeal();
            firstIntoSummary = false;
        }
       
    }

    public void setFlag()
    {
        firstIntoSummary = true;
    }
    public void showlast()
    {
        if (timerController.gameoverFlag == true)
        {
            playAudio();
        }
        float overallTime = timerController.idealSecond + timerController.idealMinute * 60;
        float timeleft = timerController.second + timerController.minute * 60;
        float TimeUsed = overallTime - timeleft;
        // Debug.Log(overallTime);
        // Debug.Log(timeleft);
        // Debug.Log(TimeUsed);
        float minuteUsed = TimeUsed / 60;
        float secondUsed = TimeUsed % 60;
        // Debug.Log(LeadingZero(minuteUsed));
        // Debug.Log(LeadingZero(secondUsed));
        string text = LeadingZero(minuteUsed) + ':' + LeadingZero(secondUsed);
        timeTaken.text = "TIME TAKEN: " + text;
    }

    public string LeadingZero(float n)
    {
        return ((int)n).ToString().PadLeft(2, '0');
    }

    void showIdeal()
    {
        Debug.Log("timer is " + timerController.idealMinute.ToString() + timerController.idealSecond.ToString());
        timeIdeal.text = "IDEAL TIME: " + LeadingZero(timerController.idealMinute) + ':' + LeadingZero(timerController.idealSecond);
    }

    public void playAudio()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = warningClip;
        source.playOnAwake = false;
        PlaySound();
    }

    void PlaySound()
    {
        source.PlayOneShot(warningClip);
    }

}
