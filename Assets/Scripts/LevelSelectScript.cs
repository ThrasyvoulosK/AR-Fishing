using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//check if the levels are unlocked and set the message below them accordingly
public class LevelSelectScript : MonoBehaviour
{
    public List<GameObject> levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        levelButtons[0].GetComponent<Button>().interactable = true;

        //if the levels are unlocked, allow them to be selected
        for(int i=1;i<levelButtons.Count;i++)
        {
            int levl = PlayerPrefs.GetInt("level" + (i+1).ToString());
            //Debug.Log("level" + i.ToString());
            //Debug.Log("is level interactable? " + levl+" "+i.ToString());
            if (levl==1)
            {
                levelButtons[i].GetComponent<Button>().interactable = true;

                //change their description to 'unlocked', too
                levelButtons[i].transform.parent.transform.Find("Subtitle").GetComponent<TextMeshProUGUI>().SetText("Unlocked!");
            }
        }
    }
}
