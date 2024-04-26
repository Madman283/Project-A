using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePopup : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI coinsText;
    public Button restartButton;
    public Button mainMenuButton;

    // Method to set the points and coins text
    public void SetPointsAndCoins(int points, int coins)
    {
        pointsText.text = "Points: " + points.ToString();
        coinsText.text = "Coins: " + coins.ToString();
    }

    // Method to restart the game
    public void RestartGame()
    {
        // Restart the game by reloading the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Method to return to the main menu
    public void ReturnToMainMenu()
    {
        // Load the main menu scene by name
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    // Method to enable the popup menu
    public void ShowPopupMenu()
    {
        // Enable the popup menu GameObject
        gameObject.SetActive(true);
        Debug.Log("Showing popup menu");
    }
}
