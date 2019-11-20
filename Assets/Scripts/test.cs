using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public void changeMenuScene(string sceneName) {
        // Debug.Log("Clicked");
        // Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
