using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inter_inorigin : MonoBehaviour
{
    private void OnEnable()
    {
        vision.VisionOn_ev += HideObj;
    }
    private void OnDisable()
    {
        vision.VisionOn_ev -= HideObj;
        vision.VisionOff_ev += ShowObj;
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
