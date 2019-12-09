using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectShake : MonoBehaviour
{
    public float speed = 5.0f; //how fast it shakes
    public float amount = 0.2f; //how much it shakes
    Vector3 position;

    private Quaternion originRotation;
    public float shake_decay = 0.002f;
    public float shake_intensity = .3f;
    private float temp_shake_intensity = 2;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        originRotation = transform.rotation;
        temp_shake_intensity = shake_intensity;
        //this.transform.position = new Vector3(Mathf.Sin(Time.time * speed) * amount + position.x, position.y, position.z);
        //this.transform.Rotate(0.0f, Mathf.Sin(Time.time * speed) * amount   , 0.0f,Space.World);
        transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .002f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .002f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .002f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .002f);
        temp_shake_intensity -= shake_decay;
    }
}
