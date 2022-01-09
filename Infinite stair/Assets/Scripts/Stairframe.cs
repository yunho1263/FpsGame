using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairframe : MonoBehaviour
{
    public GameObject stairPrefab;
    public Stair[] stairs;
    public int steppingOnStair;

    public void Awake()
    {
        GameManager.Instance.stairframe = this;
        MakeStairs();
    }

    void MakeStairs()
    {
        stairs = new Stair[30];
        for (int i = 0; i < 30; i++)
        {
            Stair newStair = Instantiate(stairPrefab, Vector3.zero, Quaternion.identity).GetComponent<Stair>();
            newStair.gameObject.transform.parent = transform;
            stairs[i] = newStair;
        }

        stairs[0].isRight = true;
        stairs[0].SetPosition(Vector3.zero);

        for (int i = 1; i < 30; i++)
        {
            stairs[i].SetDirection(stairs[i - 1].isRight);
            stairs[i].SetPosition(stairs[i - 1].gameObject.transform.position);
        }
    }
}
