using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

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
    public string mvName;
    public int duration;
    public Image icon;
    public Image poster;
}


[System.Serializable]
public class Audi
{
    public int audiNo;
    public int noOfSeats;
    public GameObject[] seats; //object of seat, and its first child its standing position in front of seat
}


[System.Serializable]
public class Show
{
    public MovieClass movie;
    public Audi audi;
    public bool[] seatsStatus;
    public int startTime;

    public Show(int movieInd, int audiInd, int start_time)
    {
        this.movie = Theater.Instance.movies[movieInd];
        this.audi = Theater.Instance.audis[audiInd-1];
        this.seatsStatus = new bool[audi.noOfSeats];
        this.startTime = start_time;
    }
}


[System.Serializable]
public class AddedMovieButton
{
    public GameObject buttonObj;
    public Show show;
}



public class Theater : MonoBehaviour
{
    public static Theater Instance;

    public TicketQueuePos[] ticketQueuePos;
    public MovieClass[] movies;
    public Audi[] audis;

    public List<AddedMovieButton> addedMovie = new List<AddedMovieButton>();
    public List<Show> shows = new List<Show>();

    private void Awake()
    {
        Instance = this;
    }
}
