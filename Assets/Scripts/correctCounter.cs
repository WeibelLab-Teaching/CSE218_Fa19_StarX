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
        Debug.Log("-----------------" + ScoreController.correctCount.ToString());
        timeTaken.text = "SAFE PLACES COLLECTED: " + ScoreController.correctCount.ToString();
    }

    public string LeadingZero(float n)
    {
        return ((int)n).ToString().PadLeft(2, '0');
    }
}
