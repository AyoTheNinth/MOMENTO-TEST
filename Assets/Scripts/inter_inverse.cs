using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inter_inverse : MonoBehaviour
{
    public GameObject interactableObject;
    private void OnEnable()
    {
        vision.VisionOn_ev += ShowObj;
        vision.VisionOff_ev += HideObj;
    }
    private void OnDisable()
    {
        vision.VisionOn_ev -= HideObj;
        vision.VisionOff_ev -= ShowObj;
    }

    private void HideObj()
    {
        interactableObject.SetActive(false);
    }

    private void ShowObj()
    {
        interactableObject.SetActive(true);
    }

}
