using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public UserData userdata;
    public SaveFileRW saveFileRW;

    public Player player;
    public Stairframe stairframe;
    public MainCamera mainCamera;
    public UiManager uiManager;

    public GameObject[] playerCharPrefebs;

    public int score;
    public float energy;
    public int enegyLassCycle;
    public float enegyLassAmount;
    public bool isGameOver;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        userdata = new UserData();
        saveFileRW = GetComponent<SaveFileRW>();
        saveFileRW.ReadFile();
    }

    public void GameStart()
    {
        score = 0;
        energy = 100;
        stairframe.steppingOnStair = -1;
        isGameOver = false;
        uiManager.UpdateScoreText(score);
        uiManager.UpdateEnegybar(energy);
        if (player == null)
        {
            player = Instantiate(playerCharPrefebs[userdata.CurCharIndex], Vector3.zero, Quaternion.identity).GetComponent<Player>();
        }
        player.isFalling = false;
        player.animator.SetTrigger("gameStart");
        EnergyAsync();
    }

    public void ResetGame()
    {
        stairframe.ResetStairs();
        player.transform.position = Vector3.zero;
        player.TurnAround(1);
        mainCamera.ResetPosition();
        GameStart();
    }

    async void GameOver()
    {
        if (userdata.maxScore < score)
        {
            userdata.maxScore = score;
        }
        saveFileRW.WriteFile();

        uiManager.UpdateScoreBoards(score, userdata.maxScore);

        isGameOver = true;
        player.animator.SetTrigger("gameOver");

        await Task.Delay(1000);
        player.isFalling = true;

        await Task.Delay(1000);
        uiManager.gameOverUi.SetActive(true);
    }

    async void EnergyAsync()
    {
        while (true)
        {
            energy -= enegyLassAmount;
            if (energy <= 0)
            {
                energy = 0;
                GameOver();
            }
            uiManager.UpdateEnegybar(energy);
            if (isGameOver)
            {
                break;
            }
            await Task.Delay(enegyLassCycle);
        }
    }

    public void MoveCalculation()
    {
        stairframe.Step();

        if ((stairframe.stairs[stairframe.steppingOnStair].isRight && player.dir != 1) ||
            (!stairframe.stairs[stairframe.steppingOnStair].isRight && player.dir != -1))
        {
            GameOver();
            return;
        }

        stairframe.Replace();

        if (player.transform.position.y > 10)
        {
            stairframe.ResetAllStairsPosition(player.transform.position);
            mainCamera.ResetPosition();
            player.transform.position = Vector3.zero;
        }

        score++;
        energy += 2.2f;
        if (energy >= 100)
        {
            energy = 100;
        }
        uiManager.UpdateScoreText(score);
    }

    public void SetPlayerCharIndex(int value)
    {
        userdata.CurCharIndex = value;
        saveFileRW.WriteFile();
    }
}
