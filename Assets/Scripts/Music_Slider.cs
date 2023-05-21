using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class Music_Slider : MonoBehaviour
{
    public string volumeParameter = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    private float _volumeValue;
    private const float _multiplier_ = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier_;
        mixer.SetFloat(volumeParameter, _volumeValue);
    }
    // Start is called before the first frame update
    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParameter, Mathf.Log10(slider.value) * _multiplier_);
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier_);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, _volumeValue);
    }
}
