using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
public class Raycast : MonoBehaviour
{
    public float interactableDistance;

    [Space]
    public PickableObjectManager pickableObjectManager;
    public PickupScript pickupScript;
    public KeyCode interactKey = KeyCode.E;

    public TextMeshProUGUI crosshairText;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, interactableDistance))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);

            if (hitinfo.collider.tag == "Pickable")
            {
                pickupScript.targetObject = hitinfo.collider.gameObject;
            }
            else
            {
                if (!pickupScript.isHolding) { pickupScript.targetObject = null; }
            }

            ICrosstext icrosstext = hitinfo.collider.GetComponent<ICrosstext>();
            if (icrosstext != null)
            {
                crosshairText.text = icrosstext.CrossText;
            }
            else
            {
                crosshairText.text = "";
            }

            IInteractable interactable = hitinfo.collider.gameObject.GetComponent<IInteractable>();
            if (interactable != null && Input.GetKeyDown(interactKey))
            {
                interactable.Interact();
            }

            if(hitinfo.collider.tag == "Customer" && Input.GetKeyDown(KeyCode.E))
            {
                CustomerAI cs = hitinfo.collider.GetComponent<CustomerAI>();
                cs.positionManager.LeaveTicketQueue(cs.posToMove, cs);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * interactableDistance, Color.red);
            crosshairText.text = "";
        }
    }
}
