using System;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private float fallTime = 0.8f;
    private float previousTime;
    private Button lbutton;
    private Button rbutton;
    private RectTransform rect;
    
    private void Awake()
    {
        rect = gameObject.GetComponent<RectTransform>();
        lbutton = GameObject.Find("LButton").GetComponent<Button>();
        rbutton = GameObject.Find("RButton").GetComponent<Button>();
    }

    private void Start()
    {
        lbutton.onClick.AddListener(() =>
        {
            rect.offsetMin = new Vector2(rect.offsetMin.x - 636, rect.offsetMin.y);
        });
        rbutton.onClick.AddListener(() =>
        {
            rect.offsetMin = new Vector2(rect.offsetMin.x + 636, rect.offsetMin.y);
        });
    }

    private void Update()
    {
        if (Time.time - previousTime > fallTime)
        {
            rect.offsetMin = new Vector2(rect.offsetMin.x, rect.offsetMin.y - 636);
            previousTime = Time.time;
        }
    }
}