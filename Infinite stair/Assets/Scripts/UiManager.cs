using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Image enegybar;
    public GameObject gameOverUi;

    private void Awake()
    {
        GameManager.Instance.uiManager = this;
    }

    public void UpdateScoreText(int value)
    {
        scoreText.text = value.ToString();
    }

    public void UpdateEnegybar(float value)
    {
        enegybar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value * 5);
    }

    public void Replay()
    {
        gameOverUi.SetActive(false);
        GameManager.Instance.ResetGame();
    }

    public void LoadmainMenu()
    {
        SceneManager.LoadScene("MainScene");
    }
}
