using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vision : MonoBehaviour
{

    public GameObject eyes;
    public bool visionOn;
    bool staminaZero;
    float totalStamina = 6;
    float fullStamina = 6;

    [SerializeField] public Slider staminabar;

    public static Action VisionOn_ev;
    public static Action VisionOff_ev;

    // Start is called before the first frame update
    void Start()
    {
        //staminabar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();
        eyes = GameObject.FindGameObjectWithTag("Vision");
        eyes.SetActive(false);
        visionOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vision();
        StaminaIsDepleting();
        StaminaUpdate(totalStamina);
    }
    private void Vision()
    {
        if (Input.GetButtonDown("Vision") && visionOn == false && staminaZero == false)
        {
            if( staminaZero != true)
            {
                SetVisionOn();
            }
            
        }
        else if (Input.GetButtonDown("Vision") && visionOn == true)
        {
            SetVisionOff();
        }
    }
    
    private void StaminaUpdate(float maxStamina)
    {
        staminabar.value = maxStamina;
    }

    private void SetVisionOn()
    {
        Debug.Log(KeyCode.Q + "нажата");
        visionOn = true;
        eyes.SetActive(true);
        VisionOn_ev.Invoke();
        
    }
    private void SetVisionOff()
    {
        visionOn = false;
        eyes.SetActive(false);
        VisionOff_ev.Invoke();
    }

    private void StaminaIsDepleting()
    {
        if (visionOn == true && staminaZero == false)
        {
            if (totalStamina > 0f)
            {
                
                totalStamina -= 1 * Time.deltaTime;
                Debug.Log(totalStamina);
            }
            else
            {
                totalStamina = 0;
                staminaZero = true;
                visionOn = false;
                SetVisionOff();
                Debug.Log("Стамина кончилась");
            }
        }
        if (staminaZero == true || (totalStamina < fullStamina && visionOn == false))
            {
                totalStamina += 1 * Time.deltaTime;
                Debug.Log("Стамина перезаряжается");
            Debug.Log(totalStamina);
            Debug.Log(staminaZero);
            staminaZero = false;
        }
    }
}