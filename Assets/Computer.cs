using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour, IInteractable, ICrosstext
{
    [SerializeField] private string crosstext;
    public string CrossText => crosstext;

   public void Interact()
   {
        Debug.Log("jdsfa");
   }
}
