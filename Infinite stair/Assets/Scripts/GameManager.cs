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
    public MainCamera mainCamera;
    public UiManager uiManager;

    public GameObject[] playerCharPrefebs;
    public int playerChIndex;

    public int score;
    public float energy;
    public bool isGameOver;

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

    public void GameStart()
    {
        score = 0;
        energy = 100;
        player = Instantiate(playerCharPrefebs[playerChIndex], new Vector3(0, 0.2f, 0), Quaternion.identity).GetComponent<Player>();
    }

    IEnumerator GameOver()
    {
        isGameOver = true;
        player.animator.SetTrigger("gameOver");

        yield return new WaitForSeconds(1f);

        player.isFalling = true;
    }

    public void MoveCalculation()
    {
        stairframe.Step();

        if ((stairframe.stairs[stairframe.steppingOnStair].isRight && player.dir != 1) ||
            (!stairframe.stairs[stairframe.steppingOnStair].isRight && player.dir != -1))
        {
            StartCoroutine(GameOver());
        }

        stairframe.Replace();

        if (player.transform.position.y > 10)
        {
            stairframe.ResetAllStairsPosition(player.transform.position);
            mainCamera.ResetPosition();
            player.transform.position = Vector3.zero;
        }

        score++;
        uiManager.UpdateScoreText(score);
    }
}
