using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    public string scoreName = "score";
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt(scoreName, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //add a number to the current value
    public void SetAddInt(string KeyName, int Value,int currentScore)
    {
        int newValue = Value + currentScore;
        PlayerPrefs.SetInt(KeyName, newValue);
    }
}
