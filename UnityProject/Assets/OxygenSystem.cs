using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;



//Script inspiration using "Breakfast With Unity: Oxygen Meter" tutorial by Pushy Pixels on Youtube with personal adjustments 


public class OxygenSystem : MonoBehaviour
{
    //Oxygen settings
    public float maxOxygen = 100f; //maximum oxygen the player can have
    public float currentOxygen; //current oxygen of player
    public float oxygenDepletionRate = 2f; //the amount of oxygen lost per second

    //UI Refrences 
    public Slider OxygenBar; //reference for Oxygen Slider in canvas
    public TextMeshProUGUI TimerText; //refernce for timer text in canvas

    //Timer Reference
    private float elapsedTime = 0f; //time passed (doesn't need to be changed in inspector)

    private bool inBase = false; //tracks if player is inside the base trigger- the bool lets its be a true or false variable


    void Start()
    {
        //Starting with full oxygen
        if (OxygenBar != null) //if oxygen bar is not empty then do the following
        {
            OxygenBar.minValue = 0;
            OxygenBar.maxValue = maxOxygen;
            OxygenBar.value = currentOxygen;
        }
        
    }


    void Update()
    {
        if (!inBase) //only run timer and oxygen bar if not in the base
        {
            //Depleting oxygen over time
            //Time.deltaTime makes sure the oxygen decreases regularly no matter the frame rate
            currentOxygen = currentOxygen - (oxygenDepletionRate * Time.deltaTime);

            //keeps oxygen between 0 and maximum
            if (currentOxygen < 0) currentOxygen = 0;

            //update UI slider
            if (OxygenBar != null) OxygenBar.value = currentOxygen;

            //Game over if oxygen reaches 0- will add more game over logic later
            if (currentOxygen == 0)
            {
                Debug.Log("Oxygen is 0. Game over!");
            }

            //Timer
            elapsedTime = elapsedTime + Time.deltaTime; //adding time since last frame to elapsedTime- keeps track of total time
            int minutes = (int)(elapsedTime / 60); //dividing seconds by 60 and making int to get whole minutes
            int seconds = (int)(elapsedTime % 60); //using %60 to get the leftover seconds after counting the full minutes

            //Updating the timer text in canvas
            if (TimerText != null) //If timer text is not empty then do the following
                TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); //formatting
        }
        else
        {
            //if inside the base the timer stops and oxygen stays max
            currentOxygen = maxOxygen; //refilling to full
            if (OxygenBar != null) OxygenBar.value = currentOxygen; //updating UI
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //only continue if the collider is tagged Base- this avoids confusion with other colliders
        if (other.CompareTag("Base"))
        {
            inBase = true; //player is inside of base

            //elapsed time stops being added to since this marks their journey time so the timer is just updated in the base to show the time
            int minutes = (int)(elapsedTime / 60);
            int seconds = (int)(elapsedTime % 60);

            //Updating the timer text in canvas
            if (TimerText != null) //If timer text is not empty then do the following
                TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); //formatting
        }
    }

    //other is the object collided with
    private void OnTriggerExit(Collider other)
    {
        //check if base trigger was activated
        if (other.tag == "Base") //other.tag used to see tag assigned to object
        {
            inBase = false; //player left the base
            elapsedTime = 0f; //reset the timer
        }
    }
}
