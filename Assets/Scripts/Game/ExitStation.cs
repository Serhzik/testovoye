using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStation : MonoBehaviour {
    Station station;
    private void Start()
    {
        station = GetComponentInParent<Station>();
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            station.Exit();
        }
    }
}
