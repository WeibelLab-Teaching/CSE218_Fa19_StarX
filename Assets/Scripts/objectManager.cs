using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{
    // Update is called once per frame
    public void scanToLevel(GameObject activate)
    {
        activate.SetActive(true);
        this.transform.parent.parent.gameObject.SetActive(false);
    }
}
