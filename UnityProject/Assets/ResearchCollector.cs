using UnityEngine;
using TMPro;

public class ResearchCollector : MonoBehaviour
{

    public int ResearchPoints = 0; //the amount of points the player has collected
    public int MaxResearchPoints = 3; //max amount of points per site and per day
    public TextMeshProUGUI DataText; //data text UI element in canvas under data items


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateResearchText(); //shows the starting value is 0 for player
    }

    //this will be called from the ResearchItem when the player presses E in order to add a point
    public void AddResearchPoint()
    {
        if (ResearchPoints < MaxResearchPoints)
        {
            ResearchPoints = ResearchPoints + 1;
            UpdateResearchText();
        }
    }

    //method for updates to the UI Text
    private void UpdateResearchText()
    {
        if (DataText != null) //if data text does not equal null then update UI with score
        {
            DataText.text = "Research Found: " + ResearchPoints;
        }
    }

    //logic will be used later during day cycles
    public void ResetResearchPoints()
    {
        ResearchPoints = 0;
        UpdateResearchText ();
    }
}
