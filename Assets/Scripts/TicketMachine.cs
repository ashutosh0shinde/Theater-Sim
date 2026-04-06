using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TicketMachine : MonoBehaviour, IInteractable, ICrosstext
{
    [SerializeField] private string crosstext;

    [SerializeField] private GameObject ticketMachineCanvas;
    [SerializeField] private GameObject ticketMachine_movieCanvas;
    [SerializeField] private GameObject ticketMachine_seatCanvas;

    [SerializeField] private GameObject ticketMachine_ticketConfCanvas;
    [SerializeField] private TextMeshProUGUI ticketConfText;

    [SerializeField] private GameObject[] seat_layout;
    [SerializeField] private TextMeshProUGUI movieName_seatSelection;
    [SerializeField] private AddedMovieButton currentAddMovieButton;
    [SerializeField] private int currentSelectedSeat;

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
    public void SetSeatLayout(int ind)
    {
        foreach (var obj in seat_layout)
        {
            obj.SetActive(false);
        }
        seat_layout[ind].SetActive(true);

        for (int i = 0; i < seat_layout[ind].transform.childCount;i++)
        {
            seat_layout[ind].transform.GetChild(i).GetComponent<Button>().interactable = true;
            if (currentAddMovieButton.show.seatsStatus[i])
            {
                seat_layout[ind].transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }
    public void SelectWindow(int i, AddedMovieButton addedMovieButton = null)
    {
        if(i == 1)
        {
            ticketMachine_movieCanvas.SetActive(true);
            ticketMachine_seatCanvas.SetActive(false);
        }
        else if (i == 2)
        {
            ticketMachine_movieCanvas.SetActive(false);

            currentAddMovieButton  = addedMovieButton;
            SetSeatLayout(addedMovieButton.show.audi.audiNo-1);
            movieName_seatSelection.text = addedMovieButton.show.movie.mvName;
            ticketMachine_seatCanvas.SetActive(true);
        }
    }
    public void TicketConfirmWindow(int seat)
    {
        currentSelectedSeat = seat;
        ticketConfText.text = $"Confirm Seat: {seat}";
        ticketMachine_ticketConfCanvas.SetActive(true);
    }
    public void ConfirmTicket()
    {
        // replace with actual booking
        // check if its already booked before confirming
        currentAddMovieButton.show.seatsStatus[currentSelectedSeat-1] = true;
        Debug.Log("Booking Successfull");
        Debug.Log($"Seat: {currentSelectedSeat} | Audi: {currentAddMovieButton.show.audi.audiNo} | Movie: {currentAddMovieButton.show.movie.mvName}");

        Close();
    }
    public void CancelTicket()
    {
        ticketMachine_ticketConfCanvas.SetActive(false);
    }
    public void BackFromTicketSelection()
    {
        ticketMachine_seatCanvas.SetActive(false);
        ticketMachine_ticketConfCanvas.SetActive(false);
        ticketMachine_movieCanvas.SetActive(true);
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
        ticketMachine_ticketConfCanvas.SetActive(false);
        controller.UnfreezeCam();
        isOpen = false;
     }
}
