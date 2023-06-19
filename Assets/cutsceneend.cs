using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneend : MonoBehaviour
{
    //public SceneTransitor transit;
    void Start()
    {
        //transit.SwitchToScene("GameScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
