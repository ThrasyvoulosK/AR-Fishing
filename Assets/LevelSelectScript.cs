using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectScript : MonoBehaviour
{
    public List<GameObject> levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        levelButtons[0].GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
