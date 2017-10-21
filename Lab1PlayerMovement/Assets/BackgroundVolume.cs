using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BackgroundVolume : MonoBehaviour {
    [SerializeField]
    AudioMixer mixer;

    // Update is called once per frame
    void Update()
    {
        float sliderValue;
        mixer.GetFloat("Background Volume", out sliderValue);
        GetComponent<Slider>().value = sliderValue;
    }
}
