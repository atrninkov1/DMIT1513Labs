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
        SceneManager.LoadScene("_Scenes/MainGame");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void exitMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitToMainMenu()
    {
        SceneManager.LoadScene("_Scenes/GameMenu");
    }

    public void changeBackgroundVolume(float value)
    {
        mixer.SetFloat("Sound Volume", value);
    }
    public void changeMasterVolume(float value)
    {
        mixer.SetFloat("Master Volume", value);
    }
}
