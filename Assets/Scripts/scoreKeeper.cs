using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class scoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public ScoreController controller;

    void Start()
    {
        
    }

    public void setController(ScoreController sc)
    {
        this.controller = sc;
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller)
        {
            Debug.LogError("This scoreKeeper does not have controller");
        }
    }
	
	public void incMistake(){
        controller.incMistake();
        playAudio(false);
    }
	
	public void incCorrect(){
        controller.incCorrect();
        playAudio(true);
    }

    public void playAudio(bool isCorrect) {
        controller.playAudioAndHide(isCorrect);
        this.gameObject.SetActive(false);
    }
   
}

