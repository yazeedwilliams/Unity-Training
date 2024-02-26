using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimerX : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60.0f; // Set the initial countdown time in seconds 

    private float currentTime;

    void Start()
    {
        currentTime = countdownTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Decrement the time
            UpdateTimerDisplay();
        }
        else
        {
            currentTime = 0;
            // Handle what happens when the timer reaches zero (e.g., game over, trigger an event, etc.)
        }
    }

    void UpdateTimerDisplay()
    {
        // Update the text to display the current time in the format "0:00"
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"Time: {minutes}: {seconds}";
    }
}
