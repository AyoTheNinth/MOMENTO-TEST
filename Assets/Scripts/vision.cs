using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vision : MonoBehaviour
{
    public GameObject eyes;
    public bool visionOn;

    // Start is called before the first frame update
    void Start()
    {
        eyes = GameObject.FindGameObjectWithTag("Vision");
        eyes.SetActive(false);
        visionOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Vision") && visionOn == false)
        {
            Debug.Log(KeyCode.Q + "нажата");
            visionOn = true;
            eyes.SetActive(true);
        }
        else if (Input.GetButtonDown("Vision") && visionOn == true)
        {
            visionOn = false;
            eyes.SetActive(false);
        }

        
    }
}
