using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerChar playerCharacter;
    public TurnHandler turnHandler;

    public int maxCost;
    public int cost;

    public Deck deck;
    public List<Card> discards;
    public List<Card> hand;
    public List<Card> destroyed;

    public Field myfield;

    public void Setup(Deck deck)
    {
        turnHandler = new TurnHandler(this);

        maxCost = 1;
        this.deck = deck;
    }

    public void CostRecovery(int value)
    {
        if (value <= 0)
        {
            return;
        }
        cost += value;
        if (cost > maxCost)
        {
            cost = maxCost;
        }
    }

    public void CostConsume(int value)
    {
        if (value <= 0)
        {
            return;
        }
        cost -= value;
        if (cost > 0)
        {
            cost = 0;
        }
    }
}

[System.Serializable]
public class TurnHandler : MonoBehaviour
{
    public TurnHandler(Player player)
    {
        this.player = player;
    }

    Player player;

    bool isMyTurn;
    float TimeLimit;
    float RemainingTime;

    public delegate void TurnEventHandler();

    public event TurnEventHandler TurnStartEvent;
    public void TrunStart()
    {
        isMyTurn = true;
        player.CostRecovery(player.maxCost);
        TurnStartEvent();
    }

    public event TurnEventHandler TurnEndEvent;
    public void TurnEnd()
    {
        isMyTurn = false;
        TurnEndEvent();
    }
}

[System.Serializable]
public class Field : MonoBehaviour
{
    public Field(Player player)
    {
        this.player = player;
        minions = new List<Minion>();
    }

    Player player;
    List<Minion> minions;

    public delegate void FieldEventHandler(Minion minion);

    public event FieldEventHandler SummonEvent;
    public void SummonMinion(GameObject minionObject)
    {
        Minion newMinion = Instantiate(minionObject).GetComponent<Minion>();
        minions.Add(newMinion);
        SummonEvent(newMinion);
    }

    public event FieldEventHandler DestroyEvent;
    public void DestroyMinion(Minion minion)
    {
        minions.Remove(minion);
        DestroyEvent(minion);
    }
}

