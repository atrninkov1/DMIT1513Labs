using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPScript : MonoBehaviour {

    [SerializeField]
    GameObject deathParticle;
    [SerializeField]
    GameObject deathScream;
    int hp = 1000;
<<<<<<< HEAD
    public int maxHP
    {
        get
        {
            return 1000;
        }
    }

    public int currentHP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
=======
    GameObject target;
    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }
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

    public void increaseHP()
    {
        hp += 300;
    }
>>>>>>> 23b3dc27d286be64c4f6190fe4b63a8f68d1d493

	// Use this for initialization
	void Start () {
        deathParticle.SetActive(true);
    }
	
	internal void TakeDamage(int damage, GameObject target)
    {
        hp -= damage;
        this.target = target;
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

    internal void RemoveTarget()
    {
        target = null;
    }
}
