using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 3600;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject player;

    public void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

     public void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeText.text = ("You lose!");
                timeRemaining = 0;
                timeText.fontSize = 100;
                
                timerIsRunning = false;
                Destroy(player);
            }
        }
    }

     public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}