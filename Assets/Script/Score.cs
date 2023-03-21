using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text time;

    private bool timerRunning = true;

    private float timePass = 0f;
    private float minutes;
    private float seconds;
    public void SetTimerRunning(bool value) 
    { 
        timerRunning = value; 
    }

    private void Update()
    {
        if (timerRunning)
        {
            minutes = Mathf.FloorToInt(timePass / 60);
            seconds = Mathf.FloorToInt(timePass % 60);
            timePass += Time.deltaTime;
            time.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        }
    }

    public float getMinutes()
    {
        return minutes;
    }

    public float getSeconds()
    {
        return seconds;
    }
}
