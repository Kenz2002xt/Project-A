using UnityEngine;


//short script for instruction UI Panel

public class InstructionBook : MonoBehaviour
{
    public GameObject instructionsPanel;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) //when pressing E on the game object
        {
            instructionsPanel.SetActive(true); //show instructions
            Cursor.lockState = CursorLockMode.None; //unlock cursor
            Cursor.visible = true;
            Time.timeScale = 0f; //pause game
        }
    }
}
