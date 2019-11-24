using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotater : MonoBehaviour
{
    public Vector3 rotateAnglePerFrame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldAngles = this.gameObject.transform.eulerAngles;
        this.gameObject.transform.eulerAngles = new Vector3(oldAngles.x + rotateAnglePerFrame.x, oldAngles.y + rotateAnglePerFrame.y, oldAngles.z + rotateAnglePerFrame.z);
    }
}
