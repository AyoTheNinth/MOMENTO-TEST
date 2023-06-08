using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vision : MonoBehaviour
{
    private Animator anim;
    public GameObject eyes;
    public bool visionOn;
    public bool staminaZero;
    float totalStamina = 8;
    float fullStamina = 8;

    public GameObject eyesanims;
    private Animator eyesanim;

    [SerializeField] public Slider staminabar;

    public static Action VisionOn_ev;
    public static Action VisionOff_ev;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        eyes = GameObject.FindGameObjectWithTag("Vision");
        eyes.SetActive(false);
        visionOn = false;
        eyesanim = eyesanims.GetComponent<Animator>();
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
                StartCoroutine(rout_VisionOn());
            }
            
        }
        else if (Input.GetButtonDown("Vision") && visionOn == true)
        {
            StartCoroutine(rout_VisionOff());
        }
    }
    
    private void StaminaUpdate(float maxStamina)
    {
        staminabar.value = maxStamina;
    }

    IEnumerator rout_VisionOn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5835f);
            SetVisionOn();
            yield break;
        }
    }
    IEnumerator rout_VisionOff()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5835f);
            SetVisionOff();
            yield break;
        }
    }


    private void SetVisionOn()
    {
        //Debug.Log(KeyCode.Q + "нажата");
        visionOn = true;
        eyes.SetActive(true);
        VisionOn_ev.Invoke();
        eyesanim.SetBool("IsTransition", true);

    }
    private void SetVisionOff()
    {
        visionOn = false;
        eyes.SetActive(false);
        VisionOff_ev.Invoke();
        eyesanim.SetBool("IsTransition", false);
    }

    private void StaminaIsDepleting()
    {
        if (visionOn == true && staminaZero == false)
        {
            if (totalStamina > 0f)
            {
                
                totalStamina -= 1 * Time.deltaTime;
               //Debug.Log(totalStamina);
            }
            else
            {
                totalStamina = 0;
                staminaZero = true;
                visionOn = false;
                SetVisionOff();
                eyesanim.SetBool("IsTransition", true);

            }
        }
        if (staminaZero == true || (totalStamina < fullStamina && visionOn == false))
            {
                totalStamina += 1 * Time.deltaTime;
                //Debug.Log("Стамина перезаряжается");
            //Debug.Log(totalStamina);
            //Debug.Log(staminaZero);
            staminaZero = false;
        }
    }
}