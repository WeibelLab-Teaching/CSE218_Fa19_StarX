using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EZCameraShake;

public class ColliderController : MonoBehaviour
{
    // Start is called before the first frame update
    //public shaketest cameraShake;
    bool detect;
    public CameraShaker shaker;
    public float magniture;
    public List<Collider> colliderToDetect;
    bool hasNoNullObject = true;
    bool addedRigid = false;

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
            } else
            {
                c.gameObject.AddComponent<CollideTrigger>().setController(this);
    
            }
        }


        if (!shaker)
        {
            shaker = FindObjectOfType<CameraShaker>();
            Debug.LogWarning("Did not assigned CameraShaker, find one " + shaker.name);
            if (!shaker)
            {
                Debug.LogError("Can not find a CameraShaker!");
                hasNoNullObject = false;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        insideDist();

        if (detect)
        {
            detect = false;
        }
    }
    public void trigerEvent()
    {
        detect = true;
        playAudio();
        shaker.ShakeOnce(magniture, 1.0f, 1.0f, 1.0f);
        Debug.Log("Here");
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
        if ((this.transform.position - headPosition).magnitude < 4)
        {
            foreach (Transform child in transform)
            {
                var rigid = child.gameObject.AddComponent<Rigidbody>();
                rigid.useGravity = true;
            }
            return true;
        }

        else
        {
            return false;
        }
            
    }
}
