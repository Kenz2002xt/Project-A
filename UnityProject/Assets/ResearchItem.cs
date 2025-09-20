using UnityEngine;
using TMPro;
using Unity.VisualScripting;


//Code created alongside reference to the "Collect the collectible" tutorial from Unity Learn

public class ResearchItem : MonoBehaviour
{

    public TextMeshProUGUI PromptText; //this is the "Press E to Collect" text
    private bool NearPlayer = false; //bool check if the player is close enough. NearPlayer is a variable used to keep track later in the code


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //these are private since only this script can call the methods 
    private void Start()
    {
        //if prompt text isn't empty then set it to false so its hidden since we only want it to appear when the players close
        if (PromptText != null)
            PromptText.gameObject.SetActive(false);
    }

    //this will run when the player touches the research objects trigger
    private void OnTriggerEnter(Collider other)
    {
        //checking if the thing that entered was the player (player has the "Player" tag)
        if (other.CompareTag("Player"))
        {
            //essentially marking down that the player is near
            NearPlayer = true;
            if (PromptText != null) //again just an extra check to make sure PromptText exists before trying to use it
                PromptText.gameObject.SetActive(true); //making the prompt text visible to player
        }
    }

    //similar to above, but it will run once the player exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NearPlayer = false; //marks down that the player is no longer near
            if (PromptText != null)
                PromptText.gameObject.SetActive(false); //hiding the text again
        }
    }
    // Update is called once per frame
    private void Update()
    {
        if (NearPlayer && Input.GetKeyDown(KeyCode.E)) //this is a double check with the "&&". Checking that the player is by the trigger and pressed the E key
        {
            ResearchCollector collector = FindFirstObjectByType<ResearchCollector>(); //this will find the ResearchCollector script on the player that was made and give it a variable name of collector
            if (collector != null) //as long as the script is found the below will run
            {
                collector.AddResearchPoint(); //a point is added
            }

            //the rest of the code below will hide the prompt text since the player completed the prompt and it will remove the research item object since it was collected 
            if (PromptText != null)
                PromptText.gameObject.SetActive(false);

            Destroy(gameObject);
        }
    }
}
