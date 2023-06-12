using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInInverse : MonoBehaviour
{
    public GameObject child;
    private void OnDisable()
    {
        Debug.Log("������ ����������");
        vision.VisionOn_ev_alt += ShowObj;

        
    }
    private void OnEnable()
    {
        Debug.Log("������ ���������");
        vision.VisionOn_ev_alt -= ShowObj;
        vision.VisionOff_ev_alt += HideObj;
    }

    private void HideObj()
    {
        Debug.Log("������ �������");
        child.SetActive(false);
    }

    private void ShowObj()
    {
        Debug.Log("������ 2 ��������");
        child.SetActive(true);
    }
}
