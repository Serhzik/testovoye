using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterStation : MonoBehaviour {
    Station station;
    private void Start()
    {
        station = GetComponentInParent<Station>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            station.Enter();
        }
    }
}
