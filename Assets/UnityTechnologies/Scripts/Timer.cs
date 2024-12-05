using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Assertions.Must;

public class Timer : MonoBehaviour
{

    public float timeRemaining;
    bool timerRunning = false;
    public float fadeDuration = 1f;
    float m_Timer;

    public TextMeshProUGUI timerText;
    public GameEnding gameEnding;
    public CanvasGroup textCanvasGroup;
    bool m_IsPlayerAtExit;
    
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 60;
        timerRunning = true;
        //TimerText(timeRemaining);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining = timeRemaining -= Time.deltaTime;
        }

        else if (gameEnding.m_IsPlayerAtExit == true)
        {
            m_Timer -= Time.deltaTime;
            textCanvasGroup.alpha = m_Timer / fadeDuration;
        }

        else
        {
            timeRemaining = 0;
            timerRunning = false;
            if(timerRunning == false)
            {
                gameEnding.CaughtPlayer(); 
            }
        }
        
        TimeSpan time = TimeSpan.FromSeconds(timeRemaining);
        timerText.text = "Time Remaining: " + timeRemaining;
    }

    void TimerText(float timeDisplay)
    {
        //timerText.text = string();
    }
}
