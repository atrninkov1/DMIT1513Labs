using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour {
    public GameObject HUDPanel;
    public GameObject optionsPanel;
    public GameObject player;
    int counter = 0;

    void Update()
    {
        counter++;
        if (Input.GetAxisRaw("ToggleMenu") > 0 && counter>100)
        {
            counter = 0;
            Cursor.visible = false;
            Time.timeScale = 1;
            HUDPanel.SetActive(true);
            player.SetActive(true);
            optionsPanel.SetActive(false);
            gameObject.SetActive(false);
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
