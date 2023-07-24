using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//store information regarding whether new levels are unlocked
public class LevelScript : MonoBehaviour
{
    //public List<bool> levelUnlocked;

    public int level2;
    public string level2Name = "level2";

    public int level3;
    public string level3Name = "level3";

    // Start is called before the first frame update
    void Start()
    {
        //first level should always be unlocked
        //levelUnlocked[0] = true;

        level2 = PlayerPrefs.GetInt(level2Name, level2);
        level3 = PlayerPrefs.GetInt(level3Name, level3);
    }
}
