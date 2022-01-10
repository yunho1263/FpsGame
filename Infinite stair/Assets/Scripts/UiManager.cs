using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public Text scoreText;

    private void Awake()
    {
        GameManager.Instance.uiManager = this;
    }

    public void UpdateScoreText(int value)
    {
        scoreText.text = value.ToString();
    }
}
