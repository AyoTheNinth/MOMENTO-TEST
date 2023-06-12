using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testvisioninterac1 : MonoBehaviour
{
    private void OnDisable()
    {
        vision.VisionOn_ev_alt += ShowObj;
    }
    private void OnEnable()
    {
        vision.VisionOn_ev_alt -= ShowObj;
        vision.VisionOff_ev_alt += HideObj;
    }

    private void HideObj()
    {
        gameObject.SetActive(false);
    }

    private void ShowObj()
    {
        gameObject.SetActive(true);
    }
}
