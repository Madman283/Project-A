using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public AudioSource cameraAudio;

    public float jumpForce = 10f;
    public float gravityModifier = 2f;
    public bool isOnGround = true;
    public bool gameOver = false;

    // UI elements
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI coinsText;
    private int totalPoints = 0;
    private int coinsCollected = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); // Rigidbody2D instead of Rigidbody
        playerAnim = GetComponent<Animator>(); // Animator
        Physics2D.gravity *= gravityModifier; // Use Physics2D for 2D physics
        playerAudio = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Vector2 for 2D, ForceMode2D instead of ForceMode
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (!gameOver)
        {
            totalPoints++; // Increment points continuously if the game is not over
            UpdateUI(); // Update UI with new points value
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            Debug.Log("Game Over");
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            cameraAudio.Stop();
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            // Increment coins collected
            coinsCollected++;
            // Update UI for coins
            UpdateUI();
            // Destroy the coin object
            Destroy(other.gameObject);
            // Optionally, you can add a sound effect for collecting coins here
            // playerAudio.PlayOneShot(coinCollectSound, 1.0f);
        }
    }

    // Method to update UI text for points and coins
    void UpdateUI()
    {
        pointsText.text = "Points: " + totalPoints.ToString();
        coinsText.text = "Coins: " + coinsCollected.ToString();
    }

    // Method to reset points and coins (call this when resetting the game)
    void ResetUI()
    {
        totalPoints = 0;
        coinsCollected = 0;
        UpdateUI();
    }
}
