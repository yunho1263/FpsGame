using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MinionCard Basedata", menuName = "Scriptable Object/MinionCard Basedata", order = int.MaxValue)]
public class MinionCardBasedata : CardBasedata
{
    [SerializeField]
    private int att;
    public int Att { get { return att; } }

    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }
}
