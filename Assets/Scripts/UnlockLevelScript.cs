using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //check score for level 2
        int currentScore = PlayerPrefs.GetInt("score");
        Debug.Log("Checking if score unlocks level: " + currentScore);
        if(currentScore>=1000)
        {
            UnlockLevel(1, "level2");
            Debug.Log(PlayerPrefs.GetInt("level2"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockLevel(int level,string levelName)
    {
        PlayerPrefs.SetInt(levelName, level);
    }
    public void UnlockLevel3()
    {
        Debug.Log("Level 3 Unlocked");
        PlayerPrefs.SetInt("level3", 1);
    }

    /*public void UnlockLevel3()
    {
        Debug.Log("Level 3 Unlocked");
        PlayerPrefs.SetInt("level3", 1);
    }*/
}
