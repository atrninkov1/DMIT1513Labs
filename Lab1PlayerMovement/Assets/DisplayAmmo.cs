using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAmmo : MonoBehaviour
{

    public Texture ammoImage;
    public FireGrenade count;
    Rect coords;
    void Start()
    {
        coords = new Rect();
    }

    void OnGUI()
    {
        for (int i = 0; i < count.Ammo; i++)
        {
            coords.position = new Vector3(815 + i*50, 150, 3);
            coords.size = new Vector3(100, 100, 100);
            GUI.DrawTexture(coords, ammoImage);
        }
    }

}
