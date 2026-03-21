using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class Raycast : MonoBehaviour
{
    public float interactableDistance;

    [Space]
    public PickableObjectManager pickableObjectManager;
    public PickupScript pickupScript;

    public TextMeshProUGUI crosshairText;
    public GameObject hitGameObject;

    void Update()
    {
        if(""!= "Hit checks")
        {
            if (CheckHitTag("Pickable"))
            {
                pickableObjectManager.Detected(true);
                pickupScript.targetObject = hitGameObject;
                crosshairText.text = hitGameObject.name;
            }
            else
            {
                if (pickableObjectManager != null) { pickableObjectManager.Detected(false); }
                if (!pickupScript.isHolding) { pickupScript.targetObject = null; }
            }
        }
        
    }

    public bool CheckHitName(string name) { return CheckRaycastHit(0, name, "");}
    public bool CheckHitTag(string tag) { return CheckRaycastHit(1, "", tag);}

    private bool CheckRaycastHit(int ind, string name, string tag)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, interactableDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);

            if (ind == 0 && hitinfo.collider.name == name)
            {
                hitGameObject = hitinfo.collider.gameObject;
                return true;
            }
            else if (ind == 1 && hitinfo.collider.tag == tag)
            {
                hitGameObject = hitinfo.collider.gameObject;

                if(hitinfo.collider.tag == "Pickable")
                {
                    pickableObjectManager = hitinfo.collider.GetComponent<PickableObjectManager>();
                }

                return true;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactableDistance, Color.red);
            crosshairText.text = "";
        }
        return false; 
    }
}
