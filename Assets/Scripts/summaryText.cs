using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class summaryText : MonoBehaviour
{
    public TextMeshPro timeTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTaken.text = "TIME TAKEN: " + Timer.textClock.text;
    }
}
