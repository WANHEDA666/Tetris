using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LotteryScreen : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image first;
    [SerializeField] private Image second;
    [SerializeField] private Image third;
    [SerializeField] private Button spin;

    private void Awake()
    {
        spin.onClick.AddListener((() =>
        {
            first.sprite = sprites[Random.Range(0, sprites.Length)];
            second.sprite = sprites[Random.Range(0, sprites.Length)];
            third.sprite = sprites[Random.Range(0, sprites.Length)];
        }));
    }
}