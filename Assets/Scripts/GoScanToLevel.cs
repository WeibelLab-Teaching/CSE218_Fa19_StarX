using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScanToLevel : MonoBehaviour
{
    public void changeMenuScene(string sceneName) {
        // Debug.Log("Clicked");
        SceneManager.LoadScene(sceneName);
    }
}
