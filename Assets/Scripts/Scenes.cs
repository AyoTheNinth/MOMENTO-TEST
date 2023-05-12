using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void SceneSwitch(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
