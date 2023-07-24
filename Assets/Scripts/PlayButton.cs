using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    //load the first available scene (level select)
    public void PlayLevel()
    {
        SceneManager.LoadScene(1);
    }

    //change to a specific scene
    public void GoToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
