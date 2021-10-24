using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;

    private float seconds = 0;
    private int minutes = 0;
    private int secondsInt = 0;

    void Update()
    {
        SetTimer();
    }
    
    private void SetTimer()
    {
        seconds += Time.deltaTime;
        if(seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }
        secondsInt = (int)seconds;

        if (seconds < 10)
        {
            timerText.text = minutes.ToString() + ":0" + secondsInt.ToString();
        }
        else
        {
            timerText.text = minutes.ToString() + ":" + secondsInt.ToString();
        }
        PlayerPrefs.SetString("Timer", timerText.text);
    }
}
