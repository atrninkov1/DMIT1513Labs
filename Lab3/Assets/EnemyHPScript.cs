using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPScript : MonoBehaviour {

    [SerializeField]
    GameObject deathParticle;
    [SerializeField]
    GameObject deathScream;
    int hp = 1000;
    public float maxHP
    {
        get
        {
            return 1000;
        }
    }
    public float currentHP
    {
        get
        {
            return hp;
        }
    }

	// Use this for initialization
	void Start () {
        deathParticle.SetActive(true);
    }
	
	internal void TakeDamage(int damage)
    {
        hp -= damage;
        GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().Play();
        if (hp <= 0)
        {
            GameObject particles = Instantiate(deathParticle);
            particles.transform.position = transform.position;
            particles.GetComponent<ParticleSystem>().Play();
            GameObject sound = Instantiate(deathScream);
            sound.transform.position = transform.position;
            sound.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
