using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    //오른쪽으로 향하는 거라면 true
    public bool isRight;

    public void SetDirection(bool preDir)
    {
        float val = Random.value;

        if (val <= 0.4f)
        {
            if (preDir)
            {
                isRight = false;
            }
            else isRight = true;
        }
        else
        {
            if (preDir)
            {
                isRight = true;
            }
            else isRight = false;
        }
    }

    public void SetPosition(Vector3 prePos)
    {
        Vector3 newPos = new Vector3(0, prePos.y + 0.3f, 0);
        newPos.x = isRight ? prePos.x + 0.6f : prePos.x - 0.6f;

        transform.localPosition = newPos;
    }
}