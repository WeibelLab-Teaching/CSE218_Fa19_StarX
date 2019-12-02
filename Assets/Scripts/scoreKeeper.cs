using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class scoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
	public static int mistakeCount;
	public static int correctCount;
    public AudioClip warningClip;
    AudioSource source { get { return GetComponent<AudioSource>(); } }
    void Start()
    {
        mistakeCount = 0;
		correctCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void incMistake(){
		mistakeCount += 1;
	}
	
	public void incCorrect(){
		correctCount += 1;
	}

    public void playAudioAndHide() {
        gameObject.AddComponent<AudioSource>();
        source.clip = warningClip;
        source.playOnAwake = false;
        PlaySound();
    }

    void PlaySound() {
        source.PlayOneShot(warningClip);
        Destroy(gameObject, source.clip.length);
    }

}

