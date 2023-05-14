using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //щрн йняршкэ - ядекюрэ юдейбюрмн
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            //int backtomenu = 0;
            //SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(backtomenu).buildIndex);

            //string backtomenu = SceneManager.GetSceneByName("Menu").name;
            //SceneManager.LoadScene(SceneManager.GetSceneByName(backtomenu).buildIndex);
        }
    }
}
