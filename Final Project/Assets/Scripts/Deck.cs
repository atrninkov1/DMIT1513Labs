using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    [SerializeField]
    List<GameObject> Cards;
    Vector3 previousPosition;
    public bool tutorial = true;

    void Start()
    {
        setPreviousPosition();
        if (!tutorial)
        {
            Shuffle();
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            int k = Random.Range(0, Cards.Count);
            GameObject value = Cards[k];
            Cards[k] = Cards[i];
            Cards[i] = value;
        }
    }

    public GameObject Draw()
    {
        GameObject card;
        if (Cards.Count > 0)
        {
            card = Cards[Cards.Count - 1];
            Cards.Remove(card);
        }
        else
        {
            card = null;
        }
        return card;
    }

    public void setPreviousPosition()
    {
        previousPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void returnToPreviousPosition()
    {
        transform.position = previousPosition;
    }
}
