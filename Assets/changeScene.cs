using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string sceneName;

    public void changeMenuScene(string sceneName) {
        // Debug.Log("Clicked");
        // Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void OnRestarButtonClick()
    {
        Timer.second = 0.0f;
        Timer.minute = 0.0f;
        Timer.hour = 0.0f;
        Debug.Log(Timer.second);
    }
}
