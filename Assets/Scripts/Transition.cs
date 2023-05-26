using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Transition : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Vision"))
        {
            Debug.Log("Анимация пошла");
            anim.SetBool("IsTransition", true);
        }
        else
        {
            anim.SetBool("IsTransition", false);
        }

    }
}
