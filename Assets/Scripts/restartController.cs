using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("restart timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRestarButtonClick()
    {
        Timer.second = 0.0f;
        Timer.minute = 0.0f;
        Timer.hour = 0.0f;
        Debug.Log(Timer.second);
    }
}
