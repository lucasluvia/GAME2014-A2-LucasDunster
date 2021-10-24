using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI timerText;


    private string score;
    private string timer;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetString("Score");
        timer = PlayerPrefs.GetString("Timer");

        scoreText.text = score;
        timerText.text = timer;
    }

}
