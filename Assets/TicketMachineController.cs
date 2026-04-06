using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMachineController : MonoBehaviour, IInteractable
{
    public TicketMachine ticketMachine;
    public void Interact()
    {
        ticketMachine.Interact();
    }
}
