using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectController : MonoBehaviour
{
    public static bool hidden = false;
    // public GameObject ObjToControl;

    // Start is called before the first frame update
    void Start()
    {
        // ObjToControl = GameObject.Find("/helpinfo/panel/intensity");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(name);
        Debug.Log("hidden " + hidden);
        if (this.gameObject.name == "intensity")
        {
            if (hidden == false)
            {
                // Debug.Log(hidden);
                this.gameObject.SetActive(true);
            }
            else if (hidden == true)
            {
                // Debug.Log(hidden);
                this.gameObject.SetActive(false);
            }
            else
            {
                // Debug.Log(hidden);
                // If nothing works, load character one as a default.
                // Useful for loading the scene by itself for testing.
                this.gameObject.SetActive(true);
            }
        }
        
    }

    public void inactivate()
    {
        hidden = true;
    }

    public void activate()
    {
        hidden = false;
    }
}
