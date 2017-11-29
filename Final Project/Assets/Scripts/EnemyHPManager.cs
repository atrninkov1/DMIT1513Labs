using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHPManager : MonoBehaviour {
    int hp = 20;
	public int HP
    {
        get
        {
            return hp;
        }
    }

    public void loseHP(int amount)
    {
        hp -= amount;
        if (hp<=0)
        {
            if (tag == "Enemy")
            {
                SceneManager.LoadScene("PlayerWon");
            }
            else if (tag == "Player")
            {
                SceneManager.LoadScene("PlayerLost");
            }
        }
    }
}
