using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;
    [SerializeField] private Button audio;
    [SerializeField] private Image image;

    private void Awake()
    {
        var isOn = PlayerPrefs.GetInt("audio") == 0;
        audio.onClick.AddListener((() =>
        {
            isOn = !isOn;
            if (isOn)
            {
                PlayerPrefs.SetInt("audio", 0);
                audioSource.Play();
                image.sprite = on;
            }
            else
            {
                PlayerPrefs.SetInt("audio", 1);
                audioSource.Stop();
                image.sprite = off;
            }
        }));
    }
}