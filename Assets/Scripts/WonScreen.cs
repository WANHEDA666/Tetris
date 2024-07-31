using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WonScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI time;

    private void OnEnable()
    {
        level.text = "Level " + (PlayerPrefs.GetInt("currentLevel") + 1);
        score.text = PlayerPrefs.GetInt(PlayerPrefs.GetInt("currentLevel").ToString()).ToString();
        time.text = PlayerPrefs.GetString(PlayerPrefs.GetInt("currentLevel") + "time");
    }
}