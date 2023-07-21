using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockLevel(int level,string levelName)
    {
        //FindObjectOfType<LevelScript>().level2 = PlayerPrefs.SetInt(levelName, 1);
        PlayerPrefs.SetInt(levelName, level);
    }
    public void UnlockLevel2()
    {
        Debug.Log("Level 2 Unlocked");
        PlayerPrefs.SetInt("level2", 1);
    }
}
