using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//keeps a 'score' value, that is also saved in PlayerPrefs
public class Score : MonoBehaviour
{
    public int score;
    public string scoreName = "score";
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt(scoreName, 0);
        scoreText = GameObject.Find("Canvas").transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.SetText("ScorePoints: \n" + score);
    }

    //add a number to the current value
    public void SetAddInt(string KeyName, int Value,int currentScore)
    {
        int newValue = Value + currentScore;
        PlayerPrefs.SetInt(KeyName, newValue);
    }
}
