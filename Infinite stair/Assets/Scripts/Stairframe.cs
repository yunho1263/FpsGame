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
        steppingOnStair = -1;
        GameManager.Instance.GameStart();
    }

    void MakeStairs()
    {
        stairs = new Stair[50];
        for (int i = 0; i < 50; i++)
        {
            Stair newStair = Instantiate(stairPrefab, Vector3.zero, Quaternion.identity).GetComponent<Stair>();
            newStair.gameObject.transform.parent = transform;
            stairs[i] = newStair;
        }

        stairs[0].isRight = true;
        stairs[0].SetPosition(new Vector3(0, -0.6f, 0));

        for (int i = 1; i < 50; i++)
        {
            stairs[i].SetDirection(stairs[i - 1].isRight);
            stairs[i].SetPosition(stairs[i - 1].gameObject.transform.position);
        }
    }

    public void Step()
    {
        steppingOnStair++;
        if (steppingOnStair >= 50)
        {
            steppingOnStair -= 50;
        }
    }

    public void Replace()
    {
        int index = steppingOnStair - 16;
        if (index < 0)
        {
            index += 50;
        }

        if (stairs[index].transform.position.y > GameManager.Instance.player.transform.position.y)
        {
            return;
        }

        int preIndex = index - 1;
        if (preIndex < 0)
        {
            preIndex += 50;
        }

        stairs[index].SetDirection(stairs[preIndex].isRight);
        stairs[index].SetPosition(stairs[preIndex].transform.position);
    }

    public void ResetAllStairsPosition(Vector3 value)
    {
        for (int i = 0; i < 50; i++)
        {
            Vector3 newVec = stairs[i].transform.position - value;
            stairs[i].transform.position = newVec;
        }
    }
}
