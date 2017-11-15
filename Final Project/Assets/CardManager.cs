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
            case Card.costType.red:
                if (currentRedMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentRedMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(blueField.transform.position);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.costType.blue:
                if (currentBlueMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentBlueMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(blueField.transform.position);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.costType.yellow:
                if (currentYellowMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentYellowMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(blueField.transform.position);
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
            case Card.costType.red:
                if (currentRedMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentRedMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(redField.transform.position);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.costType.blue:
                if (currentBlueMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentBlueMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(redField.transform.position);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.costType.yellow:
                if (currentYellowMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentYellowMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(redField.transform.position);
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
            case Card.costType.red:
                if (currentRedMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentRedMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(yellowField.transform.position);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.costType.blue:
                if (currentBlueMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentBlueMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(yellowField.transform.position);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            case Card.costType.yellow:
                if (currentYellowMana >= hand.selectedCard.GetComponent<Card>().Cost)
                {
                    currentYellowMana -= hand.selectedCard.GetComponent<Card>().Cost;
                    hand.selectedCard.GetComponent<Card>().playCard(yellowField.transform.position);
                    hand.selectedCard = null;
                    Panel.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}
