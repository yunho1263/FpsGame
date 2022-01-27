using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CardType
{
    Minion,
    Skill
}

public class Card : MonoBehaviour
{
    public CardType type { get { return cardType; } }
    private CardType cardType;

    public Deck myDeck;

    public int cost;

    public virtual void Play()
    {

    }
}

[System.Serializable]
public class Deck
{
    public List<Card> list;
    public Player myPlayer;

    //¼¯±â
    public void Shuffle()
    {
        for (int i = 0; i < 100; i++)
        {
            int index = Random.Range(0, list.Count);
            Card c = list[index];
            list.RemoveAt(index);
            list.Insert(Random.Range(0, list.Count), c);
        }
    }

    //µå·Î¿ì
    public Card Draw()
    {
        Card c = list[0];
        list.RemoveAt(0);
        return c;
    }
}
