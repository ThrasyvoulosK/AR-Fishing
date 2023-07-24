using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void LevelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
