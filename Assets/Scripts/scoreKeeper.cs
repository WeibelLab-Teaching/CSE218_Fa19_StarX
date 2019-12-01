using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
	public static int mistakeCount;
	public static int correctCount;
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
}

