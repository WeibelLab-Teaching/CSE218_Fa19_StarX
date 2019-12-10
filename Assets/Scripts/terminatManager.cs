using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminatManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    //public shaketest cameraShake;
    bool detect;
    public List<Collider> colliderToDetect;
    bool hasNoNullObject = true;
    bool addedRigid = false;

    public GameObject[] objectInactive;
    public GameObject[] objectActive;

    public static bool terminateFlag = false;

    public AudioClip warningClip;
    AudioSource source { get { return GetComponent<AudioSource>(); } }

    private void Start()
    {
        detect = false;
        foreach (Collider c in this.GetComponentsInChildren<Collider>())
        {
            colliderToDetect.Add(c);
        }
        for (int i = 0; i < colliderToDetect.Count; i++)
        {
            Collider c = colliderToDetect[i];
            if (!c)
            {
                Debug.LogError("Collider in index " + i + " is null");
                hasNoNullObject = false;
            }
            else
            {
                c.gameObject.AddComponent<terminateTrigger>().setController(this);

            }
        }


        
    }

    // Update is called once per frame
    private void Update()
    {
        if (terminateFlag == false)
        {
            insideDist();
        }
        
        if (detect)
        {
            detect = false;
        }
    }
    public void trigerEvent()
    {
        detect = true;
    }

    public void playAudio()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = warningClip;
        source.playOnAwake = false;
        PlaySound();
    }

    void PlaySound()
    {
        source.PlayOneShot(warningClip);
    }

    private bool insideDist()
    {
        var headPosition = Camera.main.transform.position;
        // Debug.Log((this.transform.position - headPosition).magnitude);
        if ((this.transform.position - headPosition).magnitude < 0.8)
        {
            terminateFlag = true;
            playAudio();
            Debug.Log("Terminate");
            foreach (GameObject gb in objectInactive)
            {
                gb.SetActive(false);
            }
            foreach (GameObject gb in objectActive)
            {
                gb.SetActive(true);
            }
            timerController.timerOn = !timerController.timerOn;
            timerController.second = 0.0f;
            timerController.minute = 0.0f;
            // menuControllerObject.setSummaryMenuActive();
            timerController.timerFlag = true;
            ruleManager.flag = true;
            return true;
        }

        else
        {
            return false;
        }

    }
}
