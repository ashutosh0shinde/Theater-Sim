using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatButtonTicketMachine : MonoBehaviour
{
    public int audi;
    public int seat;
    public TicketMachine ticketMachine;

    public void Start()
    {
        ticketMachine = GameObject.Find("TicketMachine").GetComponent<TicketMachine>();
    }
    public void choseSeat()
    {
        ticketMachine.TicketConfirmWindow(seat);
    }
}
