using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject locker;
    [SerializeField] private Sprite open;
    [SerializeField] private Image image;
    [SerializeField] public Button button;
    public int levelIs;

    public void Open()
    {
        image.sprite = open;
        locker.SetActive(false);
        text.SetActive(true);
        button.enabled = true;
    }
}