using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelect : MonoBehaviour
{
    public List<GameObject> AllCards;
    public Deck deck;

    public void InsertCard(Card card)
    {
        deck.list.Add(card);
    }

    public void RemoveCard(Card card)
    {
        deck.list.Remove(card);
    }

    public void ShowCards()
    {
        //À½.....
    }
}
