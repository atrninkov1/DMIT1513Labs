using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    int maxHP = 10;
    int hp = 10;
    public float hpPercent
    {
        get
        {
            return (float)hp / maxHP;
        }
    }

    public void loseHP()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
