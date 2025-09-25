using UnityEngine;

//this script will collect player's time and research points each round- to then add it in for a total once the game is over


public class SubmitData : MonoBehaviour
{

    private bool playerInRange = false; //will keep track if the player is inside of the trigger zone

    public AudioClip submitSound; //sound to play when a player submits the data
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); //will get the audio source attached to the game object
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
            Submit(); //will call submit
        }
    }

    void Submit() //sends research points and time to the GameOverSummary script to be used in the game over menu
    {
        ResearchCollector research = FindFirstObjectByType<ResearchCollector>(); //finds the research collector script in the scene
        OxygenSystem timer = FindFirstObjectByType<OxygenSystem>(); //finds the oxygen system script in the scene

        if (research != null && timer != null) //checks that the scripts exist
        {
            //continues to add the points amd time to the totals in the GameOverSummary script
            GameOverSummary.totalResearch = GameOverSummary.totalResearch + research.ResearchPoints;
            GameOverSummary.totalTime = GameOverSummary.totalTime + timer.elapsedTime;

            Debug.Log("Submitted Data. Research: " + research.ResearchPoints + " Time: " + timer.elapsedTime);
        }

       if (audioSource != null && submitSound != null)
        {
            audioSource.PlayOneShot(submitSound); //plays sound once as long as audio source and the sound are found
            Debug.Log("Audio played- data submitted");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            playerInRange = true; //marks if the player has entered
            Debug.Log("Press R to submit Research");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) //marks that the player has left
        {
            playerInRange = false;
        }
    }
}
