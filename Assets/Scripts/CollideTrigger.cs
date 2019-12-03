using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EZCameraShake;
public class CollideTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    //public shaketest cameraShake;
    ColliderController controller;

    private void Start()
    {
       
    }
    // Update is called once per frame
    private void Update()
    {
        
    }

    public void setController(ColliderController c)
    {
        this.controller = c;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
            controller.trigerEvent();
    }
}
