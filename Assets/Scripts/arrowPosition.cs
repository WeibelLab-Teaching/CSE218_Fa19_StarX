using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class arrowPosition : MonoBehaviour
{

    public float positionOffset;
    public float dist_limit;

    public GameObject[] safeNodes = new GameObject[3];
    private List<KeyValuePair<int, float>> queue;

    void Start()
    {
        dist_limit = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        var position = NearestPosition();

        var direction = (position - headPosition).normalized;
        gameObject.transform.rotation = Quaternion.LookRotation(direction);

    }

    Vector3 NearestPosition()
    {
        int i = 0;
        queue = new List<KeyValuePair<int, float>>(3);
        foreach (GameObject child in safeNodes)
        {
            var position = child.transform.position;
            float distance = (Camera.main.transform.position - position).magnitude;
            //Debug.Log(distance);
            queue.Insert(i, new KeyValuePair<int, float>(i, -distance));
            i++;
        }
        queue.Sort((x, y) => (x.Value.CompareTo(y.Value)));

        if (-queue[0].Value < dist_limit*dist_limit)
        {
            int index;
            if (queue[1].Key < queue[2].Key)
            {
                index = queue[1].Key;
            }
            else
                index = queue[2].Key;
            return safeNodes[index].transform.position;
        }
            

        return safeNodes[queue[0].Key].transform.position;
    }
}
