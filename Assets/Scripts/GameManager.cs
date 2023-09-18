using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject continuePanel;
    [SerializeField] private Rigidbody2D rbShip;

    public Text scoreText;
    public float score;
    public bool isStart;
    float shipFallSpeed = 0;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        continuePanel.SetActive(false);
    }
    public void PlayGame()
    {
        mainMenuPanel.SetActive(false);
        rbShip.gravityScale = 1;
       
       
            isStart = true;
        

        
    }

    private void Update()
    {
        if (isStart)
        {
            // Tinh diem cho player
            // Tang gia tri de ship roi nhanh hon
            shipFallSpeed = Mathf.MoveTowards(shipFallSpeed, Constants.MAX_SPEED, 0.5f * Time.deltaTime);
        }
        rbShip.velocity = new Vector2(0, -shipFallSpeed);
        score += shipFallSpeed * Time.deltaTime;
        scoreText.text = "SCORE: " + Mathf.FloorToInt(score).ToString();
    }

    public void GameOver()
    {
        // Handle game over state
        shipFallSpeed = 0f;
        enabled = false;
        continuePanel.SetActive(true); 
       // isStart = false;
    }


    public void RestartLevel()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        


    }
}