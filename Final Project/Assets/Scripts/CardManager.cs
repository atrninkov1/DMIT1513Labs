using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

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
    [SerializeField]
    GameObject blueDeck;
    [SerializeField]
    GameObject redDeck;
    [SerializeField]
    GameObject yellowDeck;
    [SerializeField]
    GameObject canvas;
    RaycastHit hit;
    [SerializeField]
    Texture texture;

    int maxBlueMana = 0;
    int maxRedMana = 0;
    int maxYellowMana = 0;
    int currentBlueMana = 0;
    int currentRedMana = 0;
    int currentYellowMana = 0;
    int numberOfCardsToDraw;

    enum phases
    {
        draw,
        play,
        end
    }

    phases phase = phases.draw;

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

    void Start()
    {
        phase = phases.draw;
        numberOfCardsToDraw = 5;
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
                    hand.RemoveCard(hand.selectedCard);
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
        Ray ray;
        switch (phase)
        {
            case phases.draw:
                blueDeck.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).x - 1.2f,
                    Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).y, blueDeck.transform.position.z);
                redDeck.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).x,
                    Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).y, redDeck.transform.position.z);
                yellowDeck.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).x + 1.2f,
                    Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)).y, yellowDeck.transform.position.z);
                if (Input.GetMouseButtonDown(0))
                {
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                    {
                        GameObject card;
                        switch (hit.collider.gameObject.tag)
                        {
                            case "BlueDeck":
                                card = Instantiate(blueDeck.GetComponent<Deck>().Draw());
                                card.transform.parent = hand.gameObject.transform;
                                hand.AddCard(card);
                                card.GetComponent<Card>().SetCanvas(canvas);
                                maxBlueMana++;
                                currentBlueMana++;
                                numberOfCardsToDraw--;
                                break;
                            case "YellowDeck":
                                card = Instantiate(yellowDeck.GetComponent<Deck>().Draw());
                                card.transform.parent = hand.gameObject.transform;
                                hand.AddCard(card);
                                card.GetComponent<Card>().SetCanvas(canvas);
                                maxYellowMana++;
                                currentYellowMana++;
                                numberOfCardsToDraw--;
                                break;
                            case "RedDeck":
                                card = Instantiate(redDeck.GetComponent<Deck>().Draw());
                                card.transform.parent = hand.gameObject.transform;
                                hand.AddCard(card);
                                card.GetComponent<Card>().SetCanvas(canvas);
                                maxRedMana++;
                                currentRedMana++;
                                numberOfCardsToDraw--;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (numberOfCardsToDraw <= 0)
                {
                    blueDeck.GetComponent<Deck>().returnToPreviousPosition();
                    redDeck.GetComponent<Deck>().returnToPreviousPosition();
                    yellowDeck.GetComponent<Deck>().returnToPreviousPosition();
                    phase = phases.play;
                }
                break;
            case phases.play:
                if (Input.GetMouseButtonDown(0) && hand.selectedCard != null)
                {
                    switch (hand.selectedCard.GetComponent<Card>().cardTypes)
                    {
                        case Card.Types.red:
                            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                            {
                                if (hit.collider.gameObject.tag == "Enemy" && !hand.selectedCard.GetComponent<Card>().HasAttacked)
                                {
                                    hit.collider.gameObject.GetComponent<EnemyHPManager>().loseHP(hand.selectedCard.GetComponent<Card>().Attack);
                                    hand.selectedCard.GetComponent<Card>().HasAttacked = true;
                                    hand.selectedCard = null;
                                }
                                else if (hit.collider.gameObject.tag == "EnemyCreature" && !hand.selectedCard.GetComponent<Card>().HasAttacked)
                                {
                                    hit.collider.gameObject.GetComponent<Card>().TakeDamage(hand.selectedCard.GetComponent<Card>().Attack);
                                    hand.selectedCard.GetComponent<Card>().HasAttacked = true;
                                    hand.selectedCard = null;
                                }
                            }
                            break;
                        case Card.Types.blue:
                            break;
                        case Card.Types.yellow:
                            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                            if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                            {
                                print(hit.collider.gameObject.tag);
                                if (hit.collider.gameObject.tag == "PlayerCreature" && hit.collider.gameObject != hand.selectedCard)
                                {
                                    if (hand.selectedCard.GetComponent<Card>().MagicPower >= 2)
                                    {
                                        for (int i = 0; i < 2; i++)
                                        {
                                            if (hit.collider.gameObject.GetComponent<Card>().Health < hit.collider.gameObject.GetComponent<Card>().MaxHealth)
                                            {
                                                hit.collider.gameObject.GetComponent<Card>().Heal(1);
                                            }
                                        }
                                        hand.selectedCard.GetComponent<Card>().LoseMagic(2);
                                        hand.selectedCard = null;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            case phases.end:
                numberOfCardsToDraw = 1;
                currentBlueMana = maxBlueMana;
                currentRedMana = maxRedMana;
                currentYellowMana = maxYellowMana;
                GameObject[] enemyRedCards = GameObject.FindGameObjectsWithTag("EnemyCreature");
                foreach (var enemy in enemyRedCards)
                {
                    if (enemy.GetComponent<Card>().cardTypes == Card.Types.red)
                    {
                        if (blueField.GetComponent<fieldScript>().creaturesInField.Count > 0)
                        {
                            blueField.GetComponent<fieldScript>().creaturesInField[Random.Range(0, blueField.GetComponent<fieldScript>().creaturesInField.Count)].
                                GetComponent<Card>().TakeDamage(enemy.GetComponent<Card>().Attack);
                        }
                        else if (redField.GetComponent<fieldScript>().creaturesInField.Count > 0)
                        {
                            redField.GetComponent<fieldScript>().creaturesInField[Random.Range(0, redField.GetComponent<fieldScript>().creaturesInField.Count)].
                                GetComponent<Card>().TakeDamage(enemy.GetComponent<Card>().Attack);
                        }
                        else if (yellowField.GetComponent<fieldScript>().creaturesInField.Count > 0)
                        {
                            yellowField.GetComponent<fieldScript>().creaturesInField[Random.Range(0, yellowField.GetComponent<fieldScript>().creaturesInField.Count)].
                                GetComponent<Card>().TakeDamage(enemy.GetComponent<Card>().Attack);
                        }
                    }
                }
                GameObject[] playerCards = GameObject.FindGameObjectsWithTag("PlayerCreature");
                foreach (var creature in playerCards)
                {
                    creature.GetComponent<Card>().HasAttacked = false;
                }
                phase = phases.draw;
                break;
            default:
                break;
        }
    }

    public void EndTurn()
    {
        phase = phases.end;
    }

    private void OnGUI()
    {
        if (hand.selectedCard != null)
        {
            if (hand.selectedCard.GetComponent<Card>().cardTypes == Card.Types.red || hand.selectedCard.GetComponent<Card>().cardTypes == Card.Types.yellow)
            {
                Vector2 position = Camera.main.WorldToScreenPoint(new Vector2(hand.selectedCard.transform.position.x, hand.selectedCard.transform.position.y) * -1);
                Vector2 size = new Vector2(3, Camera.main.WorldToScreenPoint(hand.selectedCard.transform.position).y - (Input.mousePosition.y));
                GUIUtility.RotateAroundPivot(45,hand.selectedCard.transform.position);
                print(hand.selectedCard);
                GUI.DrawTexture(new Rect(position, size), texture);
            }
        }        
    }
}
