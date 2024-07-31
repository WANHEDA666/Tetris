using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] public Button pause;
    [SerializeField] public Button settings;
    [SerializeField] public Board board;
    [SerializeField] public Sprite[] tetrominoes;
    [SerializeField] private Image first;
    [SerializeField] private Image second;
    [SerializeField] private Image third;
    public Action<bool> OnGameEnded;
    
    private float elapsedTime = 0f;
    private bool gameended;
    
    private Dictionary<int, int> levelsCountsMax = new Dictionary<int, int>()
    {
        {0, 10},
        {1, 20},
        {2, 30},
        {3, 40},
        {4, 50},
        {5, 60},
        {6, 70},
        {7, 80},
        {8, 90},
        {9, 100},
        {10, 110},
        {11, 120},
    };

    private int scoreCount;
    private int seconds;
    private int currentLevel;
    private int currentMaxScore;

    private void SetNext()
    {
        first.sprite = tetrominoes[board.nextTetrominoes[0]];
        first.type = Image.Type.Simple;
        first.preserveAspect = true;
        second.sprite = tetrominoes[board.nextTetrominoes[1]];
        second.type = Image.Type.Simple;
        second.preserveAspect = true;
        third.sprite = tetrominoes[board.nextTetrominoes[2]];
        third.type = Image.Type.Simple;
        third.preserveAspect = true;
    }
    
    private void Awake()
    {
        SetNext();
        board.OnLineDestroyed += () =>
        {
            scoreCount += 10;
            score.text = scoreCount.ToString();
        };
        board.OnGameLoosed += () =>
        {
            board.activePiece.locks = true;
            PlayerPrefs.SetInt(currentLevel.ToString(), scoreCount);
            PlayerPrefs.SetString(currentLevel + "time", time.text);
            OnGameEnded.Invoke(false);
        };
        board.OnPieceSpawned += () =>
        {
            SetNext();
        };
        score.text = "0";
        time.text = "00:00";
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        currentMaxScore = levelsCountsMax[currentLevel];
        level.text = (currentLevel + 1).ToString();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // Calculate minutes and seconds from the elapsed time
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Update the UI Text with the formatted time
        if (!gameended)
        {
            time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        
        if (scoreCount >= currentMaxScore)
        {
            //PlayerPrefs.SetInt("level", currentLevel + 1);
            board.activePiece.locks = true;
            PlayerPrefs.SetInt(currentLevel.ToString(), scoreCount);
            PlayerPrefs.SetString(currentLevel + "time", string.Format("{0:00}:{1:00}", minutes, seconds));
            gameended = true;
            OnGameEnded.Invoke(true);
        }
    }

    private void OnDestroy()
    {
        board.OnLineDestroyed -= () =>
        {
            scoreCount += 10;
            score.text = scoreCount.ToString();
        };
        board.OnGameLoosed -= () =>
        {
            OnGameEnded.Invoke(false);
        };
        board.OnPieceSpawned -= () =>
        {
            SetNext();
        };
    }
}