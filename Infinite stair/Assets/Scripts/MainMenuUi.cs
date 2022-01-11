using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUi : MonoBehaviour
{
    public GameObject charChangeMenu;
    public void GameStart()
    {
        SceneManager.LoadScene("IngameScene");
    }

    public void ShowCharChangeMenu(bool value)
    {
        charChangeMenu.SetActive(value);
    }

    public void SetCharIndex(int value)
    {
        GameManager.Instance.SetPlayerCharIndex(value);
        ShowCharChangeMenu(false);
    }
}
