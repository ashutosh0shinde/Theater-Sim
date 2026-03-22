using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PickableObjectManager : MonoBehaviour, ICrosstext
{
    [SerializeField] private string crosstext;
    public string CrossText => crosstext;
}
