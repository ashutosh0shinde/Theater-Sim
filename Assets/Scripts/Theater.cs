using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class TicketQueuePos
{
    public Transform pos;
    public bool isReserved = false;
    public CustomerAI customerAI;
}


[System.Serializable]
public class MovieClass
{
    public string name;
    public int duration;
    public Image icon;
    public Image poster;
}


[System.Serializable]
public class Audi
{
    public int audi;
    public GameObject[] seats; //object of seat, and its first child its standing position in front of seat
}



public class Theater : MonoBehaviour
{
    public static Theater Instance;

    public TicketQueuePos[] ticketQueuePos;
    public MovieClass[] movies;
    public Audi[] audis;
    public List<GameObject> addedMovie = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }
}
