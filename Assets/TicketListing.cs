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

        Show show = new Show(ind, audi-1, start_minute);
        AddedMovieButton addedMovieButton = new AddedMovieButton();
        addedMovieButton.show = show;
        addedMovieButton.buttonObj = obj;

        Theater.Instance.shows.Add(show);
        Theater.Instance.addedMovie.Add(addedMovieButton);
        mb.Init();
        
    }
}
