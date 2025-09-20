using UnityEngine;

public class Bed : MonoBehaviour
{
    private bool NearPlayer = false; //tracks using bool is the player is nearby


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            NearPlayer = true; //marks that player is near the bed
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NearPlayer = false; //marks that the player is no longer near the bed
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!NearPlayer && Input.GetKeyDown(KeyCode.F)) //as long as both are true the following will run
        {
            DayCycleManager DayCycle = FindFirstObjectByType<DayCycleManager>(); //accesses the day cycle manager script and runs sleep 
            if (DayCycle != null)
            {
                DayCycle.PlayerSleep();
            }
        }
    }
}
