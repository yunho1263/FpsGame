using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardVisual : MonoBehaviour
{
    public Card myCard;
    public CardBasedata basedata;

    public TextMeshPro cost;
    public TextMeshPro hp;
    public TextMeshPro att;
    public TextMeshPro cardName;
    public TextMeshPro dis;

    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        SetBaseData();
    }

    public void SetBaseData()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;

            if (child.name == "name")
            {
                cardName = child.GetComponent<TextMeshPro>();
            }

            else if (child.name == "description")
            {
                dis = child.GetComponent<TextMeshPro>();
            }

            else if(child.name == "cost")
            {
                cost = child.GetComponent<TextMeshPro>();
            }

            else if(child.name == "att")
            {
                att = child.GetComponent<TextMeshPro>();
            }

            else if(child.name == "hp")
            {
                hp = child.GetComponent<TextMeshPro>();
            }

            else if(child.name == "image")
            {
                spriteRenderer = child.GetComponent<SpriteRenderer>();
                break;
            }
        }

        cost.text = basedata.Cost.ToString();
        hp.text = basedata.Hp.ToString();
        att.text = basedata.Att.ToString();
        cardName.text = basedata.CardName;
        dis.text = basedata.Dis;
        spriteRenderer.sprite = basedata.Image;
    }
}
