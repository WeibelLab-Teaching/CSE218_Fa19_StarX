using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowBreaking : MonoBehaviour
{
    bool added = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (!added && Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // add rigid body component here for all children objects
            addRigidBody();
            added = true;
            Debug.Log("break");
        }
    }
    void addRigidBody()
    {
        foreach (Transform child in GetComponent<Transform>())
        {
            var rigidBody = child.gameObject.AddComponent<Rigidbody>();
            rigidBody.useGravity = true;
        }
    }
}
