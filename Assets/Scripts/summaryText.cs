using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summaryText : MonoBehaviour
{
    public Text timeTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTaken.text = "Time taken: " + Timer.textClock.text;
    }
}
