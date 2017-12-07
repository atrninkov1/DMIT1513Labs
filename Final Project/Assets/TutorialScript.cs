using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    int tutorialStage = 0;
    [SerializeField]
    Text tutorialText;
    [SerializeField]
    CardManager cardManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (tutorialStage)
        {
            case 0:
                tutorialText.text = "Welcome newbie to the wonderful world of raid \n of reason\n (Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 1:
                tutorialText.text = "These three squares that you see right here are your three decks. Click on one of them to draw a card from that deck\n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 2:
                tutorialText.text = "Draw a card from the blue deck";
                if (cardManager.DrewBlueCard)
                {
                    tutorialStage++;
                }
                break;
            case 3:
                GetComponent<RectTransform>().position = new Vector3(6, -2, -6);
                tutorialText.text = "These three squares represent your mana the number on the left is your current mana, the number on the right is your maximum mana\n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 4:
                tutorialText.text = "The color of the square represents the type of mana, when you draw a card from a certain deck type your maximum and current mana of that type gets increased by one\n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }

                break;
            case 5:
                tutorialText.text = "you just drew a card from the blue deck so now you have 1 current blue mana and one maximum blue mana";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 6:
                GetComponent<RectTransform>().position = new Vector3(0, -2, -6);
                tutorialText.text = "you have to draw 5 cards at the start of the first turn of the game, you already drew one now draw 4 more, it is highly recomended that you have some red cardsat the begining";
                if (cardManager.NumberOfCardsToDraw <= 0)
                {
                    tutorialStage++;
                }
                break;
            case 7:
                GetComponent<RectTransform>().position = new Vector3(0, 0, -6);
                tutorialText.text = "Each card can be played on any field but cards are usually at their best when in their respective fields\n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 8:
                tutorialText.text = "The number on the top right corner of the card has a square and a number on it, the square the type of mana required and the number is the amount of mana required to play the card\n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 9:
                tutorialText.text = "Play a card by clicking on it and then by clicking on the button with the same color as the button \n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 10:
                tutorialText.text = "Cards in the blue field cannot attack but other cards cannot be attacked if there is a card in the blue field, go ahead and play a blue card on the blue field";
                if (cardManager.playedBlueCard)
                {
                    tutorialStage++;
                }
                break;
            case 11:
                tutorialText.text = "As you may have already noticed there are three squares followed by three numbers on the bottom of the card \n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 12:
                tutorialText.text = "The number next to the blue square is health, the number next to the red square is attack, and the number next to the yellow sqlaure is magical power which is used to activate the effect of creatures in the yellow field \n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 13:
                tutorialText.text = "If you followed my advise earlier then you should have a lot of red cards in your hand you may want to play some of those on the red field\n(Click anywhere to continue)";
                if (cardManager.playedRedCard)
                {
                    tutorialStage++;
                }
                break;
            case 14:
                tutorialText.text = "Now that you have cards in your red field you can attack your opponent's creatures, do this by clicking on your red card then select a target for the attack";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 15:
                tutorialText.text = "Now you know enough to beat this newb opponent on your own \n(Click anywhere to continue)";
                if (Input.GetMouseButtonDown(0))
                {
                    tutorialStage++;
                }
                break;
            case 16:
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
