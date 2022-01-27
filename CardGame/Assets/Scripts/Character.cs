using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public bool isAlive;

    public int maxHp;
    public int hp;

    public void TakeDamage(int value)
    {
        if (value > 0)
        {
            return;
        }

        hp -= value;

        if (hp < 0)
        {
            hp = 0;
            isAlive = false;
        }
    }
}
