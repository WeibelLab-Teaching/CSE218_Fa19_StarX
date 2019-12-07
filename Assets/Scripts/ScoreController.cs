using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.UI;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public int mistakeCount;
    public int correctCount;
    public AudioClip warningClip;
    public AudioClip safeClip;

    public AudioSource source;

    public List<GameObject> safePlaces;
    public List<GameObject> dangerPlaces;


    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
        mistakeCount = 0;
        correctCount = 0;
        //foreach (GameObject g in GetComponentsInChildren<GameObject>())
        //{
        //    GameObject childGameObject = g.GetComponentInChildren<GameObject>();
        //    if (!childGameObject)
        //    {
        //        continue;
        //    }
        //    if (childGameObject.CompareTag("safePlace"))
        //    {
        //        safePlaces.Add(childGameObject);
        //        childGameObject.GetComponent<scoreKeeper>().setController(this);
        //    }
        //    else if (childGameObject.CompareTag("dangerPlace"))
        //    {
        //        dangerPlaces.Add(childGameObject);
        //        childGameObject.GetComponent<scoreKeeper>().setController(this);
        //    }
        //}

        foreach (GameObject g in safePlaces)
        {
            Interactable ig = g.GetComponent<Interactable>();
            if (!ig)
            {
                Debug.LogWarning("One safeplace does not have Interactable Script in it!");
                continue;
            }
        }
    }

    private void OnEnable()
    {
        foreach (GameObject g in safePlaces)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in dangerPlaces)
        {
            g.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incMistake()
    {
        mistakeCount += 1;
    }

    public void incCorrect()
    {
        correctCount += 1;
    }

    public void playAudioAndHide(bool isCorrect)
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = (isCorrect ? safeClip : warningClip);
        source.playOnAwake = false;
        source.PlayOneShot(source.clip);
    }
}
