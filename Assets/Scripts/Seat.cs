using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public int audi;
    public int seatNo;
    public bool isReserved;
    public Transform standPos;

    private void Start()
    {
        standPos = transform.GetChild(0);
    }
}
