using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    public AudioMixer mixer;

    public void PlayGame()
    {
        SceneManager.LoadScene("_Scenes/PlayerMovement");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void changeBackgroundVolume(float value)
    {
        mixer.SetFloat("Background Volume", value);
    }

    public void changeGunVolume(float value)
    {
        mixer.SetFloat("Gunshot Volume", value);
    }
    public void changeMasterVolume(float value)
    {
        mixer.SetFloat("Master Volume", value);
    }
}
