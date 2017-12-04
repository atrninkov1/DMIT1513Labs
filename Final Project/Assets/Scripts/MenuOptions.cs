using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour {

    bool optionsEbabled = false;
    [SerializeField]
    GameObject optionsPanel;
    [SerializeField]
    GameObject mainMenuPanel;
    [SerializeField]
    AudioMixer mixer;

    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ToggleOptions()
    {
        if (!optionsEbabled)
        {
            optionsPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
            optionsEbabled = true;
        }
        else
        {
            optionsPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            optionsEbabled = false;
        }
    }

    public void resume()
    {
        mainMenuPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Concede()
    {
        SceneManager.LoadScene("PlayerLost");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetBackgroundSound(float newSound)
    {
        mixer.SetFloat("Background",newSound);
    }
    public void SetGameSound(float newSound)
    {
        mixer.SetFloat("GameSounds", newSound);
    }
}
