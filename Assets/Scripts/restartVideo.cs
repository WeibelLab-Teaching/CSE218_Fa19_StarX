using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class restartVideo : MonoBehaviour
{
    public VideoPlayer earthquake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAgain()
    {
        earthquake.Stop();
        earthquake.Play();
    }
}
