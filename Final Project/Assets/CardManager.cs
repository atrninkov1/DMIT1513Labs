using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour {

    [SerializeField]
    HandScript hand;
    [SerializeField]
    GameObject Panel;
    [SerializeField]
    GameObject blueField;
    [SerializeField]
    GameObject redField;
    [SerializeField]
    GameObject yellowField;
    RaycastHit hit;

    int maxBlueMana = 5;
    int maxRedMana = 5;
    int maxYellowMana = 5;
    int currentBlueMana = 5;
    int currentRedMana = 5;
    int currentYellowMana = 5;

    public int MaxBlueMana
    {
        get
        {
            return maxBlueMana;
        }
    }
    public int MaxRedMana
    {
        get
        {
            return maxRedMana;
        }
    }
    public int MaxYellowMana
    {
        get
        {
            return maxYellowMana;
        }
    }
    public int CurrentBlueMana
    {
        get
        {
            return currentBlueMana;
        }
    }
    public int CurrentRedMana
    {
        get
        {
            return currentRedMana;
        }
    }
    public int CurrentYellowMana
    {
        get
        {
            return currentYellowMana;
        }
    }

    public void Cancel()
    {
        hand.selectedCard.GetComponent<Card>().unSelectCard();
        Panel.SetActive(false);
    }

    public void playOnBlueField()
    {
        switch (hand.selectedCard.GetComponent<Card>().CardCostType)
        {
            case Card.Types.red:
                if (currentRedMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentRedMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(blueField.transform.position, "blue");
                    blueField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.Types.blue:
                if (currentBlueMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentBlueMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(blueField.transform.position, "blue");
                    blueField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.Types.yellow:
                if (currentYellowMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentYellowMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(blueField.transform.position, "blue");
                    blueField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            default:
                break;
        }
    }

    public void playOnRedField()
    {
        switch (hand.selectedCard.GetComponent<Card>().CardCostType)
        {
            case Card.Types.red:
                if (currentRedMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentRedMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(redField.transform.position, "red");
                    redField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.Types.blue:
                if (currentBlueMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentBlueMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(redField.transform.position, "red");
                    redField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.Types.yellow:
                if (currentYellowMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentYellowMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(redField.transform.position, "red");
                    redField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            default:
                break;
        }
    }


    public void playOnYellowField()
    {
        switch (hand.selectedCard.GetComponent<Card>().CardCostType)
        {
            case Card.Types.red:
                if (currentRedMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentRedMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(yellowField.transform.position, "yellow");
                    yellowField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.Types.blue:
                if (currentBlueMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentBlueMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(yellowField.transform.position, "yellow");
                    yellowField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.Types.yellow:
                if (currentYellowMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentYellowMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(yellowField.transform.position, "yellow");
                    yellowField.GetComponent<fieldScript>().addCardToField(hand.selectedCard);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hand.selectedCard != null)
        {
            Ray ray;
            switch (hand.selectedCard.GetComponent<Card>().cardTypes)
            {
                case Card.Types.red:
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                    {
                        if (hit.collider.gameObject.tag == "Enemy")
                        {
                            hit.collider.gameObject.GetComponent<EnemyHPManager>().loseHP(hand.selectedCard.GetComponent<Card>().Attack);
                        }
                    }
                    break;
                case Card.Types.blue:                    
                    break;
                case Card.Types.yellow:
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                    {
                        print(hit.collider.gameObject.name);
                        if (hit.collider.gameObject.tag == "PlayerCreature")
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                if (hit.collider.gameObject.GetComponent<Card>().Health < hit.collider.gameObject.GetComponent<Card>().MaxHealth)
                                {
                                    hit.collider.gameObject.GetComponent<Card>().Heal(1);
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }      
        }
    }
}
