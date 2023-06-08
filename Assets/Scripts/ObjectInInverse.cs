using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInInverse : MonoBehaviour
{

    public GameObject child;
    private void OnEnable()
    {
        vision.VisionOn_ev += ShowObj;
    }
    private void OnDisable()
    {
        vision.VisionOn_ev -= ShowObj;
        vision.VisionOff_ev += HideObj;
    }

    private void HideObj()
    {
        child.SetActive(false);
    }

    private void ShowObj()
    {
        child.SetActive(true);
    }
}
