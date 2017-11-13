using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

    void OnDestroy()
    {
        SceneManager.LoadScene("GameOver");
    }
}
