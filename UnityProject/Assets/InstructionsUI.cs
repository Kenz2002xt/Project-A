using UnityEngine;

//short script for UI panel close button
public class InstructionsUI : MonoBehaviour
{
    public GameObject instructionsPanel;

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false); //when button clicked then hide instructions
        Cursor.lockState = CursorLockMode.Locked; //lock cursor
        Cursor.visible = false;
        Time.timeScale = 1f; //unfreeze gameplay
    }
}
