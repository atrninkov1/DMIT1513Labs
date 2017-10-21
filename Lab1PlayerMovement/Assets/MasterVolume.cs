using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MasterVolume : MonoBehaviour {
    [SerializeField]
    AudioMixer mixer;

	// Update is called once per frame
	void Update () {
        float sliderValue;
        mixer.GetFloat("Master Volume", out sliderValue);
        GetComponent<Slider>().value = sliderValue;
    }
}
