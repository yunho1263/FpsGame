using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCard : Card
{
    GameObject thisMinion;


    public override void Play()
    {
        base.Play();
        Minion newinstans = Instantiate(thisMinion).GetComponent<Minion>();
        newinstans.myField = myDeck.myPlayer.myfield;
    }
}