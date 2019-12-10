using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terminateTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    terminatManager controller;
    private void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {

    }

    public void setController(terminatManager c)
    {
        this.controller = c;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("target"))
            controller.trigerEvent();
    }
}
