using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{

    public TextMeshProUGUI conditionText; //Text field for game over conditions
    public TextMeshProUGUI dataText; //text to display performance based on data collected- also shows total time

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //unlocks cursor for player to use 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        DisplayGameOver(); //calls to display game over info
    }

    // Update is called once per frame
    void DisplayGameOver()
    {
        if (conditionText != null)
            conditionText.text = GameOverSummary.endMessage; //set condition to game over summary end message

        //Data Text
        if (dataText != null)
        {
            string performance;

            //Determines performance message based on total research
            if (GameOverSummary.totalResearch >= 6)
            {
                performance = "Well Done";
            }

            else
            {
                performance = "Do Better Next Time";
            }

            //formats the minutes and seconds from totalTime is totalTime is in seconds
            int minutes = (int)(GameOverSummary.totalTime / 60);
            int seconds = (int)(GameOverSummary.totalTime % 60);

            //the "\n" is a newline character that will move to text to the next line so its formatted correctly

            //first is the performance text
            string text = performance + "\n";

            //next is the data collected amount 
            text = text + "Data Collected: " + GameOverSummary.totalResearch + "\n";

            //last line is the travel time total
            text = text + "Travel Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");


            //puts the constructed string into the UI element 
            dataText.text = text;
        }
    }
}
