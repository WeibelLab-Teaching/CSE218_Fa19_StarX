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
        for (int i = 0; i < MenuObjToControl.Length; i++)
        {
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
        Debug.Log(MenuObjToControl[index].name);
        MenuObjToControl[5].SetActive(b);
    }

    public void setLevelActiveBool(int index, bool b)
    {
        if (levelControllerObj== null)
        {
            Debug.LogError(gameObject.name + "does not have a levelControllerObj");
            return;
        }
        levelControllerObj.setLevelActive(index, b);
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
}
