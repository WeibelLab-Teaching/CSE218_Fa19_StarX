using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class enableWarnings : MonoBehaviour
{
    bool setWarning = true;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (setWarning)
        {
            foreach (Transform g in GetComponentsInChildren<Transform>())
            {
                Transform childTransform = g.GetComponentInChildren<Transform>();
                
                if (!childTransform)
                {
                    continue;
                }
                else
                {
                    Debug.Log("enable objects " + g.name + " subchild " + childTransform.name);
                    //Debug.Log("reenable objects");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
