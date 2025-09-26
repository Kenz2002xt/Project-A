using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Code configured with inspiration from "Ending the Game" tutorial by Unity Learn highlighting fade mechanics- repurposed for specific game use
public class DayCycleManager : MonoBehaviour
{
    public int currentDay = 1; //this will track which day the player is currently on
    public int maxDays = 3; //total number of expedition days

    public TextMeshProUGUI DayText;
    public Image FadePanel;

    //Messages for each corresponding day 
    public string[] dayMessages = new string[3] //setting an array of strings
    {
        "Day 1: Read Instructions And Head to Site A",
        "Day 2: Head to Site B",
        "Day 3: Head to Site C"
    };

    private bool sleeping = false; //bool to keep track of the players sleeping state


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (FadePanel != null)
            FadePanel.color = new Color(0, 0, 0, 1); //starts the alpha of the black image as fully visible at start

        ShowDayText(); //shows the message for the first day
        Invoke("HideBlackPanel", 2f); //hides the panel after 2 seconds for readability, the invoke will run this function found later in the script after a delay
    }

    // Update is called once per frame
    void Update()
    {
        if (sleeping) //this will become true if the player presses E on the bed object
        {
            FadePanel.color = new Color(0, 0, 0, 1); //will make the panel fully visible again
            sleeping = false; //stops the sleep so it only runs once

            ResearchCollector research = FindFirstObjectByType<ResearchCollector>(); //find the call in the reseach collector script to reset the points
            if (research != null) research.ResetResearchPoints();

            if (currentDay < maxDays) //as long as the player isnt at the max, move to the next day
            {
                currentDay = currentDay + 1;
                ShowDayText(); //show message for next day
                Invoke("HideBlackPanel", 2f);
            } 
            else //if player goes over max then go to game over for completion 
            {
                GameOverSummary.endMessage = "Expediton Complete"; 
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    //This is what displays the day cycle messages
    void ShowDayText()
    {
        if (DayText != null)
        {
            DayText.text = dayMessages[currentDay - 1]; //this will find the correct message from the array since the array starts with an index of 0, but the days are 1,2,3
            DayText.gameObject.SetActive(true); //makes the text element visible
            Invoke("HideDayText", 2f); //will also hide the text after two seconds
        }
    }

    //hides the day text
    void HideDayText()
    {
        if (DayText != null)
            DayText.gameObject.SetActive(false); //makes the text element invisible 
    }

    void HideBlackPanel()
    {
        if (FadePanel != null)
            FadePanel.color = new Color(0, 0, 0, 0); //Makes the alpha of the panel back to transparent 
    }

    //This will be called by the bed script once the player hits E
    public void PlayerSleep()
    {
        sleeping = true; //sets sleeping bool to true
    }
}
