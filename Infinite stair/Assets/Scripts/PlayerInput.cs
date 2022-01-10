using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            player.Move();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.TurnAround();
        }
    }

    public void MoveButton()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        player.Move();
    }

    public void TurnButton()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        player.TurnAround();
    }
}
