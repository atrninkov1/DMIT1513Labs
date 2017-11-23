using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    bool positionSet = false;
    bool positionSetOnShrink = false;
    bool hasAttacked;

    public bool HasAttacked
    {
        get
        {
            return hasAttacked;
        }
        set
        {
            hasAttacked = value;
        }
    }


    public GameObject onSelectedCanvas;


    public enum Types
    {
        red,
        blue,
        yellow
    }
    bool played = false;

    [SerializeField]
    int attack;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    int health;
    [SerializeField]
    int magicPower;

    public int Attack
    {
        get
        {
            return attack;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
    public int Health
    {
        get
        {
            return health;
        }
    }

    public int MagicPower
    {
        get
        {
            return magicPower;
        }
    }

    Vector3 previousPosition;

    [SerializeField]
    Types cardCostType = Types.red;
    [SerializeField]
    int cost = 1;

    public Types CardCostType
    {
        get
        {
            return cardCostType;
        }
    }
    [SerializeField]
    Types cardType;

    public Types cardTypes
    {
        get
        {
            return cardType;
        }
    }

    public int Cost
    {
        get
        {
            return cost;
        }
    }

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }


    void OnMouseOver()
    {
        transform.localScale = new Vector3(2, 2, 1);
        if (!positionSet)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, -7);
            positionSet = true;
            positionSetOnShrink = false;
        }
    }

    private void OnMouseExit()
    {
        if (!positionSetOnShrink)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, -7);
            positionSet = false;
            positionSetOnShrink = true;
        }
        transform.localScale = new Vector3(1, 1, 1);
    }

    void OnMouseDown()
    {
        if (!played && gameObject.tag == "PlayerCreature")
        {
            previousPosition = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).x,
                Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).y + 1.75f, transform.position.z);
            onSelectedCanvas.SetActive(true);
            transform.parent.GetComponent<HandScript>().selectedCard = gameObject;
        }
        else
        {
            if (gameObject.tag == "PlayerCreature")
            {
                switch (cardType)
                {
                    case Types.red:
                        //attack
                        transform.parent.GetComponent<HandScript>().selectedCard = gameObject;
                        break;
                    case Types.blue:
                        //nothing
                        break;
                    case Types.yellow:
                        //utility effect
                        transform.parent.GetComponent<HandScript>().selectedCard = gameObject;
                        break;
                    default:
                        break;
                }
            }            
        }
    }

    public void unSelectCard()
    {
        transform.position = previousPosition;
        transform.parent.GetComponent<HandScript>().selectedCard = null;
    }

    public void playCard(Vector3 fieldLocation, string type)
    {
        transform.position = new Vector3(fieldLocation.x, fieldLocation.y + 0.25f, fieldLocation.z);
        played = true;
        switch (type)
        {
            case "blue":
                cardType = Types.blue;
                break;
            case "red":
                cardType = Types.red;
                break;
            case "yellow":
                cardType = Types.yellow;
                break;
            default:
                break;
        }
    }

    public void Heal(int amount)
    {
        if (health < maxHealth)
        {
            health+=amount;
        }
    }

    public void SetCanvas(GameObject canvas)
    {
        onSelectedCanvas = canvas;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LoseMagic(int amount)
    {
        magicPower -= amount;
    }
}
