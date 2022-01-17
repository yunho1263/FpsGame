using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //1일 때 오른쪽을 봄
    public int dir;
    public Animator animator;
    public bool isFalling;

    private void Awake()
    {
        TurnAround(1);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isFalling)
        {
            transform.Translate(new Vector3(0, -0.02f, 0));
            if (transform.position.y <= -10)
            {
                isFalling = false;
            }
        }
    }

    public void Move()
    {
        transform.Translate(new Vector3(0.6f * dir, 0.3f, 0));
        GameManager.Instance.MoveCalculation();
        animator.SetTrigger("move");
    }

    public void TurnAround()
    {
        dir *= -1;
        transform.localScale = new Vector3(dir * -1, 1, 1);
        Move();
    }

    public void TurnAround(int val)
    {
        dir = val;
        transform.localScale = new Vector3(dir * -1, 1, 1);
    }
}
