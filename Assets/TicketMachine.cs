using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMachine : MonoBehaviour, IInteractable, ICrosstext
{
    [SerializeField] private string crosstext;
    [SerializeField] private GameObject ticketMachineCanvas;
    public bool isOpen;
    private CameraController controller;
    private void Start()
    {
        controller = GameObject.Find("Camera").GetComponent<CameraController>();
    }
    public string CrossText => crosstext;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(ticketMachineCanvas)
            {
                Close();
            }
        }
    }
    public void Interact()
    {
        ticketMachineCanvas.SetActive(true);
        controller.FreezeCam();
        isOpen = true;
    }
     public void Close()
     {
        ticketMachineCanvas.SetActive(false);
        controller.UnfreezeCam();
        isOpen = false;
     }
     
    public void SelectMovie(int i)
    {

    }
}
