using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    GameObject particle;

    bool positionSet = false;
    bool positionSetOnShrink = false;
    bool hasAttacked;
    bool hidden = false;

    float damageTaken;

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

    public enum effectType
    {
        heal,
        buff,
        giveArmor,
        damage,
        draw
    }
    public enum effectTargetType
    {
        field,
        creature,
        player,
        singleUnit
    }

    [SerializeField]
    GameObject hideTexture;

    [SerializeField]
    List<effectType> effects;
    [SerializeField]
    List<effectTargetType> effectTargets;

    public GameObject onSelectedCanvas;


    public enum Types
    {
        red,
        blue,
        yellow
    }
   
    public enum CardType
    {
        creature,
        spell
    }

    [SerializeField]
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

    public CardType CardBaseType
    {
        get
        {
            return cardBaseType;
        }
    }
    public List<effectType> EffectTypes
    {
        get
        {
            return effects;
        }
    }
    public List<effectTargetType> EffectTargetTypes
    {
        get
        {
            return effectTargets;
        }
    }
    Vector3 previousPosition;

    [SerializeField]
    Types cardCostType = Types.red;
    [SerializeField]
    CardType cardBaseType = CardType.creature;
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
    public bool Played
    {
        get
        {
            return played;
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
        if (!played && gameObject.tag == "PlayerCreature" && cardBaseType == CardType.creature)
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
        GetComponent<AudioSource>().Play();
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
        ((Behaviour)GetComponent("Halo")).enabled = true;
        damageTaken = Time.time;
        if (health <= 0)
        {
            GameObject pEmmiter = Instantiate(particle);
            pEmmiter.transform.position = transform.position;
            pEmmiter.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }

    public void LoseMagic(int amount)
    {
        magicPower -= amount;
    }
    private void Update()
    {
        if (((Behaviour)GetComponent("Halo")).enabled && Time.time > damageTaken + 2)
        {
            ((Behaviour)GetComponent("Halo")).enabled = false;
        }
        if (hidden)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).gameObject;
                if (child != null && child != hideTexture)
                    child.SetActive(false);
            }
        }
        else
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).gameObject;
                if (child != null && child != hideTexture)
                    child.SetActive(true);
            }
        }
    }

    public void setHidden(bool hidden)
    {
        this.hidden = hidden;
    }
}
