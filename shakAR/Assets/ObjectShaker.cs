using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShaker : MonoBehaviour
{
    public float speed = 1.0f; //how fast it shakes
    public float amount = 1.0f; //how much it shakes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3 (Mathf.Sin(Time.time * speed) * amount, 0, 0);
    }
}
