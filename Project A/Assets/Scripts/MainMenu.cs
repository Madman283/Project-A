using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to be called when the play button is pressed
    public void PlayGame()
    {
        // Load the game scene by name
        SceneManager.LoadScene("NewGame");
    }
}
