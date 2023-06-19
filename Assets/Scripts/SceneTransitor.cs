using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : MonoBehaviour
{
    private static SceneTransitor transitor;
    private AsyncOperation loadingscene;
    private Animator anim;

    private static bool PlayAnim = false;

    void Start()
    {
        transitor = this;

        anim = GetComponent<Animator>();

        if (PlayAnim == true)
        {
            anim.SetTrigger("TransitionEnd");
        }
    }
    
    public void SwitchToScene(string sceneName)
    {
        transitor.anim.SetTrigger("TransitionStart");
        transitor.loadingscene = SceneManager.LoadSceneAsync(sceneName);
        transitor.loadingscene.allowSceneActivation = false;
    }

    public void SwitchToSceneInstaa(string sceneName)
    {
        transitor.anim.SetTrigger("TransitionStart");
        SceneManager.LoadScene(sceneName);
        //transitor.loadingscene.allowSceneActivation = false;
    }

    public void OnAnimOver()
    {
        PlayAnim = true;
        transitor.loadingscene.allowSceneActivation = true;
    }
    public IEnumerator Fade()
    {
        anim.SetTrigger("FadeStart");
        yield return new WaitForSeconds(1);
        anim.SetTrigger("FadeEnd");

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
