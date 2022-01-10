using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform playerTrans;

    private void Start()
    {
        playerTrans = GameManager.Instance.player.transform;
        GameManager.Instance.mainCamera = this;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        Vector3 newVec = (playerTrans.position + transform.position) / 2;
        newVec.z = -10;
        transform.position = newVec;
    }

    public void ResetPosition()
    {
        Vector3 newVec = transform.position - playerTrans.position;
        transform.position = newVec;
    }
}
