using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldScript : MonoBehaviour {

    [SerializeField]
    enum fieldType
    {
        red,
        blue,
        yellow
    }

    [SerializeField]
    fieldType cardCostType = fieldType.red;

    public List<Card> creaturesInField
    {
        get
        {
            return cards;
        }
    }
    [SerializeField]
    List<Card> cards;

    void Start()
    {

    }

    public void addCardToField(GameObject card)
    {
        cards.Add(card.GetComponent<Card>());
    }
    void Update()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] == null)
            {
                cards.Remove(cards[i]);
            }
            else
            {
                cards[i].transform.position = new Vector3(transform.position.x + i * -1.5f, transform.position.y + 0.25f, -3);
                cards[i].transform.localScale = new Vector3(0.75f, 0.75f, 1);
            }
        }
    }

    public void PlayAnimation()
    {
        GetComponent<ParticleSystem>().Play();
    }
}
