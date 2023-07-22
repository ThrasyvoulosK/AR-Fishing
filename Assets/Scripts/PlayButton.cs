using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //load the first available scene
    public void PlayLevel()
    {
        //TEMP: Currently there's only one scene!
        SceneManager.LoadScene(1);
    }

    public void GoToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
