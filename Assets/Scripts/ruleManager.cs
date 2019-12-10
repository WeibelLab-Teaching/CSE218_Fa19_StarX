using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ruleManager : MonoBehaviour
{
    TextMeshPro textRule;
    public static bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        textRule = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true)
        {
            if (textRule == null)
            {
                textRule = GetComponent<TextMeshPro>();
            }

            Debug.Log("level is" + levelController.levelSelected.ToString());
            if (levelController.levelSelected == 3)
            {
                textRule.text = "it's a high magnitude earthquake drill." + "\n" + "follow navigator to reach emergency assembly area quickly.";
            }
            else if (levelController.levelSelected == 1 || levelController.levelSelected == 2)
            {
                textRule.text = "there are many safe / danger places in the drill." + " " + "airtap to collect them." + "\n" + "follow navigator to reach emergency assembly area." + "\n" + "before timer runs out collect as many safe / danger place as possible and reach emergency assembly area.";
            }
            flag = false;
        }
        
    }

}
