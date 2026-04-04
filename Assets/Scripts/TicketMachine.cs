using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TicketMachine : MonoBehaviour, IInteractable, ICrosstext
{
    [SerializeField] private string crosstext;

    [SerializeField] private GameObject ticketMachineCanvas;
    [SerializeField] private GameObject ticketMachine_movieCanvas;
    [SerializeField] private GameObject ticketMachine_seatCanvas;

    [SerializeField] private GameObject[] seat_layout;
    [SerializeField] private TextMeshProUGUI movieName_seatSelection;

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
    public void SetSeatLayout(int i)
    {
        foreach (var obj in seat_layout)
        {
            obj.SetActive(false);
        }
        seat_layout[i].SetActive(true);
    }
    public void SelectWindow(int i, int addedMovieIndex = 1)
    {
        if(i == 1)
        {
            ticketMachine_movieCanvas.SetActive(true);
            ticketMachine_seatCanvas.SetActive(false);
        }
        else if (i == 2)
        {
            ticketMachine_movieCanvas.SetActive(false);

            //int audi = Theater.Instance.addedMovie[addedMovieIndex].audi.audiNo;
            //SetSeatLayout(audi-1);
            //movieName_seatSelection.text = Theater.Instance.addedMovie[addedMovieIndex].buttonObj.GetComponent<MovieButton>().movieName;
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
