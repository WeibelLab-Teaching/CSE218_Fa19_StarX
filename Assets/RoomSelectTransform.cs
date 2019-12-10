using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelectTransform : MonoBehaviour
{

    public Transform Room;
    public GameObject roomMenuObj;

    public GameObject menuObjToEnableAfter;
    public GameObject physicsObjToEnableAfter;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public bool isTransform = false;
    public bool isShowInMenu = false;
    public Transform rotateRoomParent;
    public GameObject rotateRoomParentObj;
    public menuController controller;
    public GameObject buttonToDisable;
    public GameObject buttonToActive;

    public AnchorModuleScript anchorManager;

    private Vector3 originalposition;
    private Quaternion originalrotation;
    private Vector3 originallocalScale;

    // Start is called before the first frame update
    void OnEnable()
    {
        originalposition = Room.transform.position;
        originallocalScale = Room.transform.localScale;
        originalrotation = Room.transform.rotation;

        if (!rotateRoomParent)
        {
            rotateRoomParent = Room.transform.parent;
        }
        if (!controller)
        {
            controller = FindObjectOfType<menuController>();
            if (!controller) Debug.LogError("No Controller To Activate Menu");
        }
        if (!roomMenuObj)
        {
            Debug.LogError("No roomMenuObj is given, disable self");
            this.enabled = false;
        }
        if (!menuObjToEnableAfter)
        {
            Debug.LogError("No menuObjToEnableAfter is given, disable self");
            this.enabled = false;
        }
        if (!physicsObjToEnableAfter)
        {
            Debug.LogError("No physicsObjToEnableAfter is given, disable self");
            this.enabled = false;
        }
        if (!anchorManager)
        {
            Debug.LogError("No AzureAnchorManager is given, disable self");
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isShowInMenu)
        {
            rotateRoomParent.Rotate(new Vector3(0, 0.5f, 0));
        }
        if (isTransform)
        {
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, 0));
            Vector3 targetScale = target.localScale / 10;
            Quaternion targetRotation = target.rotation;

            // Smoothly move the camera towards that target position
            Room.transform.position = Vector3.SmoothDamp(Room.transform.position, targetPosition, ref velocity, smoothTime);
            Room.transform.localScale = Vector3.Lerp(Room.transform.localScale, new Vector3(1, 1, 1), smoothTime * 0.1f);
            Room.transform.rotation = Quaternion.RotateTowards(Room.transform.rotation, targetRotation, smoothTime * 0.2f);

            if ((Room.transform.position - targetPosition).z < 0.00005f )
            {
                Room.transform.position = targetPosition;
                Room.transform.localScale = new Vector3(1, 1, 1);
                Room.transform.rotation = targetRotation;
                isTransform = false;

                rotateRoomParent.gameObject.SetActive(false);
                //controller.setMenuActiveBool(roomMenuIndex, false);
                //this.enabled = false;
                menuObjToEnableAfter.SetActive(true);
                physicsObjToEnableAfter.SetActive(true);
                roomMenuObj.SetActive(false);
                Room.gameObject.SetActive(false);
            }
        }
        
    }

    public void startLoadModel()
    {
        try {
            anchorManager.GetSharedAzureAnchorID();
        }
        catch(System.Exception e)
        {
            Debug.LogError("I got " + e);
            
        }
        anchorManager.StartAzureSession();
        buttonToDisable.SetActive(false);
        buttonToActive.SetActive(true);
        rotateRoomParentObj.SetActive(true);
        isShowInMenu = true;
    }

    public void enableTransform()
    {
        Room.transform.parent = null;
        isTransform = true;
        isShowInMenu = false;
        anchorManager.FindAzureAnchor();
    }
    public void resetTransform()
    {
        Room.transform.position = originalposition;
        Room.transform.localScale = originallocalScale;
        Room.transform.rotation = originalrotation;
        Room.transform.parent = rotateRoomParent;
    }

}
