using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectShake : MonoBehaviour
{
    public float speed = 5.0f; //how fast it shakes
    public float amount = 0.2f; //how much it shakes
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Mathf.Sin(Time.time * speed) * amount + position.x, position.y, position.z);
    }
}
