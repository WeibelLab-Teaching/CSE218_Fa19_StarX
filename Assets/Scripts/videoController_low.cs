using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class videoController_low : MonoBehaviour
{
    
    public VideoPlayer VideoPlayer_low;
    public VideoPlayer VideoPlayer_medium;
    public VideoPlayer VideoPlayer_high;

    public GameObject easy;
    public GameObject medium;
    public GameObject high;
    public GameObject startup;

    // public string SceneName;
    public GameObject[] videoDisable;
    public GameObject[] sceneActive;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("this start");
       // Debug.Log(VideoPlayer);
        // VideoPlayer.Prepare();


       // VideoPlayer.Play();
       // VideoPlayer.loopPointReached += LoadLow;
    }

    public void videoend()
    {
        if (levelController.levelSelected == 1)
        {
            easy.SetActive(false);
            startup.SetActive(true);
        }
        else if (levelController.levelSelected == 2)
        {
            medium.SetActive(false);
            startup.SetActive(true);
        }
        else if (levelController.levelSelected == 3)
        {
            high.SetActive(false);
            startup.SetActive(true);
        }
        else
        {
            easy.SetActive(false);
            startup.SetActive(true);
        }

        if (levelController.levelSelected == 1)
        {
            VideoPlayer_low.Play();
            VideoPlayer_low.loopPointReached += LoadLow;
        } else if (levelController.levelSelected == 2)
        {
            VideoPlayer_medium.Play();
            VideoPlayer_medium.loopPointReached += LoadLow;
        }
        else if (levelController.levelSelected == 3)
        {
            VideoPlayer_high.Play();
            VideoPlayer_high.loopPointReached += LoadLow;
        } else
        {
            Debug.Log("no level selection");
            VideoPlayer_low.Play();
            VideoPlayer_low.loopPointReached += LoadLow;
        }
        //VideoPlayer.Play();
        Debug.Log("end");
        
    }
    void LoadLow(VideoPlayer vp)
    {
        Debug.Log("getloooooo");
        foreach (GameObject gb in videoDisable)
        {
            gb.SetActive(false);
        }
        foreach (GameObject gb in sceneActive)
        {
            gb.SetActive(true);
        }
        if (levelController.levelSelected == 1)
        {
            easy.SetActive(true);
        }
        else if (levelController.levelSelected == 2)
        {
            medium.SetActive(true);
        }
        else if (levelController.levelSelected == 3)
        {
            high.SetActive(true);
        }
        else
        {
            easy.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
