using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float timeLeft = 60f; // ‚¿ŠÔi•bj
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // ŠÔØ‚ê‚Ìˆ—
            timeLeft = 0;
            Debug.Log("Time's up!");
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
