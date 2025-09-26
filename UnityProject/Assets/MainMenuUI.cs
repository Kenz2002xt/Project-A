using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        //resets the game totals for a new run
        GameOverSummary.totalResearch = 0;
        GameOverSummary.totalTime = 0f;

        SceneManager.LoadScene("MainScene"); //Gameplay scene
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //Main menu
    }
    public void OpenControls()
    {
        SceneManager.LoadScene("ControlsScene"); //Controls menu
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("CreditsScene"); //Credits menu
    }
}