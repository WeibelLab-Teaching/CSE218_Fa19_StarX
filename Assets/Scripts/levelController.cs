using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// same as menu conrtoller but it is good to seperate two controller since they may have different behavior in future
// -Robin
public class levelController : MonoBehaviour
{
    public GameObject[] LevelObjToControl;
    public static int levelSelected;
    // Start is called before the first frame update
    void Start()
    {
        if (LevelObjToControl.Length == 0)
        {
            Debug.LogError("LevelObjToControl has nothing in it, will put its all children into");
            LevelObjToControl = gameObject.GetComponentsInChildren<GameObject>();
        }
        for (int i = 0; i < LevelObjToControl.Length; i++)
        {
            if (LevelObjToControl[i] == null)
            {
                Debug.LogError("LevelObjToControl list has null object in index " + i);
                return;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setLevel(int level) {
        levelSelected = level;
    }

    public void setLevelActive(bool b)
    {
        int index = levelSelected;
        if (LevelObjToControl[index] == null)
        {
            Debug.LogError(gameObject.name + ": Can not setActive on null level in index " + index);
            return;
        }
        foreach (GameObject gb in LevelObjToControl)
        {
            gb.SetActive(false);
        }
        LevelObjToControl[index].SetActive(b);
    }
}
