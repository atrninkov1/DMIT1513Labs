using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour {
    public GameObject HUDPanel;
    public GameObject optionsPanel;
    public GameObject player;
    bool stoppedPressingESC = false;

    void Update()
    {
        if (Input.GetAxis("ToggleMenu") == 0 && !stoppedPressingESC)
        {
            stoppedPressingESC = true;
        }
        if (Input.GetAxis("ToggleMenu") > 0 && stoppedPressingESC)
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            HUDPanel.SetActive(true);
            player.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }

    public void Continue()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        HUDPanel.SetActive(true);
        player.SetActive(true);
        optionsPanel.SetActive(false);
    }
}
