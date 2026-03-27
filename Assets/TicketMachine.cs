using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMachine : MonoBehaviour, IInteractable, ICrosstext
{
    [SerializeField] private string crosstext;
    [SerializeField] private GameObject ticketMachineCanvas;
    public bool isOpen;
    private CameraController controller;
    public int movieListingMargin;
    public GameObject movieButton;
    public GameObject movieButtonPlaceholder;
    public GameObject firstPlaceTrans;
    private void Start()
    {
        controller = GameObject.Find("Camera").GetComponent<CameraController>();

        { // test only
            AddMovie(1, 1, 660);
            AddMovie(0, 2, 760);
            AddMovie(1, 4, 430);
            AddMovie(0, 1, 760);
        }
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
    public void Interact()
    {
        ticketMachineCanvas.SetActive(true);
        controller.FreezeCam();
        isOpen = true;
    }
     public void Close()
     {
        ticketMachineCanvas.SetActive(false);
        controller.UnfreezeCam();
        isOpen = false;
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
        mb.Init();
        
        // add features to calculate start and end time of movie in suitable script

        obj.GetComponent<MovieButton>().Init();
        Theater.Instance.addedMovie.Add(obj);
    }
}
