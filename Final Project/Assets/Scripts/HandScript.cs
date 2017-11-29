using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {

    List<GameObject> cards;
    public GameObject selectedCard;

    public List<GameObject> Cards
    {
        get
        {
            return cards;
        }
    }

    void Start()
    {
        cards = new List<GameObject>();
    }

    void Update()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] == null)
            {
            //    cards.Remove(cards[i]);
            }
            else
            {
                cards[i].transform.position = new Vector3(transform.position.x + i * -1.5f, transform.position.y, -3);
            }
        }
    }

	public void AddCard(GameObject card)
    {
        cards.Add(card);
    }

    public void RemoveCard(GameObject card)
    {
        cards.Remove(card);
    }
}
