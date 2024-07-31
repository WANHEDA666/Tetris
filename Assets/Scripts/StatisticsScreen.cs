using System;
using UnityEngine;

public class StatisticsScreen : MonoBehaviour
{
    [SerializeField] private StatRow[] StatRows;

    private void OnEnable()
    {
        for (int i = 0; i < StatRows.Length; i++)
        {
            StatRows[i].level.text = (i + 1).ToString();
            StatRows[i].score.text = PlayerPrefs.GetInt(i.ToString()).ToString();
            var t = PlayerPrefs.GetString(i + "time");
            if (t == "")
                StatRows[i].time.text = "00:00";
            else
                StatRows[i].time.text = PlayerPrefs.GetString(i + "time");
        }
    }
}