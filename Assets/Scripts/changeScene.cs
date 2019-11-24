using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string sceneName;
    public static bool hidden = false;

    public void changeMenuScene(string sceneName) {
        // Debug.Log("Clicked");
        // Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void OnRestarButtonClick()
    {
        Timer.second = Timer.idealSecond;
        Timer.minute = Timer.idealMinute;
        Debug.Log(Timer.second);
    }

    /*
    public void OnRestarButtonClick()
    {
        Timer.second = 0.0f;
        Timer.minute = 0.0f;
        Timer.hour = 0.0f;
        Debug.Log(Timer.second);
    }
    */

    void Update()
    {
        string name = this.gameObject.name;
        Debug.Log(name);
        Debug.Log(hidden);
        if (name == "help")
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
}
