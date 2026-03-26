using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieButton : MonoBehaviour
{
    public string movieName;
    public int duration_minute;
    public int start_hour;
    public int start_minute;
    public string movieTime;
    public int audi;
    public int index;

    private TicketMachine ticketMachine;
    private void Start()
    {
        ticketMachine = GameObject.Find("ticket").GetComponent<TicketMachine>();
    }
    public void Init()
    {

    }
    public void SelectMovie()
    {
        
    }
}
