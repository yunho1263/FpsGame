using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card Basedata", menuName = "Scriptable Object/Card Basedata", order = int.MaxValue)]
public class CardBasedata : ScriptableObject
{
    public int cardIndex;

    [SerializeField]
    private CardType type;
    public CardType Type { get { return type; } }

    [SerializeField]
    private int cost;
    public int Cost { get { return cost; } }

    [SerializeField]
    private string dis;
    public string Dis { get { return dis; } }

    [SerializeField]
    private string carddName;
    public string CardName { get { return carddName; } }

    [SerializeField]
    private Sprite image;
    public Sprite Image { get { return image; } }
}
