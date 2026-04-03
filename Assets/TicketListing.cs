using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TicketListing : MonoBehaviour
{
    public int movieListingMargin;
    public GameObject movieButton;
    public GameObject movieButtonPlaceholder;
    public GameObject firstPlaceTrans;

    private void Start()
    {
        AddMovie(0, 1, 330);
        AddMovie(1, 1, 600);
    }
    public void AddMovie(int ind, int audi, int start_minute)
    {
        GameObject obj = Instantiate(movieButton);

        // set correct parent FIRST
        obj.transform.SetParent(movieButtonPlaceholder.transform, false);

        RectTransform target = firstPlaceTrans.GetComponent<RectTransform>();
        RectTransform rt = obj.GetComponent<RectTransform>();

        // copy layout values
        rt.anchorMin = target.anchorMin;
        rt.anchorMax = target.anchorMax;
        rt.pivot = target.pivot;

        rt.anchoredPosition = target.anchoredPosition;
        rt.sizeDelta = target.sizeDelta;
        rt.localScale = target.localScale;

        rt.anchoredPosition -= new Vector2(0, Theater.Instance.addedMovie.Count * movieListingMargin);

        //passing only audi, start_minute and index, rest details will be fetched from movie data with the index in button script
        MovieButton mb = obj.GetComponent<MovieButton>();
        mb.audi = audi;
        mb.start_minute = start_minute;
        mb.index = ind;
        mb.addedMovieIndex = Theater.Instance.addedMovie.Count;
        mb.movieName = Theater.Instance.movies[ind].name;
        mb.Init();

        // add features to calculate start and end time of movie in suitable script

        obj.GetComponent<MovieButton>().Init();

        
        //set button obj
        Theater.Instance.addedMovieTemp.buttonObj = obj;

        //set audi
        foreach (var aud in Theater.Instance.audis)
        {
            if(aud.audiNo == audi)
            {
                Theater.Instance.addedMovieTemp.audi = aud;
            }
        }
        
        // fix the object referencing
        Theater.Instance.addedMovie.Add(new AddedMovie(obj, Theater.Instance.addedMovieTemp.audi));
        
    }
}
