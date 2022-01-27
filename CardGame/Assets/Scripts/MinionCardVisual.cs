using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinionCardVisual : CardVisual
{
    public TextMeshPro hp;
    public TextMeshPro att;

    public new MinionCardBasedata basedata;

    public override void GetVisualComponent()
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

            else if (child.name == "cost")
            {
                cost = child.GetComponent<TextMeshPro>();
            }

            else if (child.name == "att")
            {
                att = child.GetComponent<TextMeshPro>();
            }

            else if (child.name == "hp")
            {
                hp = child.GetComponent<TextMeshPro>();
            }

            else if (child.name == "image")
            {
                spriteRenderer = child.GetComponent<SpriteRenderer>();
                break;
            }
        }
    }

    public override void SetBaseData()
    {
        base.SetBaseData();
        hp.text = basedata.Hp.ToString();
        att.text = basedata.Att.ToString();
    }
}
