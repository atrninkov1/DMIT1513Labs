using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    [SerializeField]
    HandScript hand;
    [SerializeField]
    HandScript enemyHand;
    [SerializeField]
    GameObject Panel;
    [SerializeField]
    GameObject blueField;
    [SerializeField]
    GameObject redField;
    [SerializeField]
    GameObject yellowField;
    [SerializeField]
    GameObject enemyBlueField;
    [SerializeField]
    GameObject enemyRedField;
    [SerializeField]
    GameObject enemyYellowField;
    [SerializeField]
    GameObject blueDeck;
    [SerializeField]
    GameObject redDeck;
    [SerializeField]
    GameObject yellowDeck;
    [SerializeField]
    GameObject enemyBlueDeck;
    [SerializeField]
    GameObject enemyRedDeck;
    [SerializeField]
    GameObject enemyYellowDeck;
    [SerializeField]
    GameObject canvas;
    RaycastHit hit;
    [SerializeField]
    GameObject lineRenderer;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject mainMenu;

    int maxBlueMana = 0;
    int maxRedMana = 0;
    int maxYellowMana = 0;
    int currentBlueMana = 0;
    int currentRedMana = 0;
    int currentYellowMana = 0;
    int enemyMaxBlueMana = 0;
    int enemyMaxRedMana = 0;
    int enemyMaxYellowMana = 0;
    int enemyCurrentBlueMana = 0;
    int enemyCurrentRedMana = 0;
    int enemyCurrentYellowMana = 0;
    int numberOfCardsToDraw;
    int enemyNumberOfCardsToDraw;
    int playerTurn;

    bool drewBlueCard = false;

    public bool DrewBlueCard
    {
        get
        {
            return drewBlueCard;
        }
    }

    enum phases
    {
        draw,
        play,
        end
    }

    phases phase = phases.draw;

    enum cardToDraw
    {
        red,
        blue,
        yellow
    }

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
        enemyNumberOfCardsToDraw = 5;
        playerTurn = 1;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
        }
        Ray ray;
        if (playerTurn == 1)
        {
            switch (phase)
            {
                case phases.draw:
                    #region Draw
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
                                    drewBlueCard = true;
                                    break;
                                case "YellowDeck":
                                    if (drewBlueCard)
                                    {
                                        card = Instantiate(yellowDeck.GetComponent<Deck>().Draw());
                                        card.transform.parent = hand.gameObject.transform;
                                        hand.AddCard(card);
                                        card.GetComponent<Card>().SetCanvas(canvas);
                                        maxYellowMana++;
                                        currentYellowMana++;
                                        numberOfCardsToDraw--;
                                    }
                                    break;
                                case "RedDeck":
                                    if (drewBlueCard)
                                    {
                                        card = Instantiate(redDeck.GetComponent<Deck>().Draw());
                                        card.transform.parent = hand.gameObject.transform;
                                        hand.AddCard(card);
                                        card.GetComponent<Card>().SetCanvas(canvas);
                                        maxRedMana++;
                                        currentRedMana++;
                                        numberOfCardsToDraw--;
                                    }
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
                #endregion
                case phases.play:
                    #region playSpell
                    if (hand.selectedCard != null && hand.selectedCard.GetComponent<Card>().CardBaseType == Card.CardType.spell)
                    {
                        switch (hand.selectedCard.GetComponent<Card>().EffectTargetTypes[0])
                        {
                            case Card.effectTargetType.field:
                                if (Input.GetMouseButtonDown(0))
                                {
                                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                                    if (Physics.Raycast(ray.origin, ray.direction, out hit, 1000))
                                    {
                                        switch (hand.selectedCard.GetComponent<Card>().CardCostType)
                                        {
                                            case Card.Types.red:
                                                if (hand.selectedCard.GetComponent<Card>().Cost <= currentRedMana)
                                                {
                                                    if (hit.collider.gameObject.tag == "Field")
                                                    {
                                                        foreach (var item in hit.collider.gameObject.GetComponent<fieldScript>().creaturesInField)
                                                        {
                                                            item.TakeDamage(4);
                                                        }
                                                        hit.collider.gameObject.GetComponent<fieldScript>().PlayAnimation();
                                                        currentRedMana -= hand.selectedCard.GetComponent<Card>().Cost;
                                                        hand.RemoveCard(hand.selectedCard);
                                                        Destroy(hand.selectedCard);
                                                    }
                                                }
                                                break;
                                            case Card.Types.blue:
                                                break;
                                            case Card.Types.yellow:
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                break;
                            case Card.effectTargetType.creature:
                                break;
                            case Card.effectTargetType.player:
                                break;
                            case Card.effectTargetType.singleUnit:
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion
                    #region attackWithCreature
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
                                        if ((hit.collider.GetComponent<Card>().cardTypes == Card.Types.red && enemyBlueField.GetComponent<fieldScript>().creaturesInField.Count == 0) ||
                                               (hit.collider.GetComponent<Card>().cardTypes == Card.Types.yellow && enemyBlueField.GetComponent<fieldScript>().creaturesInField.Count == 0
                                               && enemyRedField.GetComponent<fieldScript>().creaturesInField.Count == 0) || hit.collider.GetComponent<Card>().cardTypes == Card.Types.blue)
                                        {
                                            hit.collider.gameObject.GetComponent<Card>().TakeDamage(hand.selectedCard.GetComponent<Card>().Attack);
                                            hand.selectedCard.GetComponent<Card>().HasAttacked = true;
                                            hand.selectedCard = null;
                                        }
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
                #endregion
                case phases.end:
                    #region endTurn
                    numberOfCardsToDraw = 1;
                    currentBlueMana = maxBlueMana;
                    currentRedMana = maxRedMana;
                    currentYellowMana = maxYellowMana;
                    GameObject[] playerCards = GameObject.FindGameObjectsWithTag("PlayerCreature");
                    foreach (var creature in playerCards)
                    {
                        creature.GetComponent<Card>().HasAttacked = false;
                    }
                    playerTurn = 2;
                    phase = phases.draw;
                    break;
                #endregion
                default:
                    break;
            }
        }
        else
        {
            switch (phase)
            {
                case phases.draw:
                    #region #enemyDrawAI
                    GameObject card;
                    card = enemyBlueDeck.GetComponent<Deck>().Draw();
                    if (card == null)
                    {
                        card = enemyRedDeck.GetComponent<Deck>().Draw();
                    }
                    if (card == null)
                    {
                        card = enemyYellowDeck.GetComponent<Deck>().Draw();
                    }
                    card = Instantiate(card);
                    card.transform.parent = enemyHand.gameObject.transform;
                    enemyHand.AddCard(card);
                    card.GetComponent<Card>().SetCanvas(canvas);
                    card.GetComponent<Card>().setHidden(true);
                    enemyMaxBlueMana++;
                    enemyCurrentBlueMana++;
                    enemyNumberOfCardsToDraw--;
                    if (enemyNumberOfCardsToDraw <= 0)
                    {
                        phase = phases.play;
                    }
                    #endregion
                    break;
                case phases.play:
                    #region enemyAIPlay
                    for (int i = 0; i < enemyHand.Cards.Count; i++)
                    {
                        if (enemyHand.Cards[i].GetComponent<Card>().Cost <= currentBlueMana)
                        {
                            enemyCurrentBlueMana -= enemyHand.Cards[i].GetComponent<Card>().Cost;
                            enemyHand.Cards[i].GetComponent<Card>().playCard(enemyBlueField.transform.position, "blue");
                            enemyBlueField.GetComponent<fieldScript>().addCardToField(enemyHand.Cards[i]);
                            enemyHand.Cards[i].GetComponent<Card>().setHidden(false);
                            enemyHand.RemoveCard(enemyHand.Cards[i]);
                            //i--;
                        }
                    }
                    GameObject[] enemyRedCards = GameObject.FindGameObjectsWithTag("EnemyCreature");
                    foreach (var enemy in enemyRedCards)
                    {
                        if (enemy.GetComponent<Card>().cardTypes == Card.Types.red && enemy.GetComponent<Card>().Played)
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
                            else
                            {
                                player.GetComponent<EnemyHPManager>().loseHP(enemy.GetComponent<Card>().Attack);
                            }
                        }
                    }
                    #endregion
                    phase = phases.end;
                    break;
                case phases.end:
                    #region endTurn
                    enemyNumberOfCardsToDraw = 1;
                    enemyCurrentBlueMana = enemyMaxBlueMana;
                    enemyCurrentRedMana = enemyMaxRedMana;
                    enemyCurrentYellowMana = enemyMaxYellowMana;
                    playerTurn = 1;
                    phase = phases.draw;
                    break;
                #endregion
                default:
                    break;
            }
        }

        if (hand.selectedCard != null)
        {
            if (hand.selectedCard.GetComponent<Card>().cardTypes == Card.Types.red || hand.selectedCard.GetComponent<Card>().cardTypes == Card.Types.yellow)
            {
                lineRenderer.SetActive(true);
                lineRenderer.GetComponent<LineRenderer>().SetPosition(0, hand.selectedCard.transform.position);
                lineRenderer.GetComponent<LineRenderer>().SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
        else
        {
            lineRenderer.SetActive(false);
        }
    }

    public void EndTurn()
    {
        phase = phases.end;
    }
}
