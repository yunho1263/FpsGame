using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public Player player;
    public Stairframe stairframe;

    public GameObject[] playerCharPrefebs;
    public int playerChIndex;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            instance = this;
        } else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadIngameScene()
    {
        SceneManager.LoadScene("IngameScene");
    }
}
