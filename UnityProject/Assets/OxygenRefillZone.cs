using UnityEngine;

//refill script for special zone during path C
//logic is taken from original oxygen system script

public class OxygenRefillZone : MonoBehaviour
{
    private bool playerInside = false;

    private void Update()
    {
        if (playerInside)
        {
            OxygenSystem oxygen = FindFirstObjectByType<OxygenSystem>();
            if (oxygen != null)
            {
                oxygen.currentOxygen = oxygen.maxOxygen;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           playerInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
