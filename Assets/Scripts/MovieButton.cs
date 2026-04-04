using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class MovieButton : MonoBehaviour
{
    public AddedMovieButton addedMovieButton;

    public string movieName;
    public string movieTime;
    public int audi;

    public int duration_minute;
    public int start_minute;
    public int addedMovieIndex;

    [Space]

    [SerializeField]
    private TextMeshProUGUI ui_movieName;
    [SerializeField]
    private TextMeshProUGUI ui_movieTime;
    [SerializeField]
    private TextMeshProUGUI ui_audi;
    [SerializeField]
    private Image ui_movieIcon;

    private TicketMachine ticketMachine;
    private void Start()
    {
        ticketMachine = GameObject.Find("ticket").GetComponent<TicketMachine>();
    }
    public void Init()
    {
        ui_movieName.text = addedMovieButton.show.movie.mvName;
        duration_minute = addedMovieButton.show.movie.duration;
        start_minute = addedMovieButton.show.startTime;
        ui_audi.text = audi.ToString();
        if(addedMovieButton.show.movie.icon)
            ui_movieIcon.sprite = addedMovieButton.show.movie.icon.sprite;


        //calculating time of movie
        movieTime = FormatTime(start_minute) + " : " + FormatTime(duration_minute + start_minute);
        ui_movieTime.text = movieTime;
        
    }
    public void SelectMovie()
    {
        ticketMachine.SelectWindow(2, addedMovieIndex);
    }
    string FormatTime(int start_min)
    {
        int hour = (start_min / 60);
        int minute = (start_min % 60);
        string ampm = "AM";

        if(hour >= 12)
        {
            ampm = "PM";
            if(hour > 12)
                hour -= 12;
        }

        return $"{hour}:{minute:D2} {ampm}";

    }
}
