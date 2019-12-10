using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{

    public levelController levelControllerObj;
    public GameObject[] MenuObjToControl;
    public int summaryIndex = 3;


    // Start is called before the first frame update
    void Start()
    {

        if (MenuObjToControl.Length == 0)
        {
            Debug.LogWarning("MenuObjToControl has nothing in it, will put its all children into");
            MenuObjToControl = gameObject.GetComponentsInChildren<GameObject>();
        }
        if (levelControllerObj == null)
        {
            Debug.LogWarning("levelControllerObj is null, will find a levelController into");
            levelControllerObj = FindObjectOfType<levelController>();
            if (levelControllerObj == null)
            {
                Debug.LogError("Cannot Find a levelController in this scene");
            }
        }
        // Debug.Log("NUMBER " + MenuObjToControl.Length);
        for (int i = 0; i < MenuObjToControl.Length; i++)
        {
            Debug.Log(i.ToString() + " " + MenuObjToControl[i].name);
            if (MenuObjToControl[i] == null)
            {
                Debug.LogError("MenuObjToControl list has null object in index " + i);
                return;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMenuActive(int index)
    {
        setMenuActiveBool(index, true);
    }

    public void setSummaryMenuActive()
    {
        setMenuActiveBool(summaryIndex, true);
    }


    public void setLevel(int index)
    {
        levelControllerObj.setLevel(index);
    }

    public void setLevelActive(int index)
    {
        setLevelActiveBool(index, true);
    }

    public void setMenuInactive(int index)
    {
        setMenuActiveBool(index, false);
    }

    public void setLevelInactive(int index)
    {
        setLevelActiveBool(index, false);
    }

    public void setMenuActiveBool(int index, bool b)
    {
        Debug.Log("help info to menu");
        if (MenuObjToControl[index] == null)
        {
            Debug.LogError(gameObject.name + ": Can not setActive on null menu in index " + index);
            return;
        }
        foreach(GameObject gb in MenuObjToControl)
        {
            gb.SetActive(false);
        }
        MenuObjToControl[index].SetActive(b);
        for (int i = 0; i < MenuObjToControl.Length; i++)
        {
            if (MenuObjToControl[i].name == "warning")
            {
                MenuObjToControl[i].SetActive(b);
                Debug.Log("mark scene name " + MenuObjToControl[i].name);
                return;
            }
        }
        // test = GameObject.Find("warning");
        // Debug.Log(test.name);
    }

    public void setLevelActiveBool(int index, bool b)
    {
        if (levelControllerObj== null)
        {
            Debug.LogError(gameObject.name + "does not have a levelControllerObj");
            return;
        }
       // levelControllerObj.setLevelActive(index, b);
    }

    public void setSubMenuActive(int index, int subIndex, bool b)
    {
        if (MenuObjToControl[index] == null)
        {
            Debug.LogError(gameObject.name + ": Can not setActive on null sub menu in index " + index);
            return;
        }

        if (MenuObjToControl[index].GetComponent<menuController>() == null)
        {
            Debug.LogError(gameObject.name + ": There is not sub menu controller in index " + index + " - " + MenuObjToControl[index]);
            return;
        }

        MenuObjToControl[index].GetComponent<menuController>().setMenuActiveBool(subIndex, b);
    }

    public void setMenuActiveBool(string menuName, bool b)
    {
        foreach(GameObject obj in MenuObjToControl)
        {
            if (!obj)
            {
                Debug.LogError("MenuObjToControl has null object");
            }
            else if (obj.name.Equals(menuName))
            {
                obj.SetActive(b);
            }
            else
            {
                Debug.LogError("No such menu in MenuObjToControl");
            }
        }
    }
}
