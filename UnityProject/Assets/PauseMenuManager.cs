using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Pause Menu script created with help from "6 Minute PAUSE MENU Unity Tutorial" by BMo on YouTube

public class PauseMenuManager : MonoBehaviour
{
    //References to pause canvas, pause panels, adjustment sliders, audio source, light, and camera
    public Canvas pauseMenu;
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public Slider audioSlider;
    public Slider brightnessSlider;
    public Light headLamp;
    public AudioSource windAudio;
    public FirstPersonLook cameraController;

    private bool isPaused = false; //boolean tracking if the game is paused


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.enabled = true; //ensures the menu is initally visible but the panels are hidden
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);

        if (windAudio == null) //will find the audio source if none is assigned
            windAudio = FindFirstObjectByType<AudioSource>();

    
        if (windAudio != null) //sets initial volume (which will be the max)
           windAudio.volume = 0.5f;

        if (audioSlider != null) //sets the initial slider values
            audioSlider.value = 1f;

        if (headLamp != null)
            brightnessSlider.value = headLamp.intensity - 246f; //baseline intensity adjustment for light
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) //listens for the escape key to be pressed to pause
        {
            if (isPaused) Resume();
            else Pause();
        }

        if (windAudio != null && audioSlider != null)
        {
            windAudio.volume = 0.5f * audioSlider.value; //updates the volume based on slider
        }

        if (headLamp != null && brightnessSlider != null)
            headLamp.intensity = 246f + brightnessSlider.value; //updates teh brightness based on slider
    }

    public void Pause()
    { 
        pausePanel.SetActive(true); //will show the pause panel
        optionsPanel.SetActive(false); //hides the options panel
        Time.timeScale = 0f; //stops game time
        isPaused = true;

        //unlocking the cursor so the player can press buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //stops the camera movement while paused
        if (cameraController != null)
            cameraController.enabled = false;
    }

    public void Resume() //resumes the game
    {
        //hides the panels and resumes the game time- also locking the cursor and starting camera movement
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cameraController != null)
            cameraController.enabled = true;
    }

    public void OpenOptions() //opens options panel from pause
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void CloseOptions() //closes options to return to pause
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void ReturnToMainMenu() //will return player to main start menu
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
