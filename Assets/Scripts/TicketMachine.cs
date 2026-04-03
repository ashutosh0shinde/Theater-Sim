using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMachine : MonoBehaviour, IInteractable, ICrosstext
{
    [SerializeField] private string crosstext;

    [SerializeField] private GameObject ticketMachineCanvas;
    [SerializeField] private GameObject ticketMachine_movieCanvas;
    [SerializeField] private GameObject ticketMachine_seatCanvas;

    public bool isOpen;
    private CameraController controller;

    private void Start()
    {
        controller = GameObject.Find("Camera").GetComponent<CameraController>();
        Close();
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
    public void ChoseMovieFromButton()
    {

    }
    public void SelectWindow(int i)
    {
        if(i == 1)
        {
            ticketMachine_movieCanvas.SetActive(true);
            ticketMachine_seatCanvas.SetActive(false);
        }
        else if (i == 2)
        {
            ticketMachine_movieCanvas.SetActive(false);
            ticketMachine_seatCanvas.SetActive(true);
        }
    }
    public void Interact()
    {
        ticketMachineCanvas.SetActive(true);
        SelectWindow(1);
        controller.FreezeCam();
        isOpen = true;
    }
     public void Close()
     {
        ticketMachineCanvas.SetActive(false);
        ticketMachine_movieCanvas.SetActive(false);
        ticketMachine_seatCanvas.SetActive(false);
        controller.UnfreezeCam();
        isOpen = false;
     }
}
