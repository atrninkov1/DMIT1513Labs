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
                GetComponent<RectTransform>().position = new Vector3(0, -2, -6);
                tutorialText.text = "These three squares that you see in the middle of the screen are your three decks. Click on one of them to draw a card from that deck\n(Click anywhere to continue)";
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
                GetComponent<RectTransform>().position = new Vector3(8, -3, -6);
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
                tutorialText.text = "you have to draw 5 cards at the start of the first turn of the game, you already drew one now draw 4 more";
                break;
            default:
                break;
        }
    }
}
